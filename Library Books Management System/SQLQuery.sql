create database LibraryBooksDB;
use LibraryBooksDB;

create table books(
BookId int identity(1,1) primary key,
BookName varchar(255),
BookAuthor varchar(255),
BookCost int,
BookIssued int,
BookAvailable int);

create table login(
userID int primary key,
password varchar(255) not null);

insert into login
values(1,'bhanuja');
insert into login
values(2,'sonali');
insert into login
values(3,'rakshan');