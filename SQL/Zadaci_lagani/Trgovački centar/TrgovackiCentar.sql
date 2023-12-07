use master;
drop database if exists TrgovackiCentar;
go
create database TrgovackiCentar collate Croatian_CI_AS;
go
use TrgovackiCentar;


create table TRGOVINA (
    Trgovina_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Radno_vrijeme varchar(20)
);

create table OSOBA (
    Osoba_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) null,
    Kontakt varchar(30) not null
);

create table SEF (
    Sef_ID int primary key identity (1, 1) not null,
    Osoba_ID int references OSOBA (Osoba_ID) not null,
    Trgovina_ID int references TRGOVINA (Trgovina_ID) not null
);

create table TRGOVINA_OSOBA (
    Trgovina_ID int references TRGOVINA (Trgovina_ID) not null,
    Osoba_ID int references OSOBA (Osoba_ID) not null
);