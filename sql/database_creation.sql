/*
 ----------------------------------------------------------------------------
             G�n�ration d'une base de donn�es pour
                        SQL Server 2005
                       (9/6/2023 8:52:00)
 ----------------------------------------------------------------------------
     Nom de la base : EcoGraph
     Projet : EcoGraph
     Auteur : Tchang William
     Date de derni�re modification : 9/6/2023 8:51:14
 ----------------------------------------------------------------------------
*/
use master

drop database Equipe3
go

/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE EcoGraph
----------------------------------------------------------------------------- */

create database Equipe3
go

use Equipe3
go



/* -----------------------------------------------------------------------------
      TABLE : Type
----------------------------------------------------------------------------- */

create table Type
  (
     idType INT PRIMARY KEY identity(1,1),
     nomType char(255)  not null ,
     uniteType char(255)  not null  
     ,
     unique(idType)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : Pays
----------------------------------------------------------------------------- */

create table Pays
  (
     idPays  INT PRIMARY KEY identity(1,1),
     nomPays char(255)  not null  ,
     codeISO3 char(255)  not null  
     ,
     UNIQUE(idPays)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : Donnee
----------------------------------------------------------------------------- */

create table Donnee
  (
     idDonnee INT PRIMARY KEY identity(1,1),
     idPays INT  not null  ,
     idType INT  not null  ,
     valeur decimal(10,2)  not null  ,
     annee smallint  not null  
     ,
     unique(idDonnee,idPays,idType)
  ) 
go



/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table Donnee 
     add constraint FK_DONNEE_PAYS foreign key (idPays) 
               references Pays (idPays)
go




alter table Donnee 
     add constraint FK_DONNEE_TYPE foreign key (idType) 
               references Type (idType)
go




/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/

create user etd03 

GRANT view definition, select, update, insert, delete TO etd03