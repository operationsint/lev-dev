USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Sls_ARAging_Report]    Script Date: 05/03/2017 11:41:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec RPT_Sls_ARAging_Report '2015-06-30','','',''
--exec RPT_Sls_ARAging_Report ''' +@date+''','','',''
ALTER procedure [dbo].[RPT_Sls_ARAging_Report] 
-- Add the parameters for the stored procedure here
	(@date nvarchar(50),
	@CCodeFrom nvarchar(50),
	@CCodeTo nvarchar(50),
	@Currcd nvarchar(5))
AS
Begin
declare 
	@sql0 nvarchar(max)='',
	@sql0b nvarchar(max)='',
	@sql0c nvarchar(max)='',
	@sql1 nvarchar(max)='',
	@sql2 nvarchar(max)='',
	@sql3 nvarchar(max)='',
	@sql4 nvarchar(max)=''
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 
	-- Insert statements for procedure here
SET @sql0 = '
select 
		(SELECT sys_company.company_name FROM sys_company WHERE company_id = 1) AS company_name
		, (SELECT sys_company.company_address1 FROM sys_company WHERE company_id = 1) AS company_address1
		, (SELECT sys_company.company_address2 FROM sys_company WHERE company_id = 1) AS company_address2
		, (SELECT sys_company.company_phone1 FROM sys_company WHERE company_id = 1) AS company_phone1
		, (SELECT sys_company.company_fax FROM sys_company WHERE company_id = 1) AS company_fax,
		 b.c_name,c.curr_code,'
SET @sql0b ='
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-6 and cast(''' +@date+''' as smalldatetime) and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [0 - 7 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-13 and cast(''' +@date+''' as smalldatetime)-7 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(e.sum_of_payment,0)) as [8 - 14 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-20 and cast(''' +@date+''' as smalldatetime)-14 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(f.sum_of_payment,0)) as [15 - 21 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-27 and cast(''' +@date+''' as smalldatetime)-21 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(f.sum_of_payment,0)) as [22 - 28 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-44 and cast(''' +@date+''' as smalldatetime)-28 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(f.sum_of_payment,0)) as [29 - 45 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-59 and cast(''' +@date+''' as smalldatetime)-45 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(f.sum_of_payment,0)) as [46 - 60 Days],'

SET @sql0c='
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-29 and cast(''' +@date+''' as smalldatetime) and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [0 - 30 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-59 and cast(''' +@date+''' as smalldatetime)-30 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(e.sum_of_payment,0)) as [31 - 60 Days],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-89 and cast(''' +@date+''' as smalldatetime)-60 and sinvoice_date <= ''' +@date+''' then sinvoice_total else 0 end) +sum(isnull(f.sum_of_payment,0)) as [61 - 90 Days],
		sum(case when sinvoice_date <= cast(''' +@date+''' as smalldatetime)-90 and sinvoice_date <= ''' +@date+''' then a.sinvoice_total  else 0 end)+ sum(isnull(g.sum_of_payment,0)) as [>90 Days],
		
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-29 and cast(''' +@date+''' as smalldatetime) and sinvoice_date <= ''' +@date+''' then (sinvoice_total*sinvoice_curr_rate) else 0 end)+sum(isnull(d.sum_of_local_payment,0)) as [0 - 30 Days in Local Currency],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-59 and cast(''' +@date+''' as smalldatetime)-30 and sinvoice_date <= ''' +@date+''' then (sinvoice_total*sinvoice_curr_rate) else 0 end) +sum(isnull(e.sum_of_local_payment,0)) as [31 - 60 Days in Local Currency],
		sum(case when sinvoice_date between cast(''' +@date+''' as smalldatetime)-89 and cast(''' +@date+''' as smalldatetime)-60 and sinvoice_date <= ''' +@date+''' then (sinvoice_total*sinvoice_curr_rate) else 0 end)+sum(isnull(f.sum_of_local_payment,0)) as [61 - 90 Days in Local Currency],
		sum(case when sinvoice_date <= cast(''' +@date+''' as smalldatetime)-90 and sinvoice_date <= ''' +@date+''' then (a.sinvoice_total)*sinvoice_curr_rate else 0 end) + sum(isnull(g.sum_of_local_payment,0)) as [>90 Days in Local Currency]
'

SET @sql1 = '
from   
tr_sinvoice a
inner join mt_customer b on a.c_id=b.c_id
inner join mt_curr c on a.curr_id=c.curr_id
left join 
		(
			select tr_spayment_dtl.sinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_spayment_dtl.spayment_dtl_value,0) else isnull(tr_spayment_dtl.spayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_spayment_dtl.local_spayment_dtl_value,0)-isnull(tr_spayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_spayment
			inner join tr_spayment_dtl on tr_spayment.spayment_id=tr_spayment_dtl.spayment_id
			inner join tr_sinvoice on tr_spayment_dtl.sinvoice_id=tr_sinvoice.sinvoice_id
			where tr_spayment.AC=0 and tr_spayment.spayment_date between cast(''' +@date+''' as smalldatetime)-29 and cast(''' +@date+''' as smalldatetime) and tr_spayment.spayment_date <= ''' +@date+'''
			group by tr_spayment_dtl.sinvoice_id
		)D on a.sinvoice_id=D.sinvoice_id
left join
		(
			select tr_spayment_dtl.sinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_spayment_dtl.spayment_dtl_value,0) else isnull(tr_spayment_dtl.spayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_spayment_dtl.local_spayment_dtl_value,0)-isnull(tr_spayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_spayment
			inner join tr_spayment_dtl on tr_spayment.spayment_id=tr_spayment_dtl.spayment_id
			inner join tr_sinvoice on tr_spayment_dtl.sinvoice_id=tr_sinvoice.sinvoice_id
			where tr_spayment.AC=0 and tr_spayment.spayment_date between cast(''' +@date+''' as smalldatetime)-60 and cast(''' +@date+''' as smalldatetime)-31 and tr_spayment.spayment_date <= ''' +@date+'''
			group by tr_spayment_dtl.sinvoice_id
		)E on a.sinvoice_id=E.sinvoice_id
'

SET @sql2 = '
 left join
		(
			select tr_spayment_dtl.sinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_spayment_dtl.spayment_dtl_value,0) else isnull(tr_spayment_dtl.spayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_spayment_dtl.local_spayment_dtl_value,0)-isnull(tr_spayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_spayment
			inner join tr_spayment_dtl on tr_spayment.spayment_id=tr_spayment_dtl.spayment_id
			inner join tr_sinvoice on tr_spayment_dtl.sinvoice_id=tr_sinvoice.sinvoice_id
			where tr_spayment.AC=0 and tr_spayment.spayment_date between cast(''' +@date+''' as smalldatetime)-90 and cast(''' +@date+''' as smalldatetime)-61 and tr_spayment.spayment_date <= ''' +@date+'''
			group by tr_spayment_dtl.sinvoice_id
		)F on a.sinvoice_id=F.sinvoice_id
left join
		(
			select tr_spayment_dtl.sinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_spayment_dtl.spayment_dtl_value,0) else isnull(tr_spayment_dtl.spayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_spayment_dtl.local_spayment_dtl_value,0)-isnull(tr_spayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_spayment
			inner join tr_spayment_dtl on tr_spayment.spayment_id=tr_spayment_dtl.spayment_id
			inner join tr_sinvoice on tr_spayment_dtl.sinvoice_id=tr_sinvoice.sinvoice_id
			where tr_spayment.AC=0 and tr_spayment.spayment_date <= cast(''' +@date+''' as smalldatetime)-91 and sinvoice_date <= ''' +@date+'''
			group by tr_spayment_dtl.sinvoice_id
		)G on a.sinvoice_id=G.sinvoice_id		
		
where a.AC=0 
'

IF @CCodeFrom <>'' AND @CCodeTo <> ''
	SET @sql3 = @sql3 + ' AND b.c_code BETWEEN ''' +@CCodeFrom+''' AND ''' +@CCodeTo + ''' '
	ELSE
	SET @sql3 = @sql3 + ''

IF  @Currcd <>''
	SET @sql3 = @sql3 + ' AND c.curr_code = ''' +@Currcd + ''' '
	ELSE
	SET @sql3 = @sql3 + ''

SET @sql4 = 'group by  b.c_name, c.curr_code
			order by b.c_name ASC '
	
exec (@sql0+@sql0b+@sql0c+@sql1+@sql2+@sql3+@sql4)
END
