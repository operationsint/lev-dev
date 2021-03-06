USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_Order_Report]    Script Date: 03/21/2017 09:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec RPT_Sls_Order_Report '','','2017-01-01','2017-06-01','','','','','','','2017-03-21','2017-03-21'


ALTER procedure [dbo].[RPT_Sls_Order_Report] 
-- Add the parameters for the stored procedure here
	(
	@SOnoFrom nvarchar(50),
	@SOnoTo nvarchar(50),
	@dtpFrom nvarchar(50),
	@dtpTo nvarchar(50),
	@slsCodeFrom nvarchar(50),
	@slsCodeTo nvarchar(50),
	@currCode nvarchar(50),
	@SoStatus nvarchar(5),
	@CustCodeFrom nvarchar(100),
	@CustCodeTo nvarchar(100),
	@ReqDeliveryDateFrom nvarchar(50),
	@ReqDeliveryDateTo nvarchar(50)
	)
AS
Begin
declare 
	@sql1 nvarchar(1000),
	@sql2 nvarchar(1000),
	@sql3 nvarchar(1000),
	@sql4 nvarchar(1000),
	@sql5 nvarchar(1000),
	@sql6 nvarchar(1000),
	@sql7 nvarchar(1000),
	@sql8 nvarchar(1000), 
	@sql9 nvarchar(1000), 
	@sql10 nvarchar(1000),
	@sql11 nvarchar(1000)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 
	-- Insert statements for procedure here
SET @sql1 = 'SELECT
(SELECT dbo.sys_company.company_name FROM dbo.sys_company WHERE company_id = 1) AS company_name,
(SELECT dbo.sys_company.company_address1 FROM dbo.sys_company WHERE company_id = 1) AS company_address1,
(SELECT dbo.sys_company.company_address2 FROM dbo.sys_company WHERE company_id = 1) AS company_address2,
(SELECT dbo.sys_company.company_phone1 FROM dbo.sys_company WHERE company_id = 1) AS company_phone1,
(SELECT dbo.sys_company.company_fax FROM dbo.sys_company WHERE company_id = 1) AS company_fax,'
SET @sql2 = '
e.c_code,
e.c_name,
a.so_no,
a.so_date
, a.so_gross,a.so_discount,a.so_tax,a.so_total,
i.trx_code,
CASE
	WHEN b.sku_id<>'''' THEN g.sku_code
	WHEN b.income_id<>'''' THEN h.expinc_code
	ELSE ''Text''
	END as code,
b.so_dtl_description,
b.so_qty,
f.curr_code,
CASE WHEN b.so_qty <>0 THEN b.so_dtl_net / b.so_qty ELSE 0 END AS so_price,
b.so_dtl_gross,b.so_dtl_discamount, b.so_dtl_tax ,b.so_dtl_net,
d.sdelivery_date,
d.sdelivery_no,
c.sdelivery_qty,
CASE WHEN c.sdelivery_qty is not null THEN b.so_qty  - c.previous_qty - c.sdelivery_qty ELSE b.so_qty END AS outstanding,
a.so_status,
a.ref_no, 
b.lot_job_no,
b.required_delivery_date '
SET @SQL3 = 'FROM tr_so a
INNER JOIN tr_so_dtl b ON a.so_id = b.so_id
LEFT JOIN tr_sdelivery_dtl c ON b.so_dtl_id = c.so_dtl_id
LEFT JOIN tr_sdelivery d ON c.sdelivery_id = d.sdelivery_id
INNER JOIN mt_customer e ON a.c_id = e.c_id
INNER JOIN mt_curr f ON a.curr_id = f.curr_id
LEFT JOIN mt_sku g ON b.sku_id = g.sku_id
LEFT JOIN mt_expinc h ON b.income_id = h.expinc_id
INNER JOIN dbo.mt_trx_code i ON a.sls_code_id = i.trx_code_id
WHERE a.AC = 0 '

IF @dtpFrom <>'' AND @dtpTo <>'' 
	SET @sql4 ='AND a.so_date BETWEEN ''' +@dtpFrom + ''' AND ''' +@dtpTo + ''' '
	ELSE 
	SET @sql4 = '' 
IF @dtpFrom <>'' AND @dtpTo <>'' AND @slsCodeFrom <>'' AND @slsCodeTo <> ''
	SET @sql5 = 'AND i.trx_code BETWEEN ''' +@slsCodeFrom+''' AND ''' +@slsCodeTo + ''' '
	ELSE
	SET @sql5 = ''
IF @dtpFrom <>'' AND @dtpTo <>'' AND @currCode <>''
	SET @sql6 = 'AND f.curr_code = ''' +@currCode + ''' '
	ELSE
	SET @sql6 = ''
IF @SoStatus <>''
	SET @sql7 = 'AND a.so_status = ''' +@SoStatus + ''' '
	ELSE
	SET @sql7 = ''
	
IF @dtpFrom <>'' AND @dtpTo <>'' AND @CustCodeFrom <>'' AND @CustCodeTo <> ''
SET @sql9 = 'AND e.c_code BETWEEN ''' +@CustCodeFrom+''' AND ''' +@CustCodeTo + ''' '
ELSE
SET @sql9 = ''

IF @dtpFrom <>'' AND @dtpTo <>'' AND @SOnoFrom <>'' AND @SOnoTo <> ''
SET @sql10 = 'AND a.So_no BETWEEN ''' +@SOnoFrom+''' AND ''' +@SOnoTo + ''' '
ELSE
SET @sql10 = ''

IF @dtpFrom <>'' AND @dtpTo <>'' AND @ReqDeliveryDateFrom <>'' AND @ReqDeliveryDateTo <> ''
SET @sql11 = 'AND b.required_delivery_date BETWEEN ''' +@ReqDeliveryDateFrom+''' AND ''' +@ReqDeliveryDateTo + ''' '
ELSE
SET @sql11 = ''

exec (@sql1+@sql2+@sql3+@sql4+@sql5+@sql6+@sql7+@sql9+@sql10+@sql11)
END

