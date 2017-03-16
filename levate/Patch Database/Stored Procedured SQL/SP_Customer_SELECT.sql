USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_customer_select]    Script Date: 07/02/2014 10:46:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_customer_select] 
@code_a nvarchar(30)=null,@code_b nvarchar(30)=null
AS
begin
Declare 
	@mssql nvarchar(255)
	set @mssql='select * from mt_customer'
	if @code_a<>'' set @mssql=@mssql + ' where c_code>='''+@code_a +''''
	if @code_a<>'' set @mssql=@mssql + ' and c_code<='''+@code_b +''''
	exec(@mssql)
End	
GO


