use master;
drop database if exists Fakultet;
go
create database Fakultet;
go
use Fakultet;


create table STUDENT (
    Student_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) not null
);

create table PREDAVAC (
    Predavac_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null,
    OIB char(11) not null
);

create table ROK (
    Rok_ID int primary key identity (1, 1) not null,
    Datum_roka datetime null,
    Predavac_ID int references PREDAVAC (Predavac_ID) not null
);

create table KOLEGIJ (
    Kolegij_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Semestar varchar(20) not null,
    Predavac_ID int references PREDAVAC (Predavac_ID) not null
);

create table STUDENT_ROK (
    Student_ID int references STUDENT (Student_ID) not null,
    Rok_ID int references ROK (Rok_ID) not null,
    Kolegij_ID int references KOLEGIJ (Kolegij_ID) not null
);


-------------------------------
----------- INSERTI -----------
-------------------------------

insert into STUDENT (Ime, Prezime, OIB) values ('Ivan', 'Malinić', '58544487134');
insert into STUDENT (Ime, Prezime, OIB) values ('Marko', 'Manuvar', '11111111111');
insert into STUDENT (Ime, Prezime, OIB) values ('Milanica', 'Milaninović', '58544487134');
insert into STUDENT (Ime, Prezime, OIB) values ('Ivan', 'Malinić', '87654398765');

insert into PREDAVAC (Ime, Prezime, OIB) values ('Tomislav', 'Jakopec', '98765432198');
insert into PREDAVAC (Ime, Prezime, OIB) values ('Ivor', 'Ćelić', '09876543219');

insert into ROK (Datum_roka, Predavac_ID) values ('2023-06-15 12:00:00', 1);
insert into ROK (Datum_roka, Predavac_ID) values ('2023-06-20 13:00:00', 2);

insert into KOLEGIJ (Naziv, Semestar, Predavac_ID) values ('C#', 'II. semestar', 1);
insert into KOLEGIJ (Naziv, Semestar, Predavac_ID) values ('Web dizajn', 'I. semestar', 2);

insert into STUDENT_ROK (Student_ID, Rok_ID, Kolegij_ID) values (1, 1, 1);
insert into STUDENT_ROK (Student_ID, Rok_ID, Kolegij_ID) values (2, 1, 1);
insert into STUDENT_ROK (Student_ID, Rok_ID, Kolegij_ID) values (2, 2, 1);
insert into STUDENT_ROK (Student_ID, Rok_ID, Kolegij_ID) values (3, 2, 1);
insert into STUDENT_ROK (Student_ID, Rok_ID, Kolegij_ID) values (1, 1, 2);
insert into STUDENT_ROK (Student_ID, Rok_ID, Kolegij_ID) values (4, 2, 2);


--------------------------------
------------ SELECT ------------
--------------------------------

select concat(b.Prezime, ' ', b.Ime) As 'Student', c.Datum_roka As 'Datum', concat(d.Prezime, ' ', d.Ime) As 'Predavač', e.Naziv from STUDENT_ROK a
inner join STUDENT b on a.Student_ID = b.Student_ID
inner join ROK c on a.Rok_ID = c.Rok_ID
inner join PREDAVAC d on c.Predavac_ID = d.Predavac_ID
inner join KOLEGIJ e on a.Kolegij_ID = e.Kolegij_ID