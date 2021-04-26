create table BankLoginInfo(
Id int Identity(1,1) primary key,
username varchar (50),
pass varchar (50)
)

Insert Into BankLoginInfo values('arpitsharma01','12345');
select * from BankLoginInfo;