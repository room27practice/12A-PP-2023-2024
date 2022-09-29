CREATE DATABASE HoraDurjaviGradove
GO
USE HoraDurjaviGradove
GO
CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(16) NOT NULL UNIQUE,
[PopulationMilions] INT NOT NULL,
[Designation] VARCHAR(2) NOT NULL,
[ContinentName] VARCHAR(16) NOT NULL,
[Languages] NVARCHAR(128) NOT NULL,
[Description] NVARCHAR(1024)
)
GO
CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(16) NOT NULL,
[Population] INT NOT NULL,
[PostalCode] VARCHAR(8) UNIQUE,
[CountryId] INT CONSTRAINT FK_Towns_Countries
FOREIGN KEY REFERENCES Countries(Id) NOT NULL,
[Region] INT CONSTRAINT FK_Towns_Towns
FOREIGN KEY REFERENCES Towns(Id)
)
GO
CREATE TABLE People(
Id NVARCHAR PRIMARY KEY,
[FirstName] VARCHAR(16) NOT NULL,
[SurnName] VARCHAR(16),
[LastName] VARCHAR(16) NOT NULL,
[Age] INT NOT NULL,
[Gender] BIT NOT NULL,
[Email] NVARCHAR(32) NOT NULL UNIQUE,
[Description] NVARCHAR(MAX) ,
[TownId] INT CONSTRAINT FK_People_Towns
FOREIGN KEY REFERENCES Towns(Id),
CONSTRAINT Age_range CHECK (Age BETWEEN 1 AND 125)
) 
GO



INSERT INTO Countries VALUES
('Bulgaria',6.5,'BG','Europe','Bulgarian','Visoki sini planini, Reki I zlatni ravnini.'),
('Uganda',45,'UG','Africa','English','For God and My Country.'),
('USA',329,'US','South America','English, Spanish','In God We Trust.'),
('Macedonia',2,'MK','Europe','Macedonian',null)

SELECT * FROM Countries
SELECT * FROM Towns

INSERT INTO Towns VALUES
('Shumen',89000,'9700',1, 1),
('Plovdiv',343000,'4000', 1, 2),
('Smiadovo',4044,'9820', 1, 1),
('Richmond',229000,'V4K',3,null),
('Kampala',1500000,'759125',2, 5)

DELETE FROM Towns
DBCC CHECKIDENT ('Towns', RESEED, 0)


SELECT * FROM People
INSERT INTO People(FirstName,SurnName,LastName,Age,Gender,Email,Id,TownId,Description)
(


