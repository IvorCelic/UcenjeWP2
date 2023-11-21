use master;
drop database if exists Muzej;
go
create database Muzej;
go
use Muzej;


create table SPONZOR (
    Sponzor_ID int primary key not null,
    Naziv varchar(100) not null,
    OIB char(11) null
);

create table IZLOZBA (
    Izlozba_ID int primary key not null,
    Naziv varchar(100) not null,
    Datum_od datetime,
    Datum_do datetime,
    Sponzor_ID int references SPONZOR (Sponzor_ID) not null
);


create table KUSTOS (
    Kustos_ID int primary key not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    OIB char(11) null,
    Izlozba_ID int references IZLOZBA (Izlozba_ID) not null
);

create table DJELO (
    Djelo_ID int primary key not null,
    Naziv varchar(100) not null,
    Procjenjena_vrijednost decimal (18,2),
    Izlozba_ID int references IZLOZBA (Izlozba_ID)
);

