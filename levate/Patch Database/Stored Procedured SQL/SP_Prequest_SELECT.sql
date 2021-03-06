create procedure sp_prequest_select(@po_no varchar(30)=NULL)
AS
Begin
	SELECT h.prequest_no,h.prequest_date,pch_code_id,h.prequest_delivery_date,h.prequester,
	CASE WHEN sku_code<>'' THEN sku_code ELSE expinc_code END as sku_code, 
	CASE WHEN ms.sku_uom<>'' THEN ms.sku_uom ELSE '-' END as sku_uom,
	d.prequest_dtl_desc,d.prequest_qty,h.prequest_remarks
	FROM tr_prequest h
	INNER JOIN tr_prequest_dtl d ON d.prequest_id=h.prequest_id
	LEFT JOIN mt_sku ms ON ms.sku_id=d.sku_id 
	LEFT JOIN mt_expinc me ON me.expinc_id=d.expense_id
	where prequest_no=@po_no
End