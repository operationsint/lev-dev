USE [levate]
GO

/****** Object:  StoredProcedure [dbo].[sp_pinvoice_select]    Script Date: 07/16/2014 11:45:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_pinvoice_select] (@po_no varchar(30)=NULL)
AS
begin
	select pinvoice_no,pinvoice_date,mc.trx_code,tpo.po_no,ms.s_name,mcr.curr_code,tp.pinvoice_curr_rate,
	CASE tpd.pinvoice_dtl_type 
		WHEN 'E' THEN 'Expense'  
		WHEN 'S' THEN 'Stock'
		WHEN 'T' THEN 'Text'
	END as pinvoice_dtl_type,
	tpr.pr_no,sku.sku_code,tpd.pinvoice_dtl_desc,ml.location_code,tpd.pinvoice_qty,
	CASE WHEN sku.sku_uom<>'' THEN sku.sku_uom ELSE '-' END sku_uom,
	tpd.pinvoice_price,tpd.pinvoice_dtl_gross,tpd.pinvoice_dtl_tax,tpd.pinvoice_dtl_net,tp.pinvoice_remarks
	from tr_pinvoice tp
	left join mt_trx_code mc on mc.trx_code_id=tp.pch_code_id 
	left join tr_po tpo on tpo.po_id=tp.po_id
	left join mt_supplier ms on ms.s_id=tp.s_id
	left join mt_curr mcr on mcr.curr_id=tp.curr_id
	inner join tr_pinvoice_dtl tpd on tpd.pinvoice_id=tp.pinvoice_id
	left join tr_pr_dtl tprd on tprd.pr_dtl_id=tpd.pr_dtl_id
	inner join tr_pr tpr on tpr.pr_id=tprd.pr_id
	inner join mt_sku sku on sku.sku_id=tpd.sku_id
	left join mt_location ml on ml.location_id=tpd.location_id
	where pinvoice_no=@po_no
end
GO


