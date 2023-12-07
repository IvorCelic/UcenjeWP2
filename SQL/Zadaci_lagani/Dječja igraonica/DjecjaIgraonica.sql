use master;
drop database if exists DjecjaIgraonica;
go
create database DjecjaIgraonica collate Croatian_CI_AS;
go
use DjecjaIgraonica;


create table DIJETE (
    Dijete_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table TETA (
    Teta_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table SKUPINA (
    Skupina_ID int primary key identity (1, 1) not null,
    Oznaka varchar(10) not null,
    Teta_ID int references TETA (Teta_ID) not null
);

create table DIJETE_SKUPINA (
    Dijete_ID int references DIJETE (Dijete_ID) not null,
    Skupina_ID int references SKUPINA (Skupina_ID) not null
);
