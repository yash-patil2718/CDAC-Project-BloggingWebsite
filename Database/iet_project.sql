/* creating users table*/
create table users (
  user_id int primary key auto_increment,
  username varchar(50) not null,
  email varchar(100) not null,
  password varchar(100) not null
);

/* create table blog_category*/
create table blog_categories (
  category_id int primary key auto_increment,
  name varchar(50) not null
);

/*creating table blog */
CREATE TABLE blogs (
  blog_id int primary key auto_increment,
  title varchar(100) not null,
  content text not null,
  user_id int,
  category_id int,
  created_at timestamp default current_timestamp,
  foreign key (user_id) references users(user_id),
  foreign key (category_id) references blog_categories(category_id)
);

/* creating blog table for category */
create table blogs_category1 (
  blog_id int primary key auto_increment,
  title varchar(100) not null,
  content text not null,
  user_id int,
  created_at timestamp default current_timestamp,
  foreign key (user_id) references users(user_id)
);

/*creating blog table for category 2*/
create table blogs_category2 (
  blog_id int primary key auto_increment,
  title varchar(100) not null,
  content text not null,
  user_id int,
  created_at timestamp default current_timestamp,
  foreign key (user_id) references users(user_id)
);

/* creating table user_recation to store reaction of users */
create table user_reactions (
  reaction_id int primary key auto_increment,
  user_id int,
  blog_id int,
  reaction_type enum('like', 'comment') not null,
  reaction_text text,
  status enum('approved', 'pending', 'rejected') default 'pending',
  created_at timestamp default current_timestamp,
  foreign key (user_id) references users(user_id),
  foreign key (blog_id) references blogs(blog_id)
);

/* create table shared blog*/
create table shared_blogs (
  share_id int primary key auto_increment,
  user_id int,
  blog_id int,
  shared_at timestamp default current_timestamp,
  foreign key (user_id) references users(user_id),
  foreign key (blog_id) references blogs(blog_id)
);

/* create table blog published*/
create table user_published_blogs (
  publish_id int primary key auto_increment,
  user_id int,
  username varchar(50) not null,
  category_id int,
  content text not null,
  created_at timestamp default current_timestamp,
  foreign key (user_id) references users(user_id),
  foreign key (category_id) references blog_categories(category_id)
);

