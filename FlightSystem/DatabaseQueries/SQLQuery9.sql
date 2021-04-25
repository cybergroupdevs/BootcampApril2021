create table Usermodel
(Username varchar(30),Password varchar(20))
insert into Usermodel values('Anurag','Anu1212')
insert into Usermodel values('Abhishek','Abhi1234')
select * from Usermodel
drop table Usermodel
CREATE TABLE  Usermodel(
    ID int NOT NULL,
    Username varchar(30),
	Password varchar(20),
    PRIMARY KEY (ID)
);
select * from Usermodel
drop table Usermodel
create table Usermodel
(
Id int IDENTITY(1,1) Primary key,
Username varchar(30),
Password varchar(20)
)
insert into Usermodel values('Anurag','Anu1212')
