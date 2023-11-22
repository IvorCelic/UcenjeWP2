use master;
drop database if exists FrizerskiSalon;
go
create database FrizerskiSalon;
go
use FrizerskiSalon;


create table DJELATNIK (
    Djelatnik_ID int primary key identity (1, 1) not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    OIB char(11) not null,
    Kontakt varchar(20) not null
);

create table KORISNIK (
    Korisnik_ID int primary key identity (1, 1) not null,
    Ime varchar(50) not null,
    Prezime varchar(50) not null,
    Spol bit not null
);

create table USLUGA (
    Usluga_ID int primary key identity (1, 1) not null,
    Naziv varchar(100) not null,
    Cijena decimal(18,2) not null,
    Trajanje int not null,
);

create table POSJETA (
    Posjeta_ID int primary key identity (1, 1) not null,
    Datum datetime,
    Djelatnik_ID int references DJELATNIK (Djelatnik_ID) not null,
    Korisnik_ID int references KORISNIK (Korisnik_ID) not null,
    Usluga_ID int references USLUGA (Usluga_ID) not null
);



-------------------------------
----------- INSERTI -----------
-------------------------------


insert into DJELATNIK (Ime, Prezime, OIB, Kontakt) values
    ('Branka', 'Pereglin', '95848288731', '+385998429658'),
    ('Marta', 'Andrijanović', '11111111111', '+385988888575');

insert into KORISNIK (Ime, Prezime, Spol) values
    ('Matej', 'Matinić', '1'),
    ('Marijana', 'Malenković', '0'),
    ('Ružica', 'Ručković', '0');

insert into USLUGA (Naziv, Cijena, Trajanje) values
    ('Šišanje mašinicom', 7, 10),
    ('Šišanje mašinicom i škarama', 7.5, 15),
    ('Farbanje', 15, 60),
    ('Muško šišanje i brijanje', 10, 25),
    ('Farbanje, šišanje, feniranje', 20, 80);

insert into POSJETA (Datum, Djelatnik_ID, Korisnik_ID, Usluga_ID) values
    ('2023-04-26 17:00:00', 1, 1, 4),
    ('2023-04-26 17:30:00', 1, 2, 3),
    ('2023-04-26 19:00:00', 1, 3, 5);




select * from POSJETA;


select a.Datum, concat(b.Ime, ' ', b.Prezime) As 'Djelatnik', concat(c.Ime, ' ', c.Prezime) As 'Korisnik', d.Naziv As 'Usluga' from POSJETA a
inner join DJELATNIK b on a.Djelatnik_ID=b.Djelatnik_ID
inner join KORISNIK c on a.Korisnik_ID=c.Korisnik_ID
inner join USLUGA d on a.Usluga_ID=d.Usluga_ID