-- drop database dbBancoApp; --
create database dbBancoApp;
use dbBancoApp;
create table usuario
(
IdUsu int primary key auto_increment,
nomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime
);
/* insert into usuario(nomeUsu,Cargo,DataNasc)
 values('Robison','Gerente','1978-05-01'),
('Luisao','Colaborador','2000-12-10'); */
create table cliente(
IdCli int primary key auto_increment,
NomeCli varchar(50) not null,
Endereco varchar(50) not null,
NumEnd decimal (4,0) not null,
Situacao varchar(50) not null
);


-- select * from usuario; --