USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_currency_select]    Script Date: 07/02/2014 10:42:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_currency_select] 
@code_a nvarchar(30) ,@code_b nvarchar(30)
as
Begin
Declare 
	@mssql nvarchar(255)
	set @mssql='select * from mt_curr'
	if @code_a<>'' set @mssql=@mssql + ' where curr_code>='''+@code_a +''''
	if @code_a<>'' set @mssql=@mssql + ' and curr_code<='''+@code_b +''''
	exec(@mssql)
End
GO


