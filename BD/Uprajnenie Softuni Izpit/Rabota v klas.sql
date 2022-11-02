CREATE TABLE DepositTypes(
DepositTypeID int PRIMARY KEY IDENTITY,
[Name] nvarchar(20),
)
GO
CREATE TABLE Deposits(
DepositID int PRIMARY KEY IDENTITY,
Amount decimal(10,2),
StartDate date,
EndDate date,
DepositTypeID int,
CustomerID int,
CONSTRAINT FK_Deposits_DepositType 
FOREIGN KEY(DepositTypeID) REFERENCES DepositTypes(DepositTypeID),
CONSTRAINT FK_Deposits_Customers 
FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
)
GO
CREATE TABLE EmployeesDeposits(
EmployeeID int,
DepositID int,
PRIMARY KEY(EmployeeID,DepositID),
CONSTRAINT FK_EmployeesDeposits_Employees
FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeesDeposits_Deposits
FOREIGN KEY(DepositID) REFERENCES Deposits(DepositID),
)
GO
CREATE TABLE CreditHistory(
CreditHistoryID int PRIMARY KEY,
Mark char,
StartDate date,
EndDate date,
CustomerID int,
CONSTRAINT FK_CreditHistory_Customers
FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
)
GO
CREATE TABLE Payments(
PayementID int PRIMARY KEY,
Date date,
Ammound decimal(10,2),
LoadID int,
CONSTRAINT FK_Payments_Loans
FOREIGN KEY(LoadID) REFERENCES Loans(LoanID),
)
GO
CREATE TABLE Users(
UserID int PRIMARY KEY,
UserName nvarchar(20),
Password nvarchar(20),
CustomerID int UNIQUE,
CONSTRAINT FK_Users_Customers
FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
)
GO
ALTER TABLE Employees
ADD ManagerID int,
CONSTRAINT FK_Employees_Employees
FOREIGN KEY(ManagerID) REFERENCES Employees(EmployeeID)

SELECT * FROM DepositTypes

INSERT INTO EmployeesDeposits VALUES
(15, 	4 ),
(20, 	15),
(8 ,	7 ),
(4 ,	8 ),
(3 ,	13),
(3 ,	8 ),
(4 ,	10),
(10,	1 ),
(13,	4 ),
(14,	9 )

INSERT INTO DepositTypes VALUES
(1,	'Time Deposit'),
(2,	'Call Deposit'),
(3,	'Free Deposit')

INSERT INTO Deposits VALUES


SELECT * FROM Deposits


SELECT CustomerID,Gender,DateOfBirth FROM Customers AS c
WHERE CustomerID <20