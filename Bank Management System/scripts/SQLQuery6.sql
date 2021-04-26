create table BankInfo(
Id int IDENTITY(1,1) primary key,
AccountNumber int,
AccountHolderName varchar(55),
Age int,
Address varchar(255),
IfscCode int,
Amount int,
)

Insert into BankInfo values(98765,'Arpit Sharma',20,'Lane no. 17,MZN',123456,20000);
Insert into BankInfo values(98766,'Kapil Dev',40,'Rajpura,Punjab',234567,400000);
select * from BankInfo;