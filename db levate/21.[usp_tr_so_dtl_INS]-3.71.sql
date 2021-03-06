USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[usp_tr_so_dtl_INS]    Script Date: 03/23/2017 15:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Emmile
-- Create date: 8/22/2013
-- Description:	Insert tr_so_dtl
-- =============================================
ALTER PROCEDURE [dbo].[usp_tr_so_dtl_INS] 
	-- Add the parameters for the stored procedure here
	@so_id int = 0, 
	@so_dtl_type nvarchar(50) = null,
	@sku_id int = 0,
	@so_dtl_desc nvarchar(255),
	@so_qty numeric(18,2) = 0.00,
	@so_price decimal(18,6),
	@so_dtl_discpercent decimal(18,4),
	@tax_percent decimal(18,2),
	@location_id int = 0,
	@income_id int = 0,
	@lot_job_no nvarchar(50) = null,
	@required_delivery_date smalldatetime = null,
	@is_package bit = 0,
	-- 20160505 daniel s : use disc amount
	@so_dtl_discamount2 decimal(18,2) = 0
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
	/*
	if @sku_id>0 and exists(select sku_id from tr_so_dtl where so_id=@so_id and sku_id=@sku_id)
		update tr_so_dtl set
		so_qty=so_qty+@so_qty
		where so_id=@so_id and sku_id=@sku_id
	
	else
		BEGIN
		*/
	
	-----------------------------------------------------
	-- Is Finish Goods
	-----------------------------------------------------
	Declare @is_finish_goods as bit
	If @sku_id>0 and @is_package=1
		Begin
			Select @is_finish_goods = is_finish_goods
			From mt_sku Where sku_id = @sku_id
		End
	Else
		Begin
			Set @is_finish_goods = 0
		End
	
	If @is_finish_goods Is Null
		Begin
			Set @is_finish_goods = 0
		End
	-----------------------------------------------------
	
		
	if @sku_id>0 and @is_package=1 and @is_finish_goods = 0
		IF (select sys_init_val from sys_init where sys_init_id = 'autoDeliveryDate') = 'True' AND @required_delivery_date IS NOT NULL  --Jangan lupa ini diganti true
		BEGIN
			declare @p_skuid2 int,
					@p_sku_name nvarchar,
					@p_sku_package_qty int,
					@p_sales_price decimal,
					@p_sales_discount decimal,
					@p_count int;
		
			-- Set cursor untuk tambahan 
			DECLARE p_cursor CURSOR FOR
			select
			mt_sku_package.sku_id2,
			mt_sku.sku_name,
			mt_sku_package.sku_package_qty,
			mt_sku.sales_price,
			mt_sku.sales_discount
			from
			mt_sku_package
			inner join mt_sku on mt_sku_package.sku_id2=mt_sku.sku_id
			where mt_sku_package.sku_id1=@sku_id

			OPEN p_cursor

			FETCH NEXT FROM p_cursor
			INTO @p_skuid2,@p_sku_name,@p_sku_package_qty,@p_sales_price,@p_sales_discount
				
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @p_count=0
				
				insert into tr_so_dtl
				(
				so_id,
				so_dtl_type,
				sku_id,
				so_dtl_description,
				so_qty,
				so_price,
				so_dtl_discpercent,
				so_dtl_taxpercent,
				location_id,
				income_id,
				lot_job_no,
				required_delivery_date
				,so_dtl_discamount2
				,so_dtl_tax2
				,stockset
				)
				values(
				@so_id,
				@so_dtl_type,
				@p_skuid2,
				@p_sku_name,
				@so_qty*@p_sku_package_qty,
				@p_sales_price,
				@p_sales_discount,
				@tax_percent,
				@location_id,
				@income_id,
				@lot_job_no,
				@required_delivery_date,
				@so_dtl_discamount2,
				@so_dtl_tax2,
				@sku_id
				)
				FETCH NEXT FROM p_cursor
				INTO @p_skuid2,@p_sku_name,@p_sku_package_qty,@p_sales_price,@p_sales_discount
				
				SET @p_count = @p_count + 1
				SET @required_delivery_date = DATEADD(DAY,@p_count,@required_delivery_date)
			END
			
			CLOSE p_cursor;
			DEALLOCATE p_cursor;
		END
		ELSE
		BEGIN
			insert into tr_so_dtl
			(
			so_id,
			so_dtl_type,
			sku_id,
			so_dtl_description,
			so_qty,
			so_price,
			so_dtl_discpercent,
			so_dtl_taxpercent,
			location_id,
			income_id,
			lot_job_no,
			required_delivery_date
			,so_dtl_discamount2
			,so_dtl_tax2
			,stockset
			)
			select
			@so_id,
			@so_dtl_type,
			mt_sku_package.sku_id2,
			mt_sku.sku_name,
			@so_qty*mt_sku_package.sku_package_qty,
			mt_sku.sales_price,
			mt_sku.sales_discount,
			@tax_percent,
			@location_id,
			@income_id,
			@lot_job_no,
			@required_delivery_date,
			@so_dtl_discamount2,
			@so_dtl_tax2,
			@sku_id
			from
			mt_sku_package
			inner join mt_sku on mt_sku_package.sku_id2=mt_sku.sku_id
			where mt_sku_package.sku_id1=@sku_id
		END
		
	else
		BEGIN
			if @so_dtl_type='T' 
			begin 
				set @tax_percent=0
				set @so_dtl_tax2=0
			end
		
			insert into tr_so_dtl
			(
			so_id,
			so_dtl_type,
			sku_id,
			so_dtl_description,
			so_qty,
			so_price,
			so_dtl_discpercent,
			so_dtl_taxpercent,
			location_id,
			income_id,
			lot_job_no,
			required_delivery_date
			,so_dtl_discamount2
			,so_dtl_tax2
			,so_dtl_tierdiscpercent
			)
			values
			(
			@so_id,
			@so_dtl_type,
			@sku_id,
			@so_dtl_desc,
			@so_qty,
			@so_price,
			@so_dtl_discpercent,
			@tax_percent,
			@location_id,
			@income_id,
			@lot_job_no,
			@required_delivery_date
			,@so_dtl_discamount2
			,@so_dtl_tax2
			,@so_dtl_tierdiscpercent
			)
		END
END

