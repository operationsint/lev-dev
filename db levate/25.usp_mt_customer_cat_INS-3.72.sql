
/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_INS]    Script Date: 03/13/2017 16:26:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_mt_customer_cat_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_mt_customer_cat_INS]
GO


/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_INS]    Script Date: 03/13/2017 16:26:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Emmile
-- Create date: 2014/4/24
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_mt_customer_cat_INS] 
	-- Add the parameters for the stored procedure here
	@customer_cat_code nvarchar(50) = null, 
	@customer_cat_name nvarchar(50) = null,
	@user_name nvarchar(50),
	@customer_cat_id int OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into mt_customer_cat
	(
	customer_cat_code,
	customer_cat_name,
	CO,
	CB,
	MO,
	MB
	)
	values
	(
	@customer_cat_code,
	@customer_cat_name,
	GETDATE(),
	@user_name,
	GETDATE(),
	@user_name
	)
	set @customer_cat_id = SCOPE_IDENTITY()
END

GO


