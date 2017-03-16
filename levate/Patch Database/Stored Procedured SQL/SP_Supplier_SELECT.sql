USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_supplier_select]    Script Date: 07/02/2014 10:47:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_supplier_select] 
@code_a nvarchar(30)=null ,@code_b nvarchar(30)=null
AS
Begin
Declare 
	@mssql nvarchar(255)
	set @mssql='select ms.s_id,ms.s_code,ms.s_name,ms.s_email,ms.s_contact,ms.s_address1,
				ms.s_address2,mc.curr_code,ms.s_balance,ms.s_local_balance 
				from mt_supplier ms
				inner join mt_curr mc on mc.curr_id=ms.s_curr_id'
	if @code_a<>'' set @mssql=@mssql + ' where s_code>='''+@code_a +''''
	if @code_a<>'' set @mssql=@mssql + ' and s_code<='''+@code_b +''''
	exec(@mssql)
End

GO


