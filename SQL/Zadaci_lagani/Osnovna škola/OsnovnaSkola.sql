use master;
drop database if exists OsnovnaSkola;
go
create database OsnovnaSkola collate Croatian_CI_AS;
go
use OsnovnaSkola;


create table UCITELJICA (
    Uciteljica_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table DIJETE (
    Dijete_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
);

create table RADIONICA (
    Radionica_ID int primary key identity (1, 1) not null,
    Naziv varchar(20) not null,
    Uciteljica_ID int references UCITELJICA (Uciteljica_ID) not null
);

create table DIJETE_RADIONICA (
    Dijete_ID int references DIJETE (Dijete_ID) not null,
    Radionica_ID int references RADIONICA (Radionica_ID) not null
);
