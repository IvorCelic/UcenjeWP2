use master;
go
drop database if exists FB;
create database FB;
go
use FB;


create table OSOBA (
    Osoba_ID int primary key identity (1, 1) not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    Datum_rodjenja datetime null,
    Email varchar(50) not null,
    Lozinka varchar(60) not null,
    Broj_telefona in null,
    Slika varchar(100) null,
    Administrator bit not null,
    Stanje bit not null,
    Aktivan bit not null,
    UniqueID varchar(255) null
);

create table OBJAVA (
    Objava_ID int primary key identity (1, 1) not null,
    Naslov varchar(50) not null,
    Upis varchar(250) not null,
    Vrijeme_izrade datetime not null,
    IP_adresa varchar(20) null,
    Osoba_ID int references OSOBA (Osoba_ID) null
);

create table SVIDA_MI_SE (
    Svida_mi_se_ID int primary key identity (1, 1) not null,
    Vrijeme_svidanja datetime not null,
    Objava_ID int references OBJAVA (Objava_ID) null,
    Osoba_ID int references OSOBA (Osoba_ID) null
);

create table KOMENTAR (
    Komentar_ID int primary key identity (1, 1) not null,
    Vrijeme_komentiranja datetime not null,
    Opis varchar(250) null,
    Objava_ID int references OBJAVA (Objava_ID) null,
    Osoba_ID int references OSOBA (Osoba_ID) null
);

create table SVIDA_MI_SE_KOMENTAR (
    Svida_mi_se_komentar_ID int primary key identity (1, 1) not null,
    Osoba_ID int references OSOBA (Osoba_ID) null,
    Komentar_ID int references KOMENTAR (Komentar_ID) null
);