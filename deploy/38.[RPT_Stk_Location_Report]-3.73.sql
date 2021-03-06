USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Stk_Location_Report]    Script Date: 05/03/2017 11:41:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[RPT_Stk_Location_Report]
	(@stkCodeFrom nvarchar(50),
	@stkCodeTo nvarchar(50),
	@locationCode nvarchar(50),
	@stkCat nvarchar(50))
AS
BEGIN
declare 
	@sql1 nvarchar(1000),
	@sql2 nvarchar(1000),
	@sql3 nvarchar(1000),
	@sql4 nvarchar(1000),
	@sql5 nvarchar(1000),
	@sql6 nvarchar(1000),
	@sql7 nvarchar(1000),
	@sql8 nvarchar(1000),
	@sql9 nvarchar(1000)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 
	-- Insert statements for procedure here
	
SET @sql1 = '
SELECT
(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name
, (SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1
, (SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2
, (SELECT dbo.sys_company.company_phone1 FROM dbo.sys_company WHERE company_id = 1) AS company_phone1
, (SELECT dbo.sys_company.company_fax FROM dbo.sys_company WHERE company_id = 1) AS company_fax,'
SET @sql2 = '
b.sku_code,
b.sku_name,
d.sku_category,
c.location_code,
c.location_name,
a.sku_qty,
CASE WHEN b.sku_uom <>'''' THEN b.sku_uom ELSE ''-'' END AS sku_uom,
b.avg_cost,
a.sku_qty * b.avg_cost as stock_value '
SET @sql3 = '
FROM mt_sku_location a
INNER JOIN mt_sku b on a.sku_id=b.sku_id
INNER JOIN mt_location c on a.location_id=c.location_id
INNER JOIN mt_sku_cat d ON b.sku_cat_id = d.sku_cat_id
WHERE b.AC=0 AND c.AC=0 '
IF @stkCodeFrom <> '' AND @stkCodeTo <> ''
SET @sql4 = 'AND b.sku_code BETWEEN ''' +@stkCodeFrom + ''' AND ''' +@stkCodeTo + ''' '
ELSE
SET @sql4 = ''
IF @locationCode <> ''
SET @sql5 = 'AND c.location_code = ''' +@locationCode + ''' '
ELSE
SET @sql5 = ''
IF @stkCat <> ''
SET @sql6 = 'AND d.sku_category = ''' +@stkCat + ''' '
ELSE
SET @sql6 = ''

--20160616 daniel s : for rune filter out zero qty
SET @sql7=' AND a.sku_qty<>0 '
SET @sql8='ORDER BY c.location_code ASC, d.sku_category'

exec (@sql1+@sql2+@sql3+@sql4+@sql5+@sql6+@sql7+@sql8)
END
