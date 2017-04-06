
/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_DEL]    Script Date: 03/13/2017 16:26:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_mt_customer_cat_DEL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_mt_customer_cat_DEL]
GO

/****** Object:  StoredProcedure [dbo].[usp_mt_customer_cat_DEL]    Script Date: 03/13/2017 16:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Emmile
-- Create date: 2014/4/24
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_mt_customer_cat_DEL] 
	-- Add the parameters for the stored procedure here
	@customer_cat_id int = 0, 
	@user_name nvarchar(50) = null,
	@row_count int OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
			update mt_customer_cat set 
			AC=1,
			MO=getdate(),
			MB=@user_name
			where customer_cat_id=@customer_cat_id;
			
END

GO


