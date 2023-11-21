use master;
go
drop database if exists Samostan;
create database Samostan;
go
use Samostan;


create table SVECENIK (
    Svecenik_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    Titula varchar(20) null,
    Nadredeni_svecenik int references SVECENIK (Svecenik_ID) not null
);

create table POSAO (
    Posao_ID int primary key identity (1, 1) not null,
    Naziv varchar(30) not null,
    Opis varchar(100) null
);

create table SVECENIK_POSAO (
    Svecenik_ID int references SVECENIK (Svecenik_ID) not null,
    Posao_ID int references POSAO (Posao_ID) not null
);