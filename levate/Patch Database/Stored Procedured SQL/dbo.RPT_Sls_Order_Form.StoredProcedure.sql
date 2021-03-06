USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Order_Form]    Script Date: 08/15/2014 16:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RPT_Sls_Order_Form] (@so_no nvarchar(50)=NULL) 
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
		 , a.so_no
	     , a.so_date
	     , a.so_remarks
	     , a.ref_no
	     , a.payment_terms
	     , a.CB
	     , a.MB
	     , a.delivery_date
	     , a.sls_code_id
	     , a.so_subtotal
	     , a.so_tax
	     , a.so_total
	     , b.required_delivery_date
	     , CASE b.so_dtl_type 
			WHEN 'I' THEN 'Income'  
			WHEN 'S' THEN 'Stock'
			WHEN 'T' THEN 'Text'
			END AS so_dtl_type
	     , b.so_dtl_description
	     , b.so_qty
	     , b.so_price
	     , b.so_dtl_discpercent * 100 AS so_dtl_discpercent
	     , b.so_dtl_discamount
	     , b.so_dtl_subtotal
	     , c.c_name
	     , c.c_address1
	     , c.c_address2
	     , c.c_phone
	     , d.curr_code
	     , CASE WHEN e.sku_uom <>'' THEN e.sku_uom ELSE '-' END AS sku_uom
	FROM          
		dbo.tr_so a
	INNER JOIN
		dbo.tr_so_dtl b 
		ON 
			a.so_id = b.so_id 
	INNER JOIN
        dbo.mt_customer c 
        ON 
			c.c_id = a.c_id
	INNER JOIN
		dbo.mt_curr d
		ON
			a.curr_id = d.curr_id
	LEFT JOIN
		dbo.mt_sku e
		ON
			e.sku_id = b.sku_id
	WHERE 
		a.so_no = @so_no
End

select * from dbo.sys_company

SELECT * FROM DBO.tr_so
GO
