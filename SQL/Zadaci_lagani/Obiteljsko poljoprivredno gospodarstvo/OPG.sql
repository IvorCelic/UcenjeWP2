use master;
drop database if exists OPG;
go
create database OPG;
go
use OPG;


create table DJELATNIK (
    Djelatnik_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) not null
);

create table PROIZVOD (
    Proizvod_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Datum_vazenja datetime not null,
    Cijena decimal(18,2) null,
    Djelatnik_ID int references DJELATNIK (Djelatnik_ID) not null
);

create table SIROVINA (
    Sirovina_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null
);

create table PROIZVOD_SIROVINA (
    Proizvod_ID int references PROIZVOD (Proizvod_ID) not null,
    Sirovina_ID int references SIROVINA (Sirovina_ID) not null
);




