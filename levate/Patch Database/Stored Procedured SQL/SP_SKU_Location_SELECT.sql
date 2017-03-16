USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_sku_location_select]    Script Date: 07/04/2014 14:41:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sku_location_select] 
@location_a nvarchar(50)=null,@location_b nvarchar(50)=null,@code_a nvarchar(30)=null,@code_b nvarchar(30)=null
AS
Begin
	Declare @mssql nvarchar(555)
	set @mssql='select location_code,location_name,sku_code,s.sku_name,sku_barcode,sku_uom,sales_discount,sales_price,stock_value,stock_balance,avg_cost,sku_remarks,sku_qty from mt_sku_location ms inner join mt_sku s on s.sku_id=ms.sku_id inner join mt_location ml on ml.location_id=ms.location_id where s.sku_id<>0'
	if @location_a<>''set @mssql=@mssql +  ' and location_code>='''+@location_a +''' and location_code<='''+@location_b +''' '
	if @code_a<>''    set @mssql=@mssql +  ' and sku_code>='''+@code_a +''' and sku_code<='''+@code_b +''' '
	exec(@mssql)
End	

GO


