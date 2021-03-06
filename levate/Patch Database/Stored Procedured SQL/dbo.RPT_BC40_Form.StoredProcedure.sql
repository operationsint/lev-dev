USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_BC40_Form]    Script Date: 08/15/2014 16:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RPT_BC40_Form] (@bc_no nvarchar(50)=NULL) 
AS
BEGIN
SELECT 
	--Mengambil data company
		(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name
		, (SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1
		, (SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2
		--Mengambil data company
	, a.bc_date
	, a.bc_contract_no
	, a.bc_contract_date
	, a.bc_sum_price
	, a.bc_sum_pack_qty
	, a.bc_sum_gross_weight
	, a.bc_sum_net_weight
	, CASE a.bc_process_type 
			WHEN 'PJM' THEN 'DIPINJAMKAN'  
			WHEN 'PRO' THEN 'DIPROSES'
			WHEN 'KBL' THEN 'DIKEMBALIKAN'
		END AS bc_process_type
	, b.bc_dtl_price
	, c.c_npwp
	, c.c_name
	, c.c_address1
	, c.c_address2
	, c.c_tpb_no
	, d.sdelivery_qty
	, ROW_NUMBER() OVER(ORDER BY f.sku_code) AS 'No'
	, f.sku_code
	, f.sku_name
	, CASE 
		WHEN f.sku_uom <>'' THEN f.sku_uom ELSE '-'
		END AS sku_uom
	, g.curr_code
FROM
	dbo.tr_bc a
INNER JOIN
	dbo.tr_bc_dtl b
ON 
	a.bc_id = b.bc_id
INNER JOIN 
	dbo.mt_customer c
ON
	c.c_id = a.c_id
INNER JOIN
	dbo.tr_sdelivery_dtl d
ON
	d.sdelivery_dtl_id = b.sdelivery_dtl_id
INNER JOIN
	dbo.tr_so_dtl e
ON
	e.so_dtl_id = d.so_dtl_id
INNER JOIN
	dbo.mt_sku f
ON
	f.sku_id = e.sku_id
INNER JOIN
	dbo.mt_curr g
ON
	g.curr_id = a.curr_id
WHERE
	a.bc_no = @bc_no
END
GO
