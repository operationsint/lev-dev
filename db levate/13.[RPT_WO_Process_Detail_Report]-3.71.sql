USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_WO_Process_Detail_Report]    Script Date: 03/21/2017 13:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Exec RPT_WO_Process_Detail_Report '2017-03-21' , '2017-03-21', '104', ''
ALTER PROCEDURE [dbo].[RPT_WO_Process_Detail_Report] 
	(
	@dtpFrom				date,
	@dtpTo					date,
	@sFinishGoods			nvarchar(50),
	@sProcess				nvarchar (50)
	)
AS
Begin

Declare @SQLString nvarchar(max)=''
Declare @iStartDate	as int
Declare @iEndDate	as int

Set @iStartDate = (((YEAR(@dtpFrom) * 100) + MONTH(@dtpFrom)) * 100) + DAY(@dtpFrom)
Set @iEndDate = (((YEAR(@dtpTo) * 100) + MONTH(@dtpTo)) * 100) + DAY(@dtpTo)

--------------------------------------------------
-- Company Data
--------------------------------------------------
Declare @company_name		as nvarchar(50)
Declare @company_address1	as nvarchar(255)
Declare @company_address2	as nvarchar(255)
Declare @company_phone1		as nvarchar(50)
Declare @company_fax		as nvarchar(50)
	

Select 
@company_name = company_name,
@company_address1 = company_address1,
@company_address2 = company_address2,
@company_phone1 = company_phone1,
@company_fax = company_fax
From sys_company
Where company_id = 1
--------------------------------------------------

-----------------------------------------------------------------------------------------
-- A. Confirm In Table
-----------------------------------------------------------------------------------------
-- Create Table
Create Table #tbConfirmIn (
		stock_adj_no	nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		stock_adj_date	smalldatetime,
		wo_no			nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		stock_adj_qty	numeric(18, 2)
		)

-- Insert Date
set @SQLString = N'Insert Into #tbConfirmIn ' + char(13) 
set @SQLString = @SQLString + N'Select  A.stock_adj_no, A.stock_adj_date, ' + char(13)   
set @SQLString = @SQLString + N'C.wo_no, SUM(B.stock_adj_qty) ' + char(13)   
set @SQLString = @SQLString + N'From tr_stock_adj A ' + char(13) 
set @SQLString = @SQLString + N'Inner Join tr_stock_adj_dtl B ON A.stock_adj_id = B.stock_adj_id ' + char(13) 
set @SQLString = @SQLString + N'Inner Join tr_work_order C ON A.wo_no = C.wo_no ' + char(13)  
set @SQLString = @SQLString + N'Where A.AC = 0 ' + char(13) 
set @SQLString = @SQLString + N'And A.trans_type = ''STPRO'' ' + char(13) 
set @SQLString = @SQLString + N'And stock_adj_qty > 0 ' + char(13) 

set @SQLString = @SQLString + N'And (((Year(C.wo_date) * 100) + Month(C.wo_date)) * 100) + Day(C.wo_date) >= ' +  CAST(@iStartDate As CHAR(8)) +  ' ' + char(13)  
set @SQLString = @SQLString + N'And (((Year(C.wo_date) * 100) + Month(C.wo_date)) * 100) + Day(C.wo_date) <= ' +  CAST(@iEndDate As CHAR(8)) +  ' ' + char(13)  

IF RTRIM(LTRIM(@sFinishGoods)) <> '' 
	BEGIN
		set @SQLString = @SQLString + N'And C.sku_code = ''' + RTRIM(LTRIM(@sFinishGoods)) + ''' ' + char(13)  
	END

set @SQLString = @SQLString + N'Group By A.stock_adj_no, A.stock_adj_date, C.wo_no'

-- Execute Query
exec(@SQLString)
-----------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------
-- B. WO Process Table
-----------------------------------------------------------------------------------------
-- Create Table
Create Table #tbWOProcess (
		wo_no					nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		wo_date					smalldatetime,
		sku_code				nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		qty_order				decimal(18, 2),
		process_code			nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		process_qty				decimal(18, 2),
		process_cost			decimal(18, 2),
		process_qty_perunit		decimal(18, 2),
		labour_code				nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS	
		)


-- Insert Data
set @SQLString = N'Insert Into #tbWOProcess ' + char(13)
set @SQLString = @SQLString + N'Select A.wo_no, A.wo_date,  ' + char(13)
set @SQLString = @SQLString + N'A.sku_code, A.qty_order, ' + char(13) 
set @SQLString = @SQLString + N'B.process_code, B.process_qty, B.process_cost, B.process_qty_perunit, ' + char(13)
set @SQLString = @SQLString + N'B.labour_code ' + char(13) 
set @SQLString = @SQLString + N'From tr_work_order A ' + char(13)
set @SQLString = @SQLString + N'Inner Join tr_work_order_process B ON A.wo_no = B.wo_no ' + char(13)
set @SQLString = @SQLString + N'Where A.AC = 0 ' + char(13)
set @SQLString = @SQLString + N'And A.wo_no In ' + char(13)
set @SQLString = @SQLString + N'	(Select wo_no From #tbConfirmIn)'

-- Execute Query
exec(@SQLString)
-----------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------
-- C. Main Table
-----------------------------------------------------------------------------------------
-- Create Table
Create Table #tbMain (
		stock_adj_no				nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		stock_adj_date				smalldatetime,
		wo_no						nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		stock_adj_qty				numeric(18, 2),
		wo_date						smalldatetime,
		sku_code					nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		qty_order					decimal(18, 2),
		process_code				nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		process_qty					decimal(18, 2),
		process_cost				decimal(18, 2),
		process_qty_perunit			decimal(18, 2),
		labour_code					nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
		process_qty_conf_in			decimal(18, 2)
)

-- Insert Data
set @SQLString = N'Insert Into #tbMain' + char(13)
set @SQLString = @SQLString + N'Select A.stock_adj_no, A.stock_adj_date, A.wo_no,' + char(13)
set @SQLString = @SQLString + N'A.stock_adj_qty, ' + char(13)
set @SQLString = @SQLString + N'B.wo_date, B.sku_code, B.qty_order, ' + char(13)
set @SQLString = @SQLString + N'B.process_code, B.process_qty, B.process_cost,' + char(13)
set @SQLString = @SQLString + N'B.process_qty_perunit, B.labour_code, 0 As process_qty_conf_in' + char(13)
set @SQLString = @SQLString + N'From #tbConfirmIn A' + char(13)
set @SQLString = @SQLString + N'Inner Join #tbWOProcess B ON A.wo_no = B.wo_no' + char(13)
set @SQLString = @SQLString + N'Where 1 = 1' + char(13)

IF LTRIM(RTRIM(@sProcess)) <> ''
	Begin
		set @SQLString = @SQLString + N'And B.process_code = ''' + LTRIM(RTRIM(@sProcess)) + ''' ' + char(13)
	End

-- Execute Query
Exec(@SQLString)

-- Update process_qty_conf_in
Update #tbMain
Set 
	process_qty_conf_in = Case When qty_order = 0 Then
								0
						  Else
								(stock_adj_qty/qty_order) * (process_qty)
						  End
-----------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------
-- D. Result
-----------------------------------------------------------------------------------------
Select
@company_name as company_name, @company_address1 as company_address1,
@company_address2 as company_address2, @company_phone1 as company_phone1,
@company_fax as company_fax,

A.process_code, IsNull(B.process_name, '') As process_name,
A.stock_adj_no, A.stock_adj_date, A.wo_no,
A.sku_code, IsNull(C.sku_name, '') As sku_name, 
A.labour_code, IsNull(D.labour_name, '') As labour_name,
A.process_qty_conf_in, A.process_cost, A.process_qty_conf_in * A.process_cost as total_cost
From #tbMain A
Left Join mt_process B ON A.process_code = B.process_code
Left Join mt_sku C ON A.sku_code = C.sku_code 
Left Join mt_labour D ON A.labour_code = D.labour_code 
Order By A.process_code, A.stock_adj_date, A.wo_no, A.sku_code, A.labour_code
-----------------------------------------------------------------------------------------


-- Drop Table
Drop Table #tbConfirmIn
Drop Table #tbWOProcess
Drop Table #tbMain

END
