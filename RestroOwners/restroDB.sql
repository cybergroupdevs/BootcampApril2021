create table Restros (
id int not null IDENTITY(1,1) primary key,
rName varchar(255) not null,
rAddress varchar(255) not null,
rPhone int not null,
rType varchar(255) not null
)

create table ownerRestro (
id int not null IDENTITY(1,1) primary key,
oUserName varchar(255) not null,
oEmail varchar(255) not null,
oPassword varchar(255) not null
)
