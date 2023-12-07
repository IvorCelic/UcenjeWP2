use master;
go
drop database if exists Odvjetnik;
create database Odvjetnik;
go
use Odvjetnik;


create table ODVJETNIK (
    Odvjetnik_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table KLIJENT (
    Klijent_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table SURADNIK (
    Suradnik_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table OBRANA (
    Obrana_ID int primary key identity (1, 1) not null,
    Kazneno_djelo varchar(100) not null,
    Datum datetime null,
    Odluka bit null,
    Odvjetnik_ID int references ODVJETNIK (Odvjetnik_ID) not null,
    Klijent_ID int references KLIJENT (Klijent_ID) not null
);

create table SURADNIK_OBRANA (
    Suradnik_ID int references SURADNIK (Suradnik_ID) not null,
    Obrana_ID int references OBRANA (Obrana_ID) not null
);