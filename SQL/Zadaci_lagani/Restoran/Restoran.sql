use master;
go
drop database if exists Restoran;
create database Restoran;
go
use Restoran;


create table KATEGORIJA (
    Kategorija_ID int primary key identity (1, 1) not null,
    Naziv varchar(30) not null
);

create table JELO (
    Jelo_ID int primary key identity (1, 1) not null,
    Naziv varchar(30) not null,
    Opis varchar(100) not null,
    Cijena decimal(18, 2) not null,
    Kategorija_ID int references KATEGORIJA (Kategorija_ID) not null
);

create table PICE (
    Pice_ID int primary key identity (1, 1) not null,
    Naziv varchar(30) not null,
    Vrsta varchar(30) not null,
    Alkoholno bit not null
);

create table JELO_PICE (
    Jelo_ID int references JELO (Jelo_ID) not null,
    Pice_ID int references PICE (Pice_ID) not null
);