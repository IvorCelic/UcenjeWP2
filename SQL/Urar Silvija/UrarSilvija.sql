use master;
drop database if exists UrarSilvija;
go
create database UrarSilvija collate Croatian_CI_AS;
go
use UrarSilvija;


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
    Ime varchar(20) not null,
    Kontakt varchar(20) not null
);

create table SAT (
    Sat_ID int primary key identity (1, 1) not null,
    Marka varchar(30) null,
    Vrijednost decimal(18,2) null,
    Korisnik_ID int references KORISNIK (Korisnik_ID) not null
);

create table POPRAVAK (
    Popravak_ID int primary key identity not null,
    Zaposlenik_ID int references ZAPOSLENIK (Zaposlenik_ID) not null,
    Datum datetime not null
);

create table SAT_POPRAVAK (
    Sat_ID int references SAT (Sat_ID) not null,
    Popravak_ID int references POPRAVAK (Popravak_ID) not null
);