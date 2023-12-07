use master;
drop database if exists TaksiSluzba;
go
create database TaksiSluzba;
go
use TaksiSluzba;


create table VOZILO (
    Vozilo_ID int primary key identity (1, 1) not null,
    Marka varchar(20) not null,
    Reg_oznaka varchar(20) not null,
);

create table VOZAC (
    Vozac_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) not null,
    Mobitel varchar(20) not null,
    Vozilo_ID int references VOZILO (Vozilo_ID) not null
);

create table VOZNJA (
    Voznja_ID int primary key identity (1, 1) not null,
    Datum datetime not null,
    Kilometraza decimal(18,2) not null,
    Cijena decimal(18,2) not null,
    Vozac_ID int references VOZAC (Vozac_ID) not null,
);

create table PUTNIK (
    Putnik_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    Mobitel varchar(20) not null
);

create table VOZNJA_PUTNIK (
    Voznja_ID int references VOZNJA (Voznja_ID) not null,
    Putnik_ID int references PUTNIK (Putnik_ID) not null
);