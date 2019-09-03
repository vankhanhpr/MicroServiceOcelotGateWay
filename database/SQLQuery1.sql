
create database MainDatabase

create table Users (
	id int not null primary key identity(1,1),
	username nvarchar(20) not null,
	password nvarchar(200),
	email nvarchar(200),
	phone nvarchar(200),
	address nvarchar(3000),
	role int 
)