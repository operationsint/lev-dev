USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[usp_tr_sinvoice_SEL]    Script Date: 05/03/2017 11:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Emmile
-- Create date: 8/26/2013
-- Description:	Select tr_invoice
-- =============================================
ALTER PROCEDURE [dbo].[usp_tr_sinvoice_SEL] 
	-- Add the parameters for the stored procedure here
	@sinvoice_id int = 0, 
	@sinvoice_no nvarchar(50) = null,
	@sinvoice_date1 smalldatetime = null,
	@sinvoice_date2 smalldatetime = null,
	@c_name nvarchar(50) = null,
	@c_id int = 0,
	@sinvoice_stat1 nvarchar(50) = null,
	@sinvoice_stat2 nvarchar(50) = null,
	@is_return bit = null,
	@is_posted bit = null,
	@so_no nvarchar(50) = null
AS
BEGIN
	declare @sql nvarchar(MAX),@sql1 nvarchar(1500)
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
	set @sql='
	SELECT tr_sinvoice.sinvoice_id
	, sinvoice_no
	, sinvoice_date
	, tr_sinvoice.c_id
	, mt_customer.c_code
	, mt_customer.c_name
	, tr_sinvoice.sls_code_id
	, mt_trx_code.trx_code
	, sinvoice_terms 
	, sinvoice_duedate
	, tr_sinvoice.ref_no 
	, sinvoice_remarks
	, tr_sinvoice.curr_id
	, mt_curr.curr_code
	, sinvoice_curr_rate
	, sinvoice_gross
	, sinvoice_discount
	, sinvoice_subtotal
	, sinvoice_tax
	, sinvoice_total
	, sinvoice_payment
	, sinvoice_total-sinvoice_payment as sinvoice_outstanding
	, (sinvoice_total-sinvoice_payment)*sinvoice_curr_rate as local_sinvoice_outstanding
	, local_subtotal
	, local_tax
	, local_total
	, sinvoice_status
	, a.sinvoice_status_val
	, is_posted
	, sinvoice_period_id
	, tr_so.so_no
	from tr_sinvoice
	inner join mt_customer on tr_sinvoice.c_id=mt_customer.c_id
	inner join mt_curr on tr_sinvoice.curr_id=mt_curr.curr_id
	inner join mt_trx_code on tr_sinvoice.sls_code_id=mt_trx_code.trx_code_id
	inner join (select sys_dropdown_id, sys_dropdown_val as sinvoice_status_val from sys_dropdown where sys_dropdown_whr=''sinvoice_status'')a
	on tr_sinvoice.sinvoice_status=a.sys_dropdown_id
	inner join tr_sinvoice_dtl on tr_sinvoice.sinvoice_id = tr_sinvoice_dtl.sinvoice_id
	left join tr_sdelivery_dtl on tr_sinvoice_dtl.sdelivery_dtl_id = tr_sdelivery_dtl.sdelivery_dtl_id
	left join tr_so_dtl on tr_so_dtl.so_dtl_id = tr_sdelivery_dtl.so_dtl_id
	left join tr_so on tr_so.so_id = tr_so_dtl.so_id
	where tr_sinvoice.AC=0'
	if @sinvoice_id <> 0
		set @sql=@sql+' and tr_sinvoice.sinvoice_id='+CONVERT(nvarchar(50),@sinvoice_id)
	if @sinvoice_date1 is not null
		BEGIN
		if @sinvoice_date2 is not null
			set @sql=@sql+ ' and sinvoice_date between '''+convert(nvarchar(50),@sinvoice_date1,101)+''' and '''+convert(nvarchar(50),@sinvoice_date2,101)+''''
		else
			set @sql=@sql+ ' and sinvoice_date <='''+convert(nvarchar(50),@sinvoice_date1,101)+''''
		END
	if @sinvoice_no is not null
		set @sql=@sql+' and sinvoice_no like ''%'+@sinvoice_no+'%'''
	if @c_name is not null
		set @sql=@sql+' and mt_customer.c_name like ''%'+@c_name+'%'''
	if @c_id <> 0
		set @sql=@sql+' and tr_sinvoice.c_id='+CONVERT(nvarchar(50),@c_id)
	if @sinvoice_stat1 is not null
		BEGIN
		if @sinvoice_stat2 is not null	
			set @sql=@sql+' and (sinvoice_status='''+@sinvoice_stat1+''' or sinvoice_status='''+@sinvoice_stat2+''')'
		else
			set @sql=@sql+' and sinvoice_status='''+@sinvoice_stat1+''''
		END
	if @is_return is not null
		set @sql=@sql+' and is_return='+CONVERT(nvarchar(50),@is_return)
	IF @is_posted is not null
		set @sql=@sql+' and is_posted='+CONVERT(nvarchar(50),@is_posted)
	if @so_no is not null
		set @sql=@sql+' and tr_so.so_no like ''%'+@so_no+'%'''
	
	SET @sql1 = ' GROUP BY 
	tr_sinvoice.sinvoice_id
	, sinvoice_no
	, sinvoice_date
	, tr_sinvoice.c_id
	, mt_customer.c_code
	, mt_customer.c_name
	, tr_sinvoice.sls_code_id
	, mt_trx_code.trx_code
	, sinvoice_terms 
	, sinvoice_duedate
	, tr_sinvoice.ref_no 
	, sinvoice_remarks
	, tr_sinvoice.curr_id
	, mt_curr.curr_code
	, sinvoice_curr_rate
	, sinvoice_gross
	, sinvoice_discount
	, sinvoice_subtotal
	, sinvoice_tax
	, sinvoice_total
	, sinvoice_payment
	, sinvoice_total-sinvoice_payment 
	, (sinvoice_total-sinvoice_payment)*sinvoice_curr_rate 
	, local_subtotal
	, local_tax
	, local_total
	, sinvoice_status
	, a.sinvoice_status_val
	, is_posted
	, sinvoice_period_id
	, tr_so.so_no'
	exec(@sql+@sql1)
END

--exec usp_tr_sinvoice_SEL 0,null,null,null,null,0,null,null,null,null,'SO1608'