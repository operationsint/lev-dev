USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[SP_PO_Incoming_SELECT]    Script Date: 07/16/2014 11:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_PO_Incoming_SELECT] (@pr_no varchar(30)=null) 
as 
Begin
	SELECT pr_no,pr_date,pr_duedate,po_no,ms.s_name,
	CASE pod.po_dtl_type 
			WHEN 'E' THEN 'Expense'  
			WHEN 'S' THEN 'Stock'
			WHEN 'T' THEN 'Text'
	END as po_dtl_type,
	CASE WHEN sku.sku_code<>'' THEN sku.sku_code ELSE me.expinc_code END sku_code,
	pod.po_dtl_description,
	CASE WHEN ml.location_code<>'' THEN ml.location_code ELSE '-' END location_code,
	pr.pr_remarks,pod.po_qty,prd.previous_qty,prd.pr_qty,po_qty-prd.pr_qty as remain_qty,
	CASE WHEN sku.sku_uom<>'' THEN sku.sku_uom ELSE '-' END sku_uom,pr.pr_remarks
	from tr_pr pr
	inner join tr_po po on po.po_id=pr.po_id
	inner join mt_supplier ms on ms.s_id=pr.s_id
	inner join tr_pr_dtl prd on prd.pr_id=pr.pr_id
	inner join tr_po_dtl pod on pod.po_dtl_id=prd.po_dtl_id
	left join mt_sku sku on sku.sku_id=pod.sku_id
	left join mt_expinc me on me.expinc_id=pod.expense_id
	left join mt_location ml on ml.location_id=prd.location_id
	where pr.pr_no=@pr_no
End
GO


