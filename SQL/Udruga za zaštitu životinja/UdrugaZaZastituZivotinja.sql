use master;
drop database if exists ZastitaZivotinja;
go
create database ZastitaZivotinja collate Croatian_CI_AS
use ZastitaZivotinja;
go


create table OSOBA (
    Osoba_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table ZIVOTINJA (
    Zivotinja_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Vrsta varchar(20) not null,
    Dob int null,
    Osoba_ID int references OSOBA (Osoba_ID) not null
);

create table PROSTOR (
    Prostor_ID int primary key identity (1, 1) not null,
    Broj_prostora int not null,
    Sirina decimal(18,2) null,
    Duzina decimal(18,2) null,
    Zivotinja_ID int references ZIVOTINJA (Zivotinja_ID) not null
);