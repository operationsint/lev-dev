insert into mt_customer_cat (customer_cat_code,customer_cat_name,AC,CO,CB,MO,MB)
SELECT distinct c_category, c_category, 0, getDate(), 'Admin', getDate(), 'Admin' from mt_customer
