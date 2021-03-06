USE [levate]
GO
/****** Object:  StoredProcedure [dbo].[RPT_Pch_APAging_Report]    Script Date: 05/03/2017 11:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec RPT_Pch_APAging_Report '2017-05-31','','',''
ALTER procedure [dbo].[RPT_Pch_APAging_Report] 
-- Add the parameters for the stored procedure here
	(@date nvarchar(50),
	@SCodeFrom nvarchar(50),
	@SCodeTo nvarchar(50),
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
		 b.s_name,c.curr_code,'

SET @sql0b = '	
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-7 and cast(''' +@date+''' as smalldatetime) and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [0 - 7 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-14 and cast(''' +@date+''' as smalldatetime)-8 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [8 - 14 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-21 and cast(''' +@date+''' as smalldatetime)-15 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [15 - 21 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-28 and cast(''' +@date+''' as smalldatetime)-22 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [22 - 28 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-45 and cast(''' +@date+''' as smalldatetime)-29 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [29 - 45 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-60 and cast(''' +@date+''' as smalldatetime)-46 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [46 - 60 Days],'

SET @sql0c = '			 
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-30 and cast(''' +@date+''' as smalldatetime) and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(d.sum_of_payment,0)) as [0 - 30 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-60 and cast(''' +@date+''' as smalldatetime)-31 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(e.sum_of_payment,0)) as [31 - 60 Days],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-90 and cast(''' +@date+''' as smalldatetime)-61 and pinvoice_date <= ''' +@date+''' then pinvoice_total else 0 end) +sum(isnull(f.sum_of_payment,0)) as [61 - 90 Days],
		sum(case when pinvoice_date <= cast(''' +@date+''' as smalldatetime)-91 and pinvoice_date <= ''' +@date+''' then a.pinvoice_total  else 0 end)+ sum(isnull(g.sum_of_payment,0)) as [>90 Days],

		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-30 and cast(''' +@date+''' as smalldatetime) and pinvoice_date <= ''' +@date+''' then (pinvoice_total*pinvoice_curr_rate) else 0 end)+sum(isnull(d.sum_of_local_payment,0)) as [0 - 30 Days in Local Currency],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-60 and cast(''' +@date+''' as smalldatetime)-31 and pinvoice_date <= ''' +@date+''' then (pinvoice_total*pinvoice_curr_rate) else 0 end) +sum(isnull(e.sum_of_local_payment,0)) as [31 - 60 Days in Local Currency],
		sum(case when pinvoice_date between cast(''' +@date+''' as smalldatetime)-90 and cast(''' +@date+''' as smalldatetime)-61 and pinvoice_date <= ''' +@date+''' then (pinvoice_total*pinvoice_curr_rate) else 0 end)+sum(isnull(f.sum_of_local_payment,0)) as [61 - 90 Days in Local Currency],
		sum(case when pinvoice_date <= cast(''' +@date+''' as smalldatetime)-91 and pinvoice_date <= ''' +@date+''' then (a.pinvoice_total)*pinvoice_curr_rate else 0 end) + sum(isnull(g.sum_of_local_payment,0)) as [>90 Days in Local Currency]
'
SET @sql1 = '
from   
tr_pinvoice a
inner join mt_supplier b on a.s_id=b.s_id
inner join mt_curr c on a.curr_id=c.curr_id
left join 
		(
			select tr_ppayment_dtl.pinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_ppayment_dtl.ppayment_dtl_value,0) else isnull(tr_ppayment_dtl.ppayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_ppayment_dtl.local_ppayment_dtl_value,0)+isnull(tr_ppayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_ppayment
			inner join tr_ppayment_dtl on tr_ppayment.ppayment_id=tr_ppayment_dtl.ppayment_id
			inner join tr_pinvoice on tr_ppayment_dtl.pinvoice_id=tr_pinvoice.pinvoice_id
			where tr_ppayment.AC=0 and tr_pinvoice.pinvoice_date between cast(''' +@date+''' as smalldatetime)-30 and cast(''' +@date+''' as smalldatetime) and tr_pinvoice.pinvoice_date <= ''' +@date+'''
			group by tr_ppayment_dtl.pinvoice_id
		)D on a.pinvoice_id=D.pinvoice_id
left join
		(
			select tr_ppayment_dtl.pinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_ppayment_dtl.ppayment_dtl_value,0) else isnull(tr_ppayment_dtl.ppayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_ppayment_dtl.local_ppayment_dtl_value,0)+isnull(tr_ppayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_ppayment
			inner join tr_ppayment_dtl on tr_ppayment.ppayment_id=tr_ppayment_dtl.ppayment_id
			inner join tr_pinvoice on tr_ppayment_dtl.pinvoice_id=tr_pinvoice.pinvoice_id
			where tr_ppayment.AC=0 and tr_pinvoice.pinvoice_date between cast(''' +@date+''' as smalldatetime)-60 and cast(''' +@date+''' as smalldatetime)-31 and tr_pinvoice.pinvoice_date <= ''' +@date+'''
			group by tr_ppayment_dtl.pinvoice_id
		)E on a.pinvoice_id=E.pinvoice_id
'      
SET @sql2 = '
left join
		(
			select tr_ppayment_dtl.pinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_ppayment_dtl.ppayment_dtl_value,0) else isnull(tr_ppayment_dtl.ppayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_ppayment_dtl.local_ppayment_dtl_value,0)+isnull(tr_ppayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_ppayment
			inner join tr_ppayment_dtl on tr_ppayment.ppayment_id=tr_ppayment_dtl.ppayment_id
			inner join tr_pinvoice on tr_ppayment_dtl.pinvoice_id=tr_pinvoice.pinvoice_id
			where tr_ppayment.AC=0 and tr_pinvoice.pinvoice_date between cast(''' +@date+''' as smalldatetime)-90 and cast(''' +@date+''' as smalldatetime)-61 and tr_pinvoice.pinvoice_date <= ''' +@date+'''
			group by tr_ppayment_dtl.pinvoice_id
		)F on a.pinvoice_id=F.pinvoice_id
left join
		(
			select tr_ppayment_dtl.pinvoice_id,
			-1*SUM(case when is_payment_base_curr=0 then isnull(tr_ppayment_dtl.ppayment_dtl_value,0) else isnull(tr_ppayment_dtl.ppayment_conversion_value,0) end) as sum_of_payment,
			-1*SUM(isnull(tr_ppayment_dtl.local_ppayment_dtl_value,0)+isnull(tr_ppayment_dtl.curr_gainloss_value,0)) as sum_of_local_payment
			from tr_ppayment
			inner join tr_ppayment_dtl on tr_ppayment.ppayment_id=tr_ppayment_dtl.ppayment_id
			inner join tr_pinvoice on tr_ppayment_dtl.pinvoice_id=tr_pinvoice.pinvoice_id
			where tr_ppayment.AC=0 and tr_pinvoice.pinvoice_date <= cast(''' +@date+''' as smalldatetime)-91 and tr_pinvoice.pinvoice_date <= ''' +@date+'''
			group by tr_ppayment_dtl.pinvoice_id
		)G on a.pinvoice_id=G.pinvoice_id		
		
where a.AC=0 
'

IF @SCodeFrom <>'' AND @SCodeTo <> ''
	SET @sql3 = @sql3 + ' AND b.s_code BETWEEN ''' +@SCodeFrom+''' AND ''' +@SCodeTo + ''' '
	ELSE
	SET @sql3 = @sql3 + ''

IF  @Currcd <>''
	SET @sql3 = @sql3 + ' AND c.curr_code = ''' +@Currcd + ''' '
	ELSE
	SET @sql3 = @sql3 + ''

SET @sql4 = 'group by  b.s_name, c.curr_code
			order by b.s_name ASC '
	
exec (@sql0+@sql0b+@sql0c+@sql1+@sql2+@sql3+@sql4)
END


--exec RPT_Pch_APAging_Report '2017-05-31','','',''