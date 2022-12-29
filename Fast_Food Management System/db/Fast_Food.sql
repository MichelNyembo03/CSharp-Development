CREATE DATABASE Fast_Food
GO

USE Fast_Food
CREATE TABLE Product
(
   id int primary key identity(1,1) not null,
   prodName varchar(25) not null,
   typeOfProd varchar(25) not null,
   price decimal(5,2) not null,
   image image not null
);
GO

CREATE TABLE Product_Order
(
   id int primary key identity(1,1) not null,
   ProductName varchar(50) not null,
   prodQuantity int not null,
   totPrice DECIMAL(5,2) not null,
)

use Fast_Food
create table Admin
(
   id int primary key identity(1,1) not null,
   adminName varchar(25) unique not null,
   adminPassword varchar(10) not null,
)
create table Users
(
   id int primary key identity(1,1) not null,
   userName varchar(25) unique not null,
   userpassword varchar(10) not null,
)


use Fast_Food
insert into Users(userName,userpassword)
values('User','user'),
      ('Admin','user')

use Fast_Food
insert into Admin(adminName,adminPassword)
values('Admin','admin')

use Fast_Food
select * from Product_Order

use Fast_Food
select * from Product

use Fast_Food
select * from Users

use Fast_Food
drop table Users