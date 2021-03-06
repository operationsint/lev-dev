USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[usp_tr_so_dtl_SEL]    Script Date: 03/23/2017 16:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Emmile
-- Create date: 8/21/2013
-- Description:	Select tr_so_dtl
-- =============================================
--exec usp_tr_so_dtl_SEL 0,1814
ALTER PROCEDURE [dbo].[usp_tr_so_dtl_SEL] 
	-- Add the parameters for the stored procedure here
	@so_dtl_id int = 0, 
	@so_id int = 0,
	@so_dtl_type nvarchar(50) = null,
	@sku_name nvarchar(50) = null,
	@outstanding bit = null,
	@lot_job nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    declare @sql nvarchar(1500),@sql1 nvarchar(1500)=''
	set @sql='SELECT tr_so_dtl.so_dtl_id,
	so_id,
	so_dtl_type,
	a.sys_dropdown_val,
	tr_so_dtl.sku_id,
	mt_sku.sku_code,
	so_dtl_description,
	tr_so_dtl.location_id,
	mt_location.location_code,
	so_qty,
	mt_sku.sku_uom,
	isnull(mt_sku.avg_cost,0) sku_avg_cost,
	so_price,
	so_dtl_gross,
	so_dtl_discpercent*100 as so_discpercent,
	so_dtl_discamount,
	so_dtl_subtotal,
	so_dtl_taxpercent*100 as so_taxpercent,
	so_dtl_tax,
	so_dtl_net,
	tr_so_dtl.income_id,
	mt_expinc.expinc_code,
	tr_so_dtl.so_qty-tr_so_dtl.sum_sdelivery_qty as qty_outstanding,
	tr_so_dtl.sum_sdelivery_qty,
	lot_job_no,
	required_delivery_date,
	CASE WHEN Z.so_dtl_id is null THEN ''Yes'' else ''No'' end as can_edit,
	ISNULL(tr_so_dtl.so_dtl_tierdiscpercent,0)*100 as so_dtl_tierdiscpercent '
	set @sql1='from tr_so_dtl
	left join mt_sku on tr_so_dtl.sku_id=mt_sku.sku_id
	left join mt_location on tr_so_dtl.location_id=mt_location.location_id
	left join mt_expinc on tr_so_dtl.income_id=mt_expinc.expinc_id
	inner join (select sys_dropdown_id, sys_dropdown_val from sys_dropdown where sys_dropdown_whr=''so_dtl_type'') a
	on tr_so_dtl.so_dtl_type=a.sys_dropdown_id
	left join (select distinct so_dtl_id from tr_sdelivery_dtl) Z on Z.so_dtl_id = tr_so_dtl.so_dtl_id'
	if @so_dtl_id <> 0
		set @sql1=@sql1+' where so_dtl_id='+CONVERT(nvarchar(50),@so_dtl_id)
	if @so_id <> 0
		set @sql1=@sql1+' where so_id='+CONVERT(nvarchar(50),@so_id)
	if @so_dtl_type is not null
		set @sql1=@sql1+' and so_dtl_type ='''+@so_dtl_type+''''
	if @sku_name is not null
		set @sql1=@sql1+' and so_dtl_description like ''%'+@sku_name+'%'''
	if @outstanding=1
		set @sql1=@sql1+' and tr_so_dtl.so_qty-tr_so_dtl.sum_sdelivery_qty>0'
	if @lot_job is not null
	set @sql1=@sql1+' and lot_job_no like ''%'+@lot_job+'%'''
	exec(@sql+@sql1)
END
