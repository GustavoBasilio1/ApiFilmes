create database dbApiFilme;
use dbApiFilme;

create table tbAdmin(
	login varchar(100) primary key,
    senha varchar(50) not null
);

create table tbGenero(
	id int primary key auto_increment,
    genero varchar(100)
);

create table tbFilme(
	imdb varchar(10) primary key,
    titulo varchar(100),
    ano varchar(10),
    avaliacao varchar(10),
    tempo varchar(10),
    diretor varchar(100),
    poster varchar(100),
    FK_generoID int not null,
    foreign key(FK_generoID) references tbGenero(id)
);

