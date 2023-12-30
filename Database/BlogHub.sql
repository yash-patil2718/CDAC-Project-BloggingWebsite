insert into users values(1,"adi","adi@gmail","adi123");
insert into users values(2,"roy","roy@gmail","roy123");
	
insert into blog_categories values(1,"Sports");
insert into blog_categories values(2,"Job");

insert into blogs (blog_id,title,content,user_id,category_id) values(1,"cricket","i love cricket",1,1);
insert into blogs (blog_id,title,content,user_id,category_id) values(2,"coding","i love coding",2,2);




insert into blogs_category1 (blog_id,title,content,user_id) values(4,"Kabbadi","i love to watch kabbadi matches",1);
insert into blogs_category1 (blog_id,title,content,user_id) values(5,"Football","i love to watch Football matches",1);


insert into blogs_category2 (blog_id,title,content,user_id) values(6,"Sales","we are hiring Students for Sales",2);
insert into blogs_category2 (blog_id,title,content,user_id) values(7,"HR","we are hiring MBA Students for HR",2);


insert into shared_blogs (share_id,user_id,blog_id) values(1,1,1);
insert into shared_blogs (share_id,user_id,blog_id) values(2,2,1);


insert into user_published_blogs (user_id,username,category_id,content) values (1,"adi123",1,"cricket");
insert into user_published_blogs (user_id,username,category_id,content) values (2,"roy",1,"Hockey");

insert into  user_reactions(user_id,blog_id,reaction_type,reaction_text,status) values(1,1,"like","nice blog","approved");
insert into  user_reactions(user_id,blog_id,reaction_type,reaction_text,status) values(2,1,"comment","Worst blog","rejected");

