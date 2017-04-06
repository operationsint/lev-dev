
/****** Object:  StoredProcedure [dbo].[usp_tr_sdelivery_SEL]    Script Date: 04/06/2017 14:23:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_tr_sdelivery_SEL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_tr_sdelivery_SEL]
GO

/****** Object:  StoredProcedure [dbo].[usp_tr_sdelivery_SEL]    Script Date: 04/06/2017 14:23:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Emmile
-- Create date: 2014/6/17
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_tr_sdelivery_SEL] 
	-- Add the parameters for the stored procedure here
	@sdelivery_id int = 0, 
	@so_id int = 0,
	@sdelivery_no nvarchar(50) = null,
	@sdelivery_date1 smalldatetime = null,
	@sdelivery_date2 smalldatetime = null,
	@c_name nvarchar(50) = null,
	@sdelivery_stat nvarchar(50) = null,
	@is_posted bit = null,
	@so_no nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    declare @sql nvarchar(1000)
    
	set @sql='
	SELECT sdelivery_id
	, sdelivery_no
	, sdelivery_date
	, tr_so.so_id
	, tr_so.so_no
	, tr_so.c_id
	, mt_customer.c_code
	, mt_customer.c_name
	, tr_so.payment_terms
	, DATEADD(d,tr_so.payment_terms,sdelivery_date) payment_duedate
	, sdelivery_remarks
	, tr_so.so_status
	, sdelivery_status
	, a.sdelivery_status_val
	, vehicle_number
	, is_posted
	, sdelivery_period_id
	from tr_sdelivery
	inner join tr_so on tr_sdelivery.so_id=tr_so.so_id
	inner join mt_customer on tr_sdelivery.c_id=mt_customer.c_id
	inner join (select sys_dropdown_id, sys_dropdown_val as sdelivery_status_val from sys_dropdown where sys_dropdown_whr=''sdelivery_status'')a
	on tr_sdelivery.sdelivery_status=a.sys_dropdown_id
	where tr_sdelivery.AC=0'	
	
	if @sdelivery_id<>0
		set @sql=@sql+' and sdelivery_id='+CONVERT(nvarchar(50),@sdelivery_id)
	if @so_id<>0
		set @sql=@sql+' and tr_sdelivery.so_id='+CONVERT(nvarchar(50),@so_id)
	if @sdelivery_date1 is not null
		BEGIN
		if @sdelivery_date2 is not null
			set @sql=@sql+ ' and sdelivery_date between '''+convert(nvarchar(50),@sdelivery_date1,101)+''' and '''+convert(nvarchar(50),@sdelivery_date2,101)+''''
		else
			set @sql=@sql+ ' and sdelivery_date <='''+convert(nvarchar(50),@sdelivery_date1,101)+''''
		END
	if @sdelivery_no is not null
		set @sql=@sql+' and sdelivery_no like ''%'+@sdelivery_no+'%'''
	if @c_name is not null
		set @sql=@sql+' and mt_customer.c_name like ''%'+@c_name+'%'''
	if @sdelivery_stat is not null
		set @sql=@sql+' and sdelivery_status='''+@sdelivery_stat+''''
	if @is_posted is not null
		set @sql=@sql+' and is_posted='+CONVERT(nvarchar(50),@is_posted)
	if @so_no is not null
		set @sql=@sql+' and tr_so.so_no like ''%'+@so_no+'%'''
	exec(@sql)
END

GO


