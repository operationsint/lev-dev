USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Work_Order_Form]    Script Date: 04/06/2017 15:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[RPT_Work_Order_Form] (@wo_no nvarchar(50)=NULL) 
AS
Begin
SELECT
--Mengambil data company
		(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name
		, (SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1
		, (SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2
		, (SELECT dbo.sys_company.company_phone1 FROM dbo.sys_company WHERE company_id = 1) AS company_phone1
		, (SELECT dbo.sys_company.company_fax FROM dbo.sys_company WHERE company_id = 1) AS company_fax,
		--Mengambil data company
a.wo_no,
a.wo_date,
e.delivery_date,
a.so_no,
f.c_code,
f.c_name,
a.sku_code as sku_code_header,
c.sku_name as sku_name_header,
a.location_code as location_code,
c.sku_uom as sku_uom_header,
a.qty_order,
a.qty_produce,
a.qty_outstanding,
a.wo_remarks,
a.info1,
a.info2,
a.info3,
case 
when a.[status]='C' THEN 'Completed'
when a.[status]='P'THEN 'Partial' 
else 'Outstanding 'end as [status],
a.unit_cost,
a.total_cost,
b.sku_code as sku_code_detail,
d.sku_name as sku_name_detail,
b.location_code as location_code_detail,
d.sku_uom as sku_uom_detail,
b.wo_dtl_qty as detail_total_qty,
b.qty_perunit as detail_unit_qty,
b.wo_dtl_cost,
b.wo_total_cost
FROM tr_work_order a
left join tr_work_order_dtl b on a.wo_no = b.wo_no
inner join mt_sku c on a.sku_code = c.sku_code 
left join mt_sku d on b.sku_code = d.sku_code
left join tr_so e on a.so_no = e.so_no
left join mt_customer f on e.c_id = f.c_id
where a.wo_no = @wo_no
END


