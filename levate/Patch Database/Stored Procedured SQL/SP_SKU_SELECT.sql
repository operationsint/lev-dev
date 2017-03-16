USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_sku_select]    Script Date: 07/02/2014 10:47:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_sku_select] 
@code_a nvarchar(30)=null ,@code_b nvarchar(30)=null
as
begin
	Declare @mssql nvarchar(255)
	set @mssql='select * from mt_sku'
	if @code_a<>'' set @mssql=@mssql + ' where sku_code>='''+@code_a +''''
	if @code_a<>'' set @mssql=@mssql + ' and sku_code<='''+@code_b +''''
	exec (@mssql)
End
GO


