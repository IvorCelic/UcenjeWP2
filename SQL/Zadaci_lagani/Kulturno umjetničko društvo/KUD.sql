use master;
drop database if exists KUD;
go
create database KUD collate Croatian_CI_AS;
go
use KUD;

create table CLAN (
    Clan_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table MJESTO (
    Mjesto_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null
);

create table NASTUP (
    Nastup_ID int primary key identity (1, 1) not null,
    Datum datetime null,
    Mjesto_ID int references MJESTO (Mjesto_ID) not null
);

create table CLAN_NASTUP (
    Clan_ID int references CLAN (Clan_ID) not null,
    Nastup_ID int references NASTUP (Nastup_ID) not null
);
