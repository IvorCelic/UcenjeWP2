use master;
go
drop database if exists Samouprava;
create database Samouprava;
go
use Samouprava;


create table ZUPAN (
    Zupan_ID int primary key identity (1, 1) not null,
    Ime varchar(20) not null,
    Prezime varchar(20) not null
);

create table ZUPANIJA (
    Zupanija_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Zupan_ID int references ZUPAN (Zupan_ID) not null
);

create table OPCINA (
    Opcina_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Zupanija_ID int references ZUPANIJA (Zupanija_ID) not null
);

create table MJESTO (
    Mjesto_ID int primary key identity (1, 1) not null,
    Naziv varchar(50) not null,
    Opcina_ID int references OPCINA (Opcina_ID) not null
);


----------------------- inserti vrijednosti -----------------------


insert into ZUPAN (Ime, Prezime) values ('Ivan', 'Anušić');
insert into ZUPAN (Ime, Prezime) values ('Stjepan', 'Kožić');
insert into ZUPAN (Ime, Prezime) values ('Božo', 'Galić');   

insert into ZUPANIJA (Naziv, Zupan_ID) values ('Osječko-baranjska županija', 1);
insert into ZUPANIJA (Naziv, Zupan_ID) values ('Zagrebačka županija', 2);
insert into ZUPANIJA (Naziv, Zupan_ID) values ('Vukovarsko-srijemska županija', 3);

insert into OPCINA (Naziv, Zupanija_ID) values ('Darda', 1);
insert into OPCINA (Naziv, Zupanija_ID) values ('Antunovac', 1);
insert into OPCINA (Naziv, Zupanija_ID) values ('Bistra', 2);
insert into OPCINA (Naziv, Zupanija_ID) values ('Dubrava', 2);
insert into OPCINA (Naziv, Zupanija_ID) values ('Borovo', 3);
insert into OPCINA (Naziv, Zupanija_ID) values ('Gunja', 3);

insert into MJESTO (Naziv, Opcina_ID) values ('Antunovac', 1);
insert into MJESTO (Naziv, Opcina_ID) values ('Ivanovac', 1);
insert into MJESTO (Naziv, Opcina_ID) values ('Darda', 2);
insert into MJESTO (Naziv, Opcina_ID) values ('Mece', 2);
insert into MJESTO (Naziv, Opcina_ID) values ('Gornja Bistra', 3);
insert into MJESTO (Naziv, Opcina_ID) values ('Donja Bistra', 3);
insert into MJESTO (Naziv, Opcina_ID) values ('Bukovje Bistransko', 3);
insert into MJESTO (Naziv, Opcina_ID) values ('Bačinec', 4);
insert into MJESTO (Naziv, Opcina_ID) values ('Brezje', 4);
insert into MJESTO (Naziv, Opcina_ID) values ('Dubrava', 4);
insert into MJESTO (Naziv, Opcina_ID) values ('Borovo', 5);
insert into MJESTO (Naziv, Opcina_ID) values ('Gunja', 6);


----------------------- select sa inner join -----------------------


select a.Zupanija_ID, a.Naziv, concat(b.Prezime, ' ', b.Ime) As 'Župan' from ZUPANIJA a
inner join ZUPAN b on a.Zupan_ID=b.Zupan_ID

select a.Opcina_ID, a.Naziv, b.Naziv As 'Županija' from OPCINA a
inner join ZUPANIJA b on a.Zupanija_ID=b.Zupanija_ID

select a.Mjesto_ID, a.Naziv, b.Naziv as 'Općina' from MJESTO a
inner join OPCINA b on a.Opcina_ID=b.Opcina_ID

select a.Naziv As 'Mjesto', b.Naziv As 'Općina', c.Naziv As 'Županija', concat(d.Prezime, ' ', d.Ime) As 'Župan' from MJESTO a
inner join OPCINA b on a.Opcina_ID=b.Opcina_ID
inner join ZUPANIJA c on b.Zupanija_ID=c.Zupanija_ID
inner join ZUPAN d on c.Zupan_ID=d.Zupan_ID