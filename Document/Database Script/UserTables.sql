use auction

----------------- PRIVAT

CREATE TABLE PrivatUsers(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	SocialSecurityNumber varchar(25),
	Balance decimal,
)

----------------- FIRM

CREATE TABLE FirmUsers(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	Cvr varchar(25),
	Balance decimal,
)

----------------- User

CREATE TABLE Users(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	PrivatId int,
	FirmId int,
	Name varchar(50) NOT NULL,
	ZipCode varchar(25),

	CONSTRAINT FK_Privat
	FOREIGN KEY (PrivatId)
	REFERENCES PrivatUsers (Id),

	CONSTRAINT FK_Firm
	FOREIGN KEY (FirmId)
	REFERENCES FirmUsers (Id),
)

-----------------Accounts
CREATE TABLE Accounts(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	PrivatUserId int,
	FirmUserId int,
	Credit decimal,

	CONSTRAINT FK_PrivatUser
	FOREIGN KEY (PrivatUserId)
	REFERENCES PrivatUsers (Id),

	CONSTRAINT FK_FirmUser
	FOREIGN KEY (FirmUserId)
	REFERENCES FirmUsers (Id),
)

CREATE TABLE Transactions(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	AccountId int,
	Date DateTime,
	Status varchar(50),
	Ammount decimal,

	CONSTRAINT FK_Account
	FOREIGN KEY (AccountId)
	REFERENCES Accounts (Id),
)

