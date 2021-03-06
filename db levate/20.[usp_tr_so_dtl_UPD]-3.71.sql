USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[usp_tr_so_dtl_UPD]    Script Date: 03/23/2017 15:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Emmile
-- Create date: 8/23/2013
-- Description:	Update tr_so_dtl
-- =============================================
ALTER PROCEDURE [dbo].[usp_tr_so_dtl_UPD]
	-- Add the parameters for the stored procedure here
	@so_dtl_id int, 
	@so_id int = 0,
	@so_dtl_type nvarchar(50) = null,
	@sku_id int = 0,
	@so_dtl_desc nvarchar(255) = null,
	@so_qty numeric(18,2) = 0.00,
	@so_price decimal(18,6),
	@so_dtl_discpercent decimal(18,4) = 0,
	@tax_percent decimal(18,1),
	@location_id int = 0,
	@income_id int = 0,
	@lot_job_no nvarchar(50) = null,
	@required_delivery_date smalldatetime = null,
	@is_package bit = 0
	-- 20160505 daniel s : use disc amount
	,@so_dtl_discamount2 decimal(18,2) = 0
	-- 20160827 : use tax amount
	,@so_dtl_tax2 decimal(18,2)
	-- 20170323 : tier disc
	,@so_dtl_tierdiscpercent decimal(18,4)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tr_so_dtl set
	so_id=@so_id,
	so_dtl_type=@so_dtl_type,
	sku_id=@sku_id,
	so_dtl_description=@so_dtl_desc,
	so_qty=@so_qty,
	so_price=@so_price,
	so_dtl_discpercent=@so_dtl_discpercent,
	so_dtl_taxpercent=@tax_percent,
	location_id=@location_id,
	income_id=@income_id,
	lot_job_no=@lot_job_no,
	required_delivery_date=@required_delivery_date
	,so_dtl_discamount2 = @so_dtl_discamount2 
	,so_dtl_tax2=@so_dtl_tax2
	,so_dtl_tierdiscpercent=@so_dtl_tierdiscpercent
	where so_dtl_id=@so_dtl_id
END

