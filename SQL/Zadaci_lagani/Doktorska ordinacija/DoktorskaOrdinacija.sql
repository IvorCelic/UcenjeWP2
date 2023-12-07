use master;
drop database if exists DoktorskaOrdinacija;
go
create database DoktorskaOrdinacija collate Croatian_CI_AS;
go
use DoktorskaOrdinacija;


create table DOKTOR (
    Doktor_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table PACIJENT (
    Pacijent_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table MEDICINSKA_SESTRA (
    Medicinska_sestra_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table LIJECENJE (
    Lijecenje_ID int primary key identity (1, 1) not null,
    Doktor_ID int references DOKTOR (Doktor_ID) not null,
    Pacijent_ID int references PACIJENT (Pacijent_ID) not null,
    Medicinska_sestra_ID int references MEDICINSKA_SESTRA (Medicinska_sestra_ID) not null,
);