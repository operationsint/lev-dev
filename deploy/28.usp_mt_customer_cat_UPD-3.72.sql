
/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_UPD]    Script Date: 03/13/2017 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_mt_customer_cat_UPD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_mt_customer_cat_UPD]
GO


/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_UPD]    Script Date: 03/13/2017 16:27:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Emmile
-- Create date: 2014/4/24
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_mt_customer_cat_UPD] 
	-- Add the parameters for the stored procedure here
	@customer_cat_id int,
	@customer_cat_code nvarchar(50) = null, 
	@customer_cat_name nvarchar(50) = null,
	@user_name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	update mt_customer_cat set
	customer_cat_code=@customer_cat_code,
	customer_cat_name=@customer_cat_name,
	MO=GETDATE(),
	MB=@user_name
	where customer_cat_id=@customer_cat_id
END

GO


