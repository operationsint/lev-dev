USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_expinc_select]    Script Date: 07/02/2014 10:46:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_expinc_select] 
@type nvarchar(30)=null,@code_a nvarchar(30)=null,@code_b nvarchar(30)=null
AS
begin
Declare 
	@mssql nvarchar(255)
	set @mssql='select * from mt_expinc '
	if @type='Expense' set @mssql=@mssql + ' where expinc_type=''E'''
	if @type='Income' set @mssql=@mssql + ' where expinc_type=''I'''
	if @type='All' or @type='' set @mssql=@mssql + ' where expinc_type>=''E'''
	if @code_a<>'' set @mssql=@mssql + 'and expinc_code>='''+@code_a +''' and expinc_code<='''+@code_b +''' '
	exec(@mssql)
End	
GO


