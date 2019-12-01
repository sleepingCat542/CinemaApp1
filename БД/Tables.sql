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
drop table GENRE_MOVIE;
drop table ACTOR_MOVIE;
drop table MOVIE;
drop table GENRE;
drop table ACTOR;
drop table STUDIO;
drop table COUNTRY;



--Country
create table COUNTRY(
ID nvarchar(10) primary key not null,
NAME nvarchar(70) unique not null);

--Studio					
create table STUDIO(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(20) not null,
COUNTRY_ID nvarchar(10) foreign key references COUNTRY(ID),
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
SURNAME nvarchar(30) not null,
COUNTRY_ID nvarchar(10) foreign key references Country(ID)
--AGE int,
--IMAGE varbinary(max)
);

--Movie
create table MOVIE(
ID uniqueidentifier rowguidcol DEFAULT NEWSEQUENTIALID(),
NAME nvarchar(max) not null,
RELEASE date,
COUNTRY_ID nvarchar(10) foreign key references COUNTRY(ID),
--GENRE_ID int foreign key references GENRE(ID),
RUNNING_TIME int,
STUDIO_ID uniqueidentifier foreign key references STUDIO(ID),
--ACTOR_ID uniqueidentifier foreign key references ACTOR(ID),
PLOT nvarchar(max),
IMAGE varbinary(max),
CONSTRAINT PK_Movie PRIMARY KEY CLUSTERED(ID));

alter table MOVIE ADD TRAILER varbinary(max) NULL

--GENRE AND MOVIE (many-to-many)
CREATE TABLE GENRE_MOVIE (
    GENRE_ID INT NOT NULL,
    MOVIE_ID uniqueidentifier NOT NULL,
    PRIMARY KEY (GENRE_ID, MOVIE_ID),
    CONSTRAINT FK_MOVIE_GENRE FOREIGN KEY (MOVIE_ID) 
        REFERENCES MOVIE (ID) ON DELETE CASCADE,
    CONSTRAINT FK_GENRE FOREIGN KEY (GENRE_ID) 
        REFERENCES GENRE (ID) ON DELETE CASCADE
)

--ACTOR AND MOVIE (many-to-many)
CREATE TABLE ACTOR_MOVIE (
    ACTOR_ID uniqueidentifier NOT NULL,
    MOVIE_ID uniqueidentifier NOT NULL,
    PRIMARY KEY (ACTOR_ID, MOVIE_ID),
    CONSTRAINT FK_MOVIE_ACTOR FOREIGN KEY (MOVIE_ID) 
        REFERENCES MOVIE (ID) ON DELETE CASCADE,
    CONSTRAINT FK_ACTOR FOREIGN KEY (ACTOR_ID) 
        REFERENCES ACTOR (ID) ON DELETE CASCADE
)


--Cinema
create table CINEMA(
ID int primary key IDENTITY(1, 1),
NAME nvarchar(30) not null,
ADDRESS nvarchar(100),
WEBSITE nvarchar(100),
CITY nvarchar(30),
NUMBER_OF_HALLS int,
TIMETABLE nvarchar(200));

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

--Users
create table USERS(
ID uniqueidentifier primary key rowguidcol DEFAULT NEWSEQUENTIALID(),
LOGIN nvarchar(50) not null,
PASSWORD nvarchar(30) not null,
EMAIL nvarchar(50) not null);

--Purchase
create table PURCHASE(
ID int primary key IDENTITY(1, 1),
USER_ID uniqueidentifier foreign key references USERS(ID) not null,
DATE smalldatetime);
ALTER TABLE PURCHASE ADD UNICK_TICKET nvarchar(20);
ALTER TABLE PURCHASE ADD PRICE int null;

--Tickets
create table TICKETS(
ID int primary key IDENTITY(1, 1),
SESSION_ID int foreign key references SESSION(ID),
PURCHASE_ID int foreign key references PURCHASE(ID),
ROW int not null,
SEAT int not null);



