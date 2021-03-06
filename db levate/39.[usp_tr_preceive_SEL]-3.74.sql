USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[usp_tr_preceive_SEL]    Script Date: 05/08/2017 13:19:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Emmile
-- Create date: 8/14/2014
-- Description:	Select tr_preceive
-- =============================================
ALTER PROCEDURE [dbo].[usp_tr_preceive_SEL] 
	-- Add the parameters for the stored procedure here
	@preceive_id int = 0, 
	@po_id int = null,
	@preceive_no nvarchar(50) = null,
	@preceive_date1 smalldatetime = null,
	@preceive_date2 smalldatetime = null,
	@s_name nvarchar(50) = null,
	@preceive_stat nvarchar(50) = null,
	@is_posted bit = null,
	@po_no nvarchar(50) = null
AS
BEGIN
declare @sql nvarchar(1000)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @sql='SELECT preceive_id,
	preceive_no,
	preceive_date,
	tr_preceive.po_id,
	tr_po.po_no,
	tr_preceive.s_id,
	mt_supplier.s_code,
	mt_supplier.s_name,
	tr_po.payment_terms,
	DATEADD(d,tr_po.payment_terms,preceive_date) payment_duedate,
	preceive_remarks,
	tr_po.po_status,
	preceive_status,
	a.preceive_status_val,
	tr_preceive.ref_no,
	tr_preceive.is_posted,
	preceive_period_id
	from tr_preceive
	inner join tr_po on tr_preceive.po_id=tr_po.po_id
	inner join mt_supplier on tr_preceive.s_id=mt_supplier.s_id
	inner join (select sys_dropdown_id, sys_dropdown_val as preceive_status_val from sys_dropdown where sys_dropdown_whr=''preceive_status'')a
	on tr_preceive.preceive_status=a.sys_dropdown_id
	where tr_preceive.AC=0'
	if @preceive_id <> 0
		set @sql=@sql+' and preceive_id='+CONVERT(nvarchar(50),@preceive_id)
	if @po_id is not null
		set @sql=@sql+' and tr_preceive.po_id='+CONVERT(nvarchar(50),@po_id)
	if @preceive_date1 is not null
		BEGIN
		if @preceive_date2 is not null
			set @sql=@sql+ ' and preceive_date between '''+convert(nvarchar(50),@preceive_date1,101)+''' and '''+convert(nvarchar(50),@preceive_date2,101)+''''
		else
			set @sql=@sql+ ' and preceive_date <='''+convert(nvarchar(50),@preceive_date1,101)+''''
		END
	if @preceive_no is not null
		set @sql=@sql+' and preceive_no like ''%'+@preceive_no+'%'''
	if @s_name is not null
		set @sql=@sql+' and mt_supplier.s_name like ''%'+@s_name+'%'''
	if @preceive_stat is not null
		set @sql=@sql+' and preceive_status='''+@preceive_stat+''''
	if @is_posted is not null
		set @sql=@sql+' and is_posted='+CONVERT(nvarchar(50),@is_posted)
	if @po_no is not null
		set @sql=@sql+' and tr_po.po_no like ''%'+@po_no+'%'''
	exec(@sql)
END