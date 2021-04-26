alter procedure Persons
@Id int,
@fname varchar
AS BEGIN Select * from Persons where Id=@Id and fName=@fName 
END;

INSERT INTO dbo.student(Id, fname,rollNo)
VALUES (1, 'K' , 123);
execute selectAll 1,'k'

execute selectAll 3, 'gyan'

alter procedure selectAll
(
@ID int,
@FName varchar(100)
)as
begin 
select * from test_one where Id-@ID and FName=

CREATE TABLE students(
ID int,
Lname varchar(255),
FName varchar(255),
Address varchar(255),
);