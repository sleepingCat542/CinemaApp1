create database Cinema on
(name = 'Cinema', filename = 'E:\Универ\5 сем\MyKP\Cinema.mdf', size = 10 mb)
log on(name = 'Cinema_log', filename = 'E:\Универ\5 сем\MyKP\Cinema_log.ldf', size = 10 mb) 

use Cinema;

drop table TICKETS;
drop table PURCHASE;
drop table USERS;
drop table SESSION;
drop table HALL;
drop table CINEMA;
drop table MOVIE;
drop table GENRE;
drop table ACTOR;
drop table STUDIO;
drop table Director;
drop table COUNTRY;


--Country
create table COUNTRY(
ID varchar(10) primary key not null,
NAME nvarchar(70) unique not null);


--Studio					
create table STUDIO(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(20) not null,
COUNTRY_ID varchar(10) foreign key references COUNTRY(ID),
YEAR_OF_FOUNDATION int,     
IMAGE varbinary(max));


--Genre
create table GENRE(                 
ID int primary key IDENTITY(1, 1),
NAME nvarchar(30) unique not null);

--Actor
create table ACTOR(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(20) not null,
SURNAME nvarchar(20),
COUNTRY_ID varchar(10) foreign key references Country(ID),
AGE int,
IMAGE varbinary(max));
многие ко многим

--Movie
create table MOVIE(
ID uniqueidentifier rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(max) not null,
RELEASE date,
COUNTRY_ID varchar(10) foreign key references COUNTRY(ID),
GENRE_ID int foreign key references GENRE(ID),
RUNNING_TIME int,
STUDIO_ID uniqueidentifier foreign key references STUDIO(ID),
SCREENPLAY nvarchar(50),
COMPOSER nvarchar(50),
ACTOR_ID uniqueidentifier foreign key references ACTOR(ID),
PLOT nvarchar(max),
IMAGE varbinary(max),
CONSTRAINT PK_Movie PRIMARY KEY CLUSTERED(ID));

alter table MOVIE ADD TRAILER varbinary(max) NULL

--Cinema
create table CINEMA(
ID int primary key IDENTITY(1, 1),
NAME nvarchar(30) not null,
ADDRESS nvarchar(max),
WEBSITE nvarchar(max),
REGION nvarchar(30),
NUMBER_OF_HALLS int,
TICKET_OFFICE nvarchar(30));

--Hall
create table HALL(
ID int primary key IDENTITY(1, 1),
NAME NVARCHAR(30),
CINEMA_ID int foreign key references CINEMA(ID),
ROWS int not null,
SEATS int not null);

--Session
create table SESSION(
ID int primary key IDENTITY(1, 1),
MOVIE_ID uniqueidentifier foreign key references MOVIE(ID),
HALL_ID int foreign key references HALL(ID),
DATE date not null,
TIME time(7) not null,
COST int not null,
FREESEATS int);


 --Role




--Users
create table USERS(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
LOGIN nvarchar(50) not null,
PASSWORD nvarchar(max) not null,
EMAIL nvarchar(50) not null);

--Purchase
create table PURCHASE(
ID int primary key IDENTITY(1, 1),
USER_ID uniqueidentifier foreign key references USERS(ID),
DATE smalldatetime);
ALTER TABLE PURCHASE ADD PRICE INT;

--Tickets
create table TICKETS(
ID int primary key IDENTITY(1, 1),
SESSION_ID int foreign key references SESSION(ID),
PURCHASE_ID int foreign key references PURCHASE(ID),
ROW int not null,
SEAT int not null);



delete TICKETS;
delete PURCHASE;
delete USERS;
delete SESSION;
delete HALL;
delete MOVIE;

delete GENRE;
delete ACTOR;
delete STUDIO;
delete COUNTRY;

