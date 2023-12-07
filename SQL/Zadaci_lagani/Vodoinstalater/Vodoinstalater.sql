use master;
drop database if exists Vodoinstalater;
go
create database Vodoinstalater collate Croatian_CI_AS;
go
use Vodoinstalater;


create table STRUCNA_SPREMA (
    Strucna_sprema_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null
);

create table ZAPOSLENIK (
    Zaposlenik_ID int primary key identity (1, 1) not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    OIB char(11) not null,
    Kontakt varchar(30) not null,
    Zaposlenik_ss_ID int references STRUCNA_SPREMA (Strucna_sprema_ID) not null
);

create table KVAR (
    Kvar_ID int primary key identity (1, 1) not null,
    Vrsta varchar(50) not null,
);

create table POPRAVAK (
    Popravak_ID int primary key identity not null,
    Zaposlenik_ID int references ZAPOSLENIK (Zaposlenik_ID) not null,
    Datum datetime not null,
    Cijena decimal(18,2) not null
);

create table KVAR_POPRAVAK (
    Kvar_ID int references KVAR (Kvar_ID) not null,
    Popravak_ID int references POPRAVAK (Popravak_ID) not null
);

