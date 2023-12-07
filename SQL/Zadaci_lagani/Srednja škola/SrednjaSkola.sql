use master;
drop database if exists SrednjaSkola;
go
create database SrednjaSkola collate Croatian_CI_AS;
go
use SrednjaSkola;


create table RAZRED (
    Razred_ID int primary key identity (1, 1) not null,
    Oznaka varchar(5) not null
);

create table UCENIK (
    Ucenik_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) null,
    Razred_ID int references RAZRED (Razred_ID) not null
);

create table PROFESOR (
    Profesor_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) null
);

create table RAZRED_PROFESOR (
    Razred_ID int references RAZRED (Razred_ID) not null,
    Profesor_ID int references PROFESOR (Profesor_ID) not null
);

