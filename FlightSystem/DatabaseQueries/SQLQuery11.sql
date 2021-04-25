Create table flightlogin
(
CId int IDENTITY(1,1) primary key,
UserName varchar(100) not null,
Password_ varchar(100) not null,
Email varchar(100) not null
)
drop table flightlogin
Create table flight
(
FId int IDENTITY(1,1) primary key,
FlightName varchar(20) not null,
FlightDeparture varchar(20) not null,
FlightSource varchar(30) not null,
FlightArrival varchar(20) not null,
Flightdestination varchar(30) not null,
FlightCharges int not null,
FlightSeats int not null,
)