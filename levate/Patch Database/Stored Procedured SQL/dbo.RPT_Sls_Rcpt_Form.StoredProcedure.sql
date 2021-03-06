USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Rcpt_Form]    Script Date: 08/15/2014 16:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RPT_Sls_Rcpt_Form] (@spayment_no nvarchar(50)=NULL) 
AS
BEGIN
SELECT 
	a.spayment_no
	, a.spayment_date
	, CASE a.spayment_method
		WHEN 'C' THEN 'CASH'
		WHEN 'Q' THEN 'CHEQUE'
		WHEN 'G' THEN 'GIRO'
		WHEN 'T' THEN 'TRANSFER'
		END AS spayment_method
	, a.spayment_ref_no
	, a.spayment_remarks
	, a.CB
	, a.MB
	, a.spayment_total_outstanding
	, a.spayment_total_advance
	, a.spayment_total_paid
	, a.spayment_total_allocation
	, b.outstanding_value
	, b.spayment_advance_allocation
	, b.spayment_dtl_value
	, c.sinvoice_no
	, d.curr_code
	, e.c_name
	, e.c_address1
	, e.c_address2
	, e.c_phone
	 
FROM
	dbo.tr_spayment a
INNER JOIN
	dbo.tr_spayment_dtl b
ON 
	a.spayment_id = b.spayment_id
INNER JOIN
	dbo.tr_sinvoice c
ON
	c.sinvoice_id = b.sinvoice_id
INNER JOIN
	dbo.mt_curr d
ON
	d.curr_id = a.curr_id
INNER JOIN
	dbo.mt_customer e
ON
	e.c_id = a.c_id
WHERE
	a.spayment_no = @spayment_no
END
GO
