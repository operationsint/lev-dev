USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Pch_Payment_Form]    Script Date: 08/15/2014 16:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RPT_Pch_Payment_Form] (@ppayment_no nvarchar(50)=NULL) 
AS
BEGIN
SELECT 
	a.ppayment_no
	, a.ppayment_date
	, CASE a.ppayment_method
		WHEN 'C' THEN 'CASH'
		WHEN 'Q' THEN 'CHEQUE'
		WHEN 'G' THEN 'GIRO'
		WHEN 'T' THEN 'TRANSFER'
		END AS ppayment_method
	, a.ppayment_ref_no
	, a.ppayment_remarks
	, a.CB
	, a.MB
	, d.s_name
	, d.s_address1
	, d.s_address2
	, d.s_phone
	, e.curr_code
	, c.pinvoice_no
	, b.outstanding_value
	, b.ppayment_advance_allocation
	, b.ppayment_dtl_value
	
FROM
	dbo.tr_ppayment a
INNER JOIN
	dbo.tr_ppayment_dtl b
ON
	a.ppayment_id = b.ppayment_id
INNER JOIN
	dbo.tr_pinvoice c
ON
	c.pinvoice_id = b.pinvoice_id
INNER JOIN
	dbo.mt_supplier d
ON
	d.s_id = a.s_id
INNER JOIN
	dbo.mt_curr e
ON
	e.curr_id = a.curr_id
WHERE
	a.ppayment_no = @ppayment_no
END
GO
