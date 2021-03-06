USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Invoice_Form]    Script Date: 08/15/2014 16:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RPT_Sls_Invoice_Form] (@sinvoice_no nvarchar(50)=NULL) 
AS
Begin
select 
	--Mengambil data company
		(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name
		, (SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1
		, (SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2
		, (SELECT dbo.sys_company.company_phone1 FROM dbo.sys_company WHERE company_id = 1) AS company_phone1
		, (SELECT dbo.sys_company.company_fax FROM dbo.sys_company WHERE company_id = 1) AS company_fax
		--Mengambil data company
	, a.sinvoice_tax	
	, d.sdelivery_no
	, e.curr_code
	, f.c_name
	, f.c_address1
	, f.c_address2
	, f.c_phone
	, CASE 
		WHEN g.sku_uom <>'' THEN g.sku_uom ELSE '-'
		END AS sku_uom
	, a.sinvoice_no 
	, a.sinvoice_date
	, a.sinvoice_remarks
	, a.sinvoice_subtotal
	, a.sinvoice_tax
	, a.sinvoice_total
	, CASE b.sinvoice_dtl_type 
			WHEN 'I' THEN 'Income'  
			WHEN 'S' THEN 'Stock'
			WHEN 'T' THEN 'Text'
		END AS sinvoice_dtl_type
	, b.sinvoice_dtl_desc
	, b.sinvoice_qty
	, b.sinvoice_price
	, b.sinvoice_dtl_discpercent * 100 AS sinvoice_dtl_discpercent
	, b.sinvoice_dtl_discamount 
	, b.sinvoice_dtl_subtotal
FROM
	dbo.tr_sinvoice a
INNER JOIN dbo.tr_sinvoice_dtl b 
	ON a.sinvoice_id = b.sinvoice_id
INNER JOIN dbo.tr_sdelivery_dtl c
	ON b.sdelivery_dtl_id = c.sdelivery_dtl_id
INNER JOIN dbo.tr_sdelivery d
	ON c.sdelivery_id = d.sdelivery_id
INNER JOIN dbo.mt_curr e
	ON a.curr_id = e.curr_id
INNER JOIN dbo.mt_customer f
	ON a.c_id = f.c_id
LEFT JOIN dbo.mt_sku g
	ON b.sku_id = g.sku_id
WHERE a.sinvoice_no = @sinvoice_no
END

--select * from tr_sinvoice
GO
