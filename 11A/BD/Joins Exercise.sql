--1
SELECT TOP(5) e.EmployeeID AS 'EmployeeId',e.JobTitle,e.AddressID AS 'AddressId',a.AddressText FROM Employees AS e
LEFT OUTER JOIN Addresses AS a
ON e.AddressID=a.AddressID
ORDER BY e.AddressID

--2
SELECT TOP(50) e.FirstName,e.LastName,t.Name,a.AddressText FROM Employees AS e
LEFT OUTER JOIN Addresses AS a
ON e.AddressID=a.AddressID
LEFT OUTER JOIN Towns AS t
ON a.TownID=t.TownID
ORDER BY e.FirstName, e.LastName

--3
SELECT  e.EmployeeID,CONCAT(e.FirstName,' ',e.LastName) AS 'Full Name',d.Name AS 'DepartmentName' FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID=d.DepartmentID
WHERE d.Name='SaleS' OR d.Name='Tool DESIGN'
ORDER BY e.EmployeeID

--4
SELECT TOP(5)  e.EmployeeID,e.FirstName,e.LastName,e.Salary,d.Name AS 'DepartmentName' FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID=d.DepartmentID
WHERE e.Salary>15000
ORDER BY d.DepartmentID

--5
SELECT TOP(3) e.EmployeeID AS 'Id',e.FirstName FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY Id

--6
SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS 'DeptName' FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID=d.DepartmentID
WHERE d.Name IN('Sales','Finance') AND e.HireDate>CONVERT(DATETIME, '1999-01-01', 102)--'19990101'
ORDER BY HireDate

--7
SELECT TOP(5) e.EmployeeID, e.FirstName,p.Name AS 'ProjectName' FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
ON e.EmployeeID=ep.EmployeeID
LEFT OUTER JOIN Projects AS p
ON ep.ProjectID=p.ProjectID
WHERE p.StartDate>CONVERT(DATETIME, '2002-08-13', 102) AND p.EndDate IS NULL


--8
SELECT e.EmployeeID,FirstName,
CASE 
   WHEN p.StartDate <= '01/01/2005'
   THEN  p.NAME
   ELSE NULL
   END  AS 'Project'
FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
LEFT OUTER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--9
SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS 'ManagenId', m.FirstName AS 'ManagerName' FROM Employees AS e
LEFT OUTER JOIN Employees AS m
ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7) 
ORDER BY e.EmployeeID

--10
SELECT TOP(50) e.EmployeeID, CONCAT(e.FirstName,' ',e.LastName) AS 'EmployeeName',  CONCAT(m.FirstName,' ',m.LastName) AS 'ManagerName', d.Name AS 'DepartmentName'
FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
LEFT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID






--, e.FirstName, e.HireDate, d.Name AS 'DepartmentName' 
FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
LEFT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
--, e.FirstName, e.HireDate, d.Name AS 'DepartmentName'
FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
LEFT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
--, e.FirstName, e.HireDate, d.Name AS 'DepartmentName'
FROM Employees AS e
LEFT OUTER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
LEFT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID


WHERE e.ManagerID IN (3,7) 
ORDER BY e.EmployeeID




SELECT * FROM Employees

SELECT * FROM Departments

SELECT * FROM Addresses

SELECT * FROM Towns
SELECT * FROM 