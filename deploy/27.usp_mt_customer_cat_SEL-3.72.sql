
/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_SEL]    Script Date: 03/13/2017 16:27:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_mt_customer_cat_SEL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_mt_customer_cat_SEL]
GO

/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_SEL]    Script Date: 03/13/2017 16:27:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Emmile
-- Create date: 2014/4/24
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_mt_customer_cat_SEL] 
	-- Add the parameters for the stored procedure here
	@customer_cat_id int = 0,
	@customer_cat_name nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @sql nvarchar(200)
set @sql='SELECT * from mt_customer_cat where ac=0'
if @customer_cat_id <> 0 
	set @sql=@sql+' and customer_cat_id='+convert(nvarchar(50), @customer_cat_id)
if @customer_cat_name is not null
	set @sql=@sql+' and customer_cat_name like ''%'+@customer_cat_name+'%'''
exec(@sql)
END

GO


