use master;
drop database if exists KlubCitatelja;
go
create database KlubCitatelja;
go
use KlubCitatelja;


create table CITATELJ (
    Citatelj_ID int primary key not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    OIB char(11) null,
    Kontakt varchar(20) not null
);

create table POSUDBA (
    Posudba_ID int primary key not null,
    Citatelj_ID int references CITATELJ (Citatelj_ID) not null,
    Razdoblje_od datetime not null,
    Razdoblje_do datetime
);

create table KNJIGA (
    Knjiga_ID int primary key not null,
    Naziv varchar(100),
    Vrsta_knjige varchar(100),
    Posudba_ID int references POSUDBA (Posudba_ID)
);

