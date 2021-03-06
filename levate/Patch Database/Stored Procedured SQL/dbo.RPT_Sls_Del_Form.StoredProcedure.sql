USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Del_Form]    Script Date: 08/15/2014 16:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RPT_Sls_Del_Form] (@sdelivery_no nvarchar(50)=NULL) 
AS
Begin
SELECT 
	--Mengambil data company
		(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name
		, (SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1
		, (SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2
		, (SELECT dbo.sys_company.company_phone1 FROM dbo.sys_company WHERE company_id = 1) AS company_phone1
		, (SELECT dbo.sys_company.company_fax FROM dbo.sys_company WHERE company_id = 1) AS company_fax
		--Mengambil data company
	, sd.so_qty
	, CASE sd.so_dtl_type 
			WHEN 'I' THEN 'Income'  
			WHEN 'S' THEN 'Stock'
			WHEN 'T' THEN 'Text'
			END AS so_dtl_type
	, sdel.sdelivery_date
	, so.ref_no  
	, mc.c_name
	, mc.c_address1
	, mc.c_address2
	, mc.c_phone  
	, sdel.sdelivery_no
	, sdel.sdelivery_date
	, sdel.sdelivery_remarks
	, sdel.CB
	, sdel.MB
	, sdeld.sdelivery_qty
    , sd.so_dtl_description
    , CASE 
		WHEN sk.sku_uom <>'' THEN sk.sku_uom ELSE '-'
		END AS sku_uom
    , loc.location_name
FROM         
	dbo.tr_sdelivery sdel
INNER JOIN
    dbo.tr_sdelivery_dtl sdeld ON sdel.sdelivery_id = sdeld.sdelivery_id 
INNER JOIN
    dbo.tr_so_dtl sd ON sdeld.so_dtl_id = sd.so_dtl_id
LEFT JOIN
    dbo.mt_sku sk ON sd.sku_id = sk.sku_id 
INNER JOIN
    dbo.mt_location loc ON sdeld.location_id = loc.location_id
INNER JOIN
	dbo.tr_so so ON so.so_id = sd.so_id 
INNER JOIN
    dbo.mt_customer mc ON so.c_id = mc.c_id
WHERE 
	sdel.sdelivery_no = @sdelivery_no
END
GO
