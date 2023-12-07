use master;
drop database if exists SalonZaUljepsavanje;
go
create database SalonZaUljepsavanje collate Croatian_CI_AS;
go
use SalonZaUljepsavanje;


create table DJELATNIK (
    Djelatnik_ID int primary key identity (1, 1) not null,
    Ime varchar(30) not null,
    Prezime varchar(30) not null
);

create table KORISNIK (
    Korisnik_ID int primary key identity (1, 1) not null,
    Ime varchar(30) not null,
    Kontakt varchar(30) null,
    Spol bit not null
);

create table USLUGA (
    Usluga_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Cijena decimal(18,2) not null,
    Trajanje int null
);

create table POSJETA (
    Posjeta_ID int primary key identity (1, 1) not null,
    Datum datetime not null,
    Djelatnik_ID int references DJELATNIK (Djelatnik_ID) not null,
    Korisnik_ID int references KORISNIK (Korisnik_ID) not null,
    Usluga_ID int references USLUGA (Usluga_ID) not null
);