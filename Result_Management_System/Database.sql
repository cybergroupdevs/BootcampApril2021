create schema StudDB;
use StudDB;
Create table loginInfo(firstname varchar(50),lastname varchar(50),email varchar(50) primary key,password varchar(50));
SELECT * FROM loginInfo;
Insert into loginInfo values('Saksham','Grover','sakshamgrover@gmail.com','saksham123');
create table StudInfo(Id int primary key,Name varchar(50),English int,Hindi int,Spansih int,Mathematics int,Science int);