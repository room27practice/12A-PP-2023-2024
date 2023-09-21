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
Id NVARCHAR(64) PRIMARY KEY,
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

INSERT INTO People(FirstName,SurnName,LastName,Age,Gender,Email,TownId,[Description],Id) VALUES
('Kosta','Ivanov','Mladenov',35,1,'kom@abv.bg',3,NULL,'f402e41e-78aa-4559-a495-4453b528a959'),
('Malinka',null ,'Ivanova',25,0,'malimali@yahoo.com',2,	null,'a3d610da-9997-4e58-855a-e2af51d4048e'),
('Kamelia','Amelieva' ,'Preslavova',21,0,'kamali@gmail.com',1,'GenshinImpact',	'066557c7-2333-4209-8982-0833d86a97c2'),
('Marin',null , 'Goleminov',40,1,'marin_g@gmail.com',1,null,'4780bdf4-ba71-4657-be2d-b0dcb389bd08'),
('Sambo','Viktor','Dontworry',58,1,'sambomambo@ugabuga.com', 5,null,'20648ab1-c5ea-4099-90ed-a77b5e173994'),
('John', 'Bob', 'Marley', 17,1,'johnybegood@yahoo.com', 4,null,'d91d8c64-e627-4502-864b-6df244d7dea6'),
('Jessica', 'Jehna', 'Jahmeson', 27,0,'jehna27@gmail.com', 4, null,'0154e4fb-bed2-40a6-bdf1-ab9ba00ec621')

--/DROP TABLE People

SELECT * FROM Countries
SELECT * FROM Towns
SELECT * FROM People

SELECT [FirstName] as 'Първо име',[LastName],[Gender] as 'Пол',[Id] FROM People

--SELECT TOP(2) [Name],[PostalCode] as Post FROM Towns AS T


SELECT * FROM Countries
TRUNCATE TABLE Countries