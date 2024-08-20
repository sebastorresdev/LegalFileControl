CREATE DATABASE LegalFileControlDb;

USE LegalFileControlDb;

-----------------------------------------------------
-- CREACIÓN DEL MÓDULO DE USUARIOS
-----------------------------------------------------
CREATE TABLE Roles (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Description VARCHAR(220) NOT NULL,
	CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(120) NOT NULL,
	Dni VARCHAR(10) NOT NULL,
	UserName VARCHAR(20) NOT NULL,
	Password VARCHAR(255) NOT NULL, -- Tamaño mayor para posibles contraseñas cifradas
	CreatedDate DATETIME DEFAULT GETDATE(),
	IsActive BIT DEFAULT 1,
	RoleId INT NOT NULL,
	FOREIGN KEY (RoleId) REFERENCES Roles (Id)
);

CREATE TABLE MenuItems (
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(220),
	Icon VARCHAR(220),
	RouterLink VARCHAR(220),
	ParentId INT,
	FOREIGN KEY (ParentId) REFERENCES MenuItems(Id)
);

CREATE TABLE Permissions (
	Id INT PRIMARY KEY IDENTITY,
	Description VARCHAR(50) NOT NULL,
	MenuItemId INT NOT NULL,
	FOREIGN KEY (MenuItemId) REFERENCES MenuItems(Id)
);

CREATE TABLE RolePermissions (
	Id INT PRIMARY KEY IDENTITY,
	PermissionId INT NOT NULL,
	RoleId INT NOT NULL,
	FOREIGN KEY (PermissionId) REFERENCES Permissions(Id),
	FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

-----------------------------------------------------
-- CREACIÓN DEL MÓDULO DE LEGAJOS
-----------------------------------------------------
CREATE TABLE LegalFileStatuses (
	Id INT PRIMARY KEY IDENTITY,
	StatusCode CHAR(1),
	Description VARCHAR(50)
);

CREATE TABLE LegalFiles (
	Id INT PRIMARY KEY IDENTITY,
	CustomerCode VARCHAR(10) NOT NULL,
	Period VARCHAR(10) NOT NULL,
	LegalFileStatusId INT NOT NULL,
	ValidationDate DATETIME NULL, -- Permitir NULL para fechas opcionales
	RejectionReason VARCHAR(500) NULL, -- Permitir NULL si no siempre hay una razón de rechazo
	WOCount INT NOT NULL,
	FOREIGN KEY (LegalFileStatusId) REFERENCES LegalFileStatuses (Id)
);

-----------------------------------------------------
-- CREACIÓN DEL MÓDULO DE CARGOS
-----------------------------------------------------
CREATE TABLE Charges (
	Id INT PRIMARY KEY IDENTITY,
	ReceptionDate DATETIME,
	UserId INT NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ImagePath VARCHAR(300),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE ChargeLegalFile (
	Id INT PRIMARY KEY IDENTITY,
	ChargeId INT NOT NULL,
	LegalFileId INT NOT NULL,
	FOREIGN KEY (ChargeId) REFERENCES Charges(Id),
	FOREIGN KEY (LegalFileId) REFERENCES LegalFiles(Id)
);
