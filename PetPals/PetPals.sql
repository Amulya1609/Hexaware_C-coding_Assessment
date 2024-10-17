--Create and Use the Database

create database PetPals3


use PetPals3

--create pets table
create table pets(
petid int primary key,
name nvarchar(50) not null,
age int not null,
breed nvarchar(50) not null,
type nvarchar(50) not null,);

--create donations table
create table donations(
donationid int primary key,
donorname nvarchar(100) not null,
donationtype nvarchar(50) not null,
donationamount decimal(10,2),
donationitem nvarchar(100),
donationdate datetime not null,
);

--create adoptionevents table
create table adoptionevents(
eventid int primary key,
eventname nvarchar(100) not null,
eventdate datetime not null,
location nvarchar(100) not null
);
--create participants table
create table participants(
participantid int primary key,
participantname nvarchar(100) not null,
participanttype nvarchar(50) not null,
eventid int,
foreign key(eventid) references adoptionevents(eventid)
);

--insert sample data into pets
insert into pets(petid,name,age,breed,type)
values(1,'rocky',3,'labrador','dog'),
(2,'molly',2,'stray','cat'),
(3,'bruno',5,'german shepherd','dog');

--insert sample data into donations
insert into donations(donationid,donorname,donationtype,donationamount,donationitem,donationdate)
values(1,'mukesh','cash',150,null,'2024-09-20 10:30:00'),
(2,'mohan','item',null,'dog food','2024-09-21 12:00:00'),
(3,'manan','cash',200,null,'2024-09-22 09:00:00');
--insert sample data into adoptionevents
insert into adoptionevents(eventid,eventname,eventdate,location)
values(1,'adopt a pet','2024-09-25 10:00:00','chennai'),
(2,'pet fest','2024-10-01 09:00:00','bombay'),
(3,'cat fest','2024-11-15 11:00:00','delhi');

--insert sample data into participants
insert into participants(participantid,participantname,participanttype,eventid)
values(1,'happy shelter','shelter',1),
(2,'rohan','adopter',1),
(3,'stray shelter','shelter',2);

