
-- 0. zad
use master;
go
drop database if exists kol_vj_1;
go
create database kol_vj_1;
go
use kol_vj_1;


create table punac (
    sifra int primary  key identity (1, 1) not null,
    ogrlica int,
    gustoca decimal (14, 9),
    hlace varchar (41) not null
);

create table cura (
    sifra int primary key identity (1, 1) not null,
    novcica decimal (16, 5) not null,
    gustoca decimal (18, 6) not null,
    lipa decimal (18, 6),
    ogrlica int not null,
    bojakose varchar (38),
    suknja varchar(36),
    punac int references punac (sifra)
);

create table svekar (
    sifra int primary key identity (1, 1) not null,
    bojaociju varchar(40) not null,
    prstena int,
    dukserica varchar(41),
    lipa decimal (13, 8),
    eura decimal (12, 7),
    majica varchar (35)
);

create table sestra (
    sifra int primary key identity (1, 1) not null,
    introvertno bit,
    haljina varchar (31) not null,
    maraka decimal (16, 6),
    hlace varchar (46) not null,
    narukvica int not null
);

create table sestra_svekar (
    sifra int primary key identity (1, 1) not null,
    sestra int references sestra (sifra) not null,
    svekar int references svekar (sifra) not null
);

create table zena (
    sifra int primary key identity (1, 1) not null,
    treciputa datetime,
    hlace varchar (46),
    kratkamajica varchar (31) not null,
    jmbag char(11) not null,
    bojaociju varchar (39) not null,
    haljina varchar (44),
    sestra int references sestra (sifra) not null
);

create table muskarac (
    sifra int primary key identity (1, 1) not null,
    bojaociju varchar (50) not null,
    hlace varchar (30),
    modelnaocala varchar (43),
    maraka decimal (14, 5) not null,
    zena int references zena (sifra) not null
);

create table mladic (
    sifra int primary key identity (1, 1) not null,
    suknja varchar (50) not null,
    kuna decimal (16, 8) not null,
    drugiputa datetime,
    asocijalno bit,
    ekstroventno bit not null,
    dukserica varchar (48) not null,
    muskarac int references muskarac (sifra)
);



-- 1 zadatak
insert into svekar (bojaociju) values
	('zelena');

insert into sestra (haljina, hlace, narukvica) values
		('haljaaaaaa', 'kratke rifleeeee', 3);

insert into sestra_svekar values (1, 2);


-- 2. zad
update cura set gustoca=15.77;


-- 3. zad
delete mladic where kuna > 15.78;


-- 4. zad
select kratkamajica from zena where hlace like '%ana%'


-- 5. zad
select a.dukserica, f.asocijalno, e.hlace
from svekar a
inner join sestra_svekar b on b.svekar=a.sifra
inner join sestra c on b.sestra=c.sifra
inner join zena d on d.sestra=c.sifra
inner join muskarac e on e.zena=d.sifra
inner join mladic f on f.muskarac=e.sifra
where d.hlace like 'a%' and c.haljina like '%ba%' order by e.hlace desc;


-- 6. zad
select haljina, maraka
from sestra a
left join sestra_svekar b on b.sestra=a.sifra
where b.sestra is null




