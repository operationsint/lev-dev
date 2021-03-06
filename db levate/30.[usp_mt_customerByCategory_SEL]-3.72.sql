
/****** Object:  StoredProcedure [dbo].[usp_mt_customerByCategory_SEL]    Script Date: 03/13/2017 16:29:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Emmile
-- Create date: 9/27/2013
-- Description:	Select customer category
-- =============================================
ALTER PROCEDURE [dbo].[usp_mt_customerByCategory_SEL] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT customer_cat_code from mt_customer_cat
	where AC=0
	order by customer_cat_code
END
