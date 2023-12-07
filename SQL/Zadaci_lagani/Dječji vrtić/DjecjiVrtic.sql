use master;
drop database if exists DjecjiVrtic;
go
create database DjecjiVrtic;
go
use DjecjiVrtic;

create table STRUCNA_SPREMA (
    Strucna_sprema_ID int primary key not null,
    Naziv varchar(50) not null
);

create table ODGAJATELJ (
    Odgajatelj_ID int primary key not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    OIB char(11) not null,
    Strucna_sprema int references STRUCNA_SPREMA (Strucna_sprema_ID) not null,
);

create table ODGOJNA_SKUPINA (
    Odgojna_skupina_ID int primary key not null,
    Naziv varchar(50) not null,
    Odgajatelj_ID int references ODGAJATELJ (Odgajatelj_ID) not null,
    Dob int not null
);

create table DIJETE (
    Dijete_ID int primary key not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    Dob int not null,
    OIB char(11) not null,
    Odgojna_skupina_ID int references ODGOJNA_SKUPINA (Odgojna_skupina_ID) not null
);