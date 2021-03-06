USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Del_Form]    Script Date: 04/06/2017 15:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[RPT_Sls_Del_Form] (@sdelivery_no nvarchar(50)=NULL) 
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
	, a.sdelivery_date
	, f.so_no
	, g.c_code 
	, g.c_name
	, g.c_address1
	, g.c_address2
	, g.c_phone  
	, a.sdelivery_no
	, a.sdelivery_date
	, a.sdelivery_remarks
	, b.sdelivery_qty
	, f.ref_no
	, CASE WHEN c.lot_job_no<>'' THEN c.lot_job_no ELSE '.' END AS lot_job_no
	, CASE 
		WHEN c.sku_id<>'' THEN d.sku_code
		WHEN c.income_id<>'' THEN h.expinc_code
		ELSE 'Text'
		END as sku_code 
    , c.so_dtl_description
    , CASE 
		WHEN d.sku_uom <>'' THEN d.sku_uom ELSE '-'
		END AS sku_uom
    , CASE WHEN e.location_code <>'' THEN e.location_code ELSE '-' END AS location_code
    , a.vehicle_number
    , CASE 
		WHEN c.stockset IS NOT NULL THEN b.sdelivery_qty / ISNULL((select x1.sku_package_qty from mt_sku_package x1 where x1.sku_id1 = c.stockset and sku_id2 = c.sku_id),1)
		ELSE NULL
		END AS stockset_qty
	, CASE 
		WHEN c.stockset IS NOT NULL THEN (select x2.sku_uom from mt_sku x2 where x2.sku_id = c.stockset)
		ELSE NULL
		END AS stockset_uom
FROM         
	dbo.tr_sdelivery a
INNER JOIN
    dbo.tr_sdelivery_dtl b ON a.sdelivery_id = b.sdelivery_id 
INNER JOIN
    dbo.tr_so_dtl c ON b.so_dtl_id = c.so_dtl_id
LEFT JOIN
    dbo.mt_sku d ON c.sku_id = d.sku_id 
LEFT JOIN
    dbo.mt_location e ON b.location_id = e.location_id
INNER JOIN
	dbo.tr_so f ON f.so_id = c.so_id 
INNER JOIN
    dbo.mt_customer g ON f.c_id = g.c_id
LEFT JOIN
	dbo.mt_expinc h ON c.income_id = h.expinc_id
WHERE 
	a.sdelivery_no = @sdelivery_no
END

--exec [RPT_Sls_Del_Form] 'DO1700445'
--select sku_package_qty from mt_sku_package where sku_id1 = and sku_id2 =
--select * from tr_sdelivery_dtl