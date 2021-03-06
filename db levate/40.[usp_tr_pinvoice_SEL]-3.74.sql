USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[usp_tr_pinvoice_SEL]    Script Date: 05/08/2017 13:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Emmile
-- Create date: 5/10/2014
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[usp_tr_pinvoice_SEL] 
	-- Add the parameters for the stored procedure here
	@pinvoice_id int = 0,
	@pinvoice_no nvarchar(50) = null,
	@pinvoice_date1 smalldatetime = null,
	@pinvoice_date2 smalldatetime = null,
	@s_name nvarchar(50) = null,
	@s_id int = 0,
	@pinvoice_stat1 nvarchar(50) = null,
	@pinvoice_stat2 nvarchar(50) = null,
	@is_return bit = null,
	@is_posted bit = null,
	@po_no nvarchar(50) = null
AS
BEGIN
declare @sql nvarchar(1500)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @sql='SELECT tr_pinvoice.pinvoice_id,
	pinvoice_no,
	pinvoice_date,
	tr_pinvoice.s_id,
	mt_supplier.s_code,
	mt_supplier.s_name,
	tr_po.po_id,
	po_no,
	tr_pinvoice.pch_code_id,
	mt_trx_code.trx_code,
	pinvoice_terms,
	pinvoice_duedate,
	tr_pinvoice.ref_no,
	pinvoice_remarks,
	tr_pinvoice.curr_id,
	mt_curr.curr_code,
	pinvoice_curr_rate,
	pinvoice_subtotal,
	pinvoice_tax,
	pinvoice_total,
	pinvoice_payment,
	pinvoice_total-pinvoice_payment as pinvoice_outstanding,
	(pinvoice_total-pinvoice_payment)*pinvoice_curr_rate as local_pinvoice_outstanding,
	local_subtotal,
	local_tax,
	local_total,
	pinvoice_status,
	a.pinvoice_status_val,
	tr_pinvoice.is_posted,
	pinvoice_period_id
	from tr_pinvoice
	left join tr_po on tr_pinvoice.po_id=tr_po.po_id 
	inner join mt_supplier on tr_pinvoice.s_id = mt_supplier.s_id
	inner join mt_curr on tr_pinvoice.curr_id=mt_curr.curr_id
	inner join mt_trx_code on tr_pinvoice.pch_code_id=mt_trx_code.trx_code_id
	inner join (select sys_dropdown_id, sys_dropdown_val as pinvoice_status_val from sys_dropdown where sys_dropdown_whr=''pinvoice_status'')a
	on tr_pinvoice.pinvoice_status=a.sys_dropdown_id
	where tr_pinvoice.AC=0'
	if @pinvoice_id <> 0
		set @sql=@sql+' and pinvoice_id='+CONVERT(nvarchar(50),@pinvoice_id)
	if @pinvoice_date1 is not null
		BEGIN
		if @pinvoice_date2 is not null
			set @sql=@sql+ ' and pinvoice_date between '''+convert(nvarchar(50),@pinvoice_date1,101)+''' and '''+convert(nvarchar(50),@pinvoice_date2,101)+''''
		else
			set @sql=@sql+ ' and pinvoice_date <='''+convert(nvarchar(50),@pinvoice_date1,101)+''''
		END
	if @pinvoice_no is not null
		set @sql=@sql+' and pinvoice_no like ''%'+@pinvoice_no+'%'''
	if @s_name is not null
		set @sql=@sql+' and mt_supplier.s_name like ''%'+@s_name+'%'''
	if @s_id <> 0
		set @sql=@sql+' and tr_pinvoice.s_id='+CONVERT(nvarchar(50),@s_id)
	if @pinvoice_stat1 is not null
		BEGIN
		if @pinvoice_stat2 is not null	
			set @sql=@sql+' and (pinvoice_status='''+@pinvoice_stat1+''' or pinvoice_status='''+@pinvoice_stat2+''')'
		else
			set @sql=@sql+' and pinvoice_status='''+@pinvoice_stat1+''''
		END
	if @is_return is not null
		set @sql=@sql+' and is_return='+CONVERT(nvarchar(50),@is_return)
	if @is_posted is not null
		set @sql=@sql+' and is_posted='+CONVERT(nvarchar(50),@is_posted)
	if @po_no is not null
		set @sql=@sql+' and tr_po.po_no like ''%'+@po_no+'%'''
	exec(@sql)
END

