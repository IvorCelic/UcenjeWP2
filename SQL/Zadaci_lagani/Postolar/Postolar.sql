use master;
drop database if exists Postolar;
go
create database Postolar collate Croatian_CI_AS;
go
use Postolar;


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

create table KORISNIK (
    Korisnik_ID int primary key identity (1, 1) not null,
    Prezime varchar(50) not null,
    Kontakt varchar(30) not null
);

create table OBUCA (
    Obuca_ID int primary key identity (1, 1) not null,
    Vrsta varchar(50) not null,
    Korisnik_ID int references KORISNIK (Korisnik_ID) not null,
    Broj_popravaka int not null
);

create table POPRAVAK (
    Popravak_ID int primary key identity not null,
    Zaposlenik_ID int references ZAPOSLENIK (Zaposlenik_ID) not null,
    Datum datetime not null
);

create table OBUCA_POPRAVAK (
    Obuca_ID int references OBUCA (Obuca_ID) not null,
    Popravak_ID int references POPRAVAK (Popravak_ID) not null
);



