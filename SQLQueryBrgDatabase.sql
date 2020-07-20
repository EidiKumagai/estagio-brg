
create database brgDatabase;
go

use brgDatabase;
go


CREATE TABLE Colaborador (
 ID_colaborador SMALLINT,
 cargo VARCHAR(40),
 departamento VARCHAR(60)
 CONSTRAINT pk_ID_colaborador PRIMARY KEY (ID_colaborador)
);
go

CREATE TABLE Habilidades (
 ID_habilidades SMALLINT,
 tipo VARCHAR(40),
 nome VARCHAR(60)
 CONSTRAINT pk_ID_habilidades PRIMARY KEY (ID_habilidades)
);
go

CREATE TABLE Trilha (
 ID_trilha SMALLINT,
 ID_colaborador SMALLINT NOT NULL,
 ID_habilidades SMALLINT NOT NULL,
 Data_trilha DATE,
 CONSTRAINT pk_ID_trilha PRIMARY KEY (ID_trilha)
);
go


alter table Trilha
add constraint fk_ID_colaborador FOREIGN KEY ( ID_colaborador ) references Colaborador(ID_colaborador)
go


alter table Trilha
add constraint fk_ID_habilidade FOREIGN KEY ( ID_habilidades ) references Habilidades(ID_habilidades)
go 
