use master;
go
drop database if exists kol_vj_2;
go
create database kol_vj_2;
go
use kol_vj_2;


-- zad 0
create table brat (
    sifra int primary key identity(1, 1) not null,
    suknja varchar(47),
    ogrlica int not null,
    asocijalno bit not null,
    neprijatelj int not null
);

create table zarucnica (
    sifra int primary key identity(1, 1) not null,
    narukvica int,
    bojakose varchar(37) not null,
    novcica decimal(15, 9),
    lipa decimal(15, 8) not null,
    indiferentno bit not null
);

create table decko (
    sifra int primary key identity(1, 1) not null,
    indiferentno bit,
    vesta varchar(34),
    asocijalno bit not null
);

create table decko_zarucnica (
    sifra int primary key identity (1, 1) not null,
    decko int references decko(sifra) not null,
    zarucnica int references zarucnica (sifra) not null
);

create table cura (
    sifra int primary key identity(1, 1) not null,
    haljina varchar(33) not null,
    drugiputa datetime not null,
    suknja varchar(38),
    narukvica int,
    introvertno bit,
    majica varchar(40),
    decko int references decko(sifra)
);

create table neprijatelj (
    sifra int primary key identity(1, 1) not null,
    majica varchar(32),
    haljina varchar(43) not null,
    lipa decimal(16, 8),
    modelnaocala varchar(49) not null,
    kuna decimal(12, 6) not null,
    jmbag char(11),
    cura int references cura (sifra)
);

create table svekar (
    sifra int primary key identity (1, 1) not null,
    stilfrizura varchar(48),
    ogrlica int not null,
    asocijalno bit not null
);

create table prijatelj (
    sifra int primary key identity (1, 1) not null,
    modelnaocala varchar(37),
    treciputa datetime not null,
    ekstroventno bit not null,
    prviputa datetime,
    svekar int references svekar (sifra) not null
);


--zad 1
insert into neprijatelj (haljina, modelnaocala, kuna) values ('bijela haljina', 'gauge 6', 2.15);
insert into neprijatelj (haljina, modelnaocala, kuna) values ('haljina za vjenčanje', 'gauge 6', 22.133);
insert into neprijatelj (haljina, modelnaocala, kuna) values ('haljina za parti', 'porsche', 42.155);

insert into decko (asocijalno) values (1);
insert into decko (asocijalno) values (0);
insert into decko (asocijalno) values (1);

insert into cura (haljina, drugiputa, majica) values ('plava', '2026-01-01', 'kratka majica');
insert into cura (haljina, drugiputa, majica) values ('smeda', '2022-01-01', 'siva majica');
insert into cura (haljina, drugiputa, majica) values ('crvena', '2021-01-01', 'dugacka majica');

insert into zarucnica (bojakose, lipa, indiferentno) values ('plava', 15.2, 1);
insert into zarucnica (bojakose, lipa, indiferentno) values ('crvena', 12.567, 0);
insert into zarucnica (bojakose, lipa, indiferentno) values ('smeđa', 11.3, 0);

insert into decko_zarucnica (decko, zarucnica) values (1, 1);
insert into decko_zarucnica (decko, zarucnica) values (2, 1);
insert into decko_zarucnica (decko, zarucnica) values (1, 3);


--zad 2
update prijatelj set treciputa='2020-04-30';


--zad 3
delete from brat where ogrlica <> 14;


--zad 4
select suknja from cura where drugiputa is null;


--zad 5
select c.novcica, f.neprijatelj, e.haljina from decko a
inner join decko_zarucnica b on b.decko=a.sifra
inner join zarucnica c on b.zarucnica=c.sifra
inner join cura d on d.decko=a.sifra
inner join neprijatelj e on e.cura=d.sifra
inner join brat f on f.neprijatelj=e.sifra
where d.drugiputa is not null and a.vesta like '%ba%' order by e.haljina desc;


--zad 6
select a.vesta, a.asocijalno from decko a
left join decko_zarucnica b on b.decko=a.sifra
where b.decko is null;