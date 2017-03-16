USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_po_select]    Script Date: 07/08/2014 10:49:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_po_select] (@po_no varchar(30)=NULL) 
AS
Begin
	SELECT p.po_no,p.po_date,p.pch_code_id,p.delivery_date,p.revise,s.s_name,c.curr_code,p.po_curr_rate,p.payment_terms,
	CASE po_dtl_type 
		WHEN 'E' THEN 'Expense'  
		WHEN 'S' THEN 'Stock'
		WHEN 'T' THEN 'Text'
	END as po_dtl_type,
	CASE WHEN sku_code<>'' THEN sku_code ELSE expinc_code END as sku_code,
	d.po_dtl_description,d.po_qty,
	CASE WHEN sk.sku_uom<>'' THEN sk.sku_uom ELSE '-' END as sku_uom,
	d.po_price,d.po_dtl_gross,d.po_dtl_tax,d.po_dtl_net,p.po_remarks  
	FROM tr_po p
	inner join mt_supplier s on s.s_id=p.s_id
	inner join mt_curr c on c.curr_id=p.curr_id
	inner join tr_po_dtl d on d.po_id=p.po_id 
	left join mt_sku sk on sk.sku_id=d.sku_id
	LEFT JOIN mt_expinc me ON me.expinc_id=d.expense_id
	where p.po_no=@po_no
End
GO


