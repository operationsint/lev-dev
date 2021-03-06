USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Order_Form]    Script Date: 05/03/2017 11:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[RPT_Sls_Order_Form] (@so_no nvarchar(50)=NULL) 
AS
Begin
SELECT 
		--Mengambil data company
		(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name
		, (SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1
		, (SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2
		, (SELECT dbo.sys_company.company_phone1 FROM dbo.sys_company WHERE company_id = 1) AS company_phone1
		, (SELECT dbo.sys_company.company_fax FROM dbo.sys_company WHERE company_id = 1) AS company_fax
		, (SELECT dbo.sys_company.company_bank_info FROM dbo.sys_company WHERE company_id = 1) AS company_bank_info
		--Mengambil data company
		 , a.so_no
	     , a.so_date
	     , a.so_remarks
	     , a.ref_no
	     , a.payment_terms
	     , a.delivery_date
	     , c.c_code
	     , c.c_name
	     , c.c_contact	     
	     , c.c_phone
	     , c.c_fax
	     , f.trx_code
	     , d.curr_code
	     , CASE a.so_status
		WHEN 'I' THEN 'Invoiced'
		WHEN 'P' THEN 'Paid'
		WHEN 'FD' THEN 'Fully Delivered'
		WHEN 'PD' THEN 'Partially Delivered'
		WHEN 'O' THEN 'Outstanding'
		END AS so_status
		, a.so_gross
		, a.so_discount
	     , a.so_subtotal
	     , a.so_tax
	     , a.so_total
	     , b.required_delivery_date
	     , CASE 
		WHEN b.sku_id<>'' THEN e.sku_code
		WHEN b.income_id<>'' THEN i.expinc_code
		ELSE 'Text'
		END as code
	     , b.so_dtl_description
	     , CASE WHEN g.location_code <>'' THEN g.location_code ELSE '-' END AS location_code
	     , b.so_qty
	     , b.so_price
	     , b.so_dtl_discamount
	     , b.so_dtl_gross
	     , CASE WHEN e.sku_uom <>'' THEN e.sku_uom ELSE '-' END AS sku_uom
	     , a.sinvoice_no_ref
	     , a.so_curr_rate
	     , DATEADD(day,a.payment_terms,a.so_date) AS duedate
	     , c.c_address1
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
	INNER JOIN dbo.mt_trx_code f ON a.sls_code_id = f.trx_code_id
	LEFT JOIN dbo.mt_location g ON b.location_id = g.location_id
	LEFT JOIN dbo.mt_expinc i ON b.income_id = i.expinc_id
	WHERE 
		a.so_no = @so_no
End

--exec RPT_Sls_Order_Form 'SO170400419'