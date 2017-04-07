use levate
declare @form_name nvarchar(50), @sequence int
set @form_name='frmStockAdjPostList'
set @sequence = (select MAX(seq) from mt_form) + 1


insert into mt_form (form_name,form_description,seq)
values (@form_name,'Stock Adjustment Post List',@sequence)

insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (1,@form_name,1,1,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (2,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (3,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (4,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (5,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (6,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (7,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (8,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
insert into mt_user_access(user_level_id,form_name,form_view,form_delete,AC,CO,CB,MO,MB)
values (9,@form_name,0,0,0,GETDATE(),'admin',GETDATE(),'admin')
