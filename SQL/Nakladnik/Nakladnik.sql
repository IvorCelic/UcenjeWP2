use master;
drop database if exists Nakladnik;
go
create database Nakladnik collate Croatian_CI_AS;
go
use Nakladnik;


create table MJESTO (
    Mjesto_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null
);

create table NAKLADNIK (
    Nakladnik_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Mjesto_ID int references MJESTO (Mjesto_ID) not null
);

create table DJELO (
    Djelo_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Vrsta_djela varchar(50) not null
);

create table NAKLADNIK_DJELO (
    Nakladnik_ID int references NAKLADNIK (Nakladnik_ID) not null,
    Djelo_ID int references DJELO (Djelo_ID) not null
);

