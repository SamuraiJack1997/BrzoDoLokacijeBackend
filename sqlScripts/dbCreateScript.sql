CREATE DATABASE DemoDatabase
go

create table [User](
	username varchar(50) primary key,
	password varchar(50)
)
go

create Table Post(
	postId int primary key identity,
	username varchar(50) foreign key references [User](username) not null,
	createdAt Date,
	[desc] varchar(255),
	title varchar(255),
	[image] varchar(255),
	latitude float,
	logitude float,
)
go

