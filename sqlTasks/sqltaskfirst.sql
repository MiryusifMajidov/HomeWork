CREATE TABLE regions(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(25)
);

INSERT INTO regions (Name)
VALUES
    ('Qafqaz'),
    ('Avropa'),
    ('Asiya');


CREATE TABLE countries(
	Id int IDENTITY PRIMARY KEY,
	Name VARCHAR(25),
	RegionId int,
	FOREIGN KEY (RegionId) REFERENCES regions(Id)

);

INSERT INTO countries (Name, RegionId)
VALUES
    ('Azərbaycan', 1),
    ('Gürcüstan', 1),
    ('Türkiyə', 1);


CREATE TABLE locations(
	Id INT IDENTITY PRIMARY KEY,
	StreetAdress VARCHAR(25),
	PostalCode VARCHAR(12),
	City VARCHAR(30),
	StateProvince VARCHAR(12),
	CounryId int,
	FOREIGN KEY (CounryId) REFERENCES countries(Id)

);


CREATE TABLE departaments(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(25),
	PostalCode VARCHAR(12),
	LocationId int,
	ManagerId INT,
	FOREIGN KEY (LocationId) REFERENCES locations(Id)

);

CREATE TABLE lobHistory(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(25),
	PostalCode VARCHAR(12),
	LocationId INT,
	FOREIGN KEY (LocationId) REFERENCES locations(Id)

);

CREATE TABLE jobs(
	Id NVARCHAR(10) PRIMARY KEY,
	Title VARCHAR(25),
	MinSalary INT,
	MaxSalary INT,
	
);


CREATE TABLE jobgGrades(
	GradesLevel NVARCHAR(2) PRIMARY KEY,
	LowestSal INT,
	HighestSal INT,
);

CREATE TABLE employees(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20),
	LastName NVARCHAR(25),
	Email NVARCHAR(25),
	PhoneNumber NVARCHAR(20),
	HireDate DATE,
	JobId NVARCHAR(10),
	Salary INT,
	CommissionCPT INT,
	ManagerId INT,
	DepartmentId INT,
	FOREIGN KEY (DepartmentId) REFERENCES departaments(Id)
	
);



