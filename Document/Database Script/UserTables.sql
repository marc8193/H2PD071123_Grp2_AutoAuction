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
	Privat int,
	Firm int,
	Name varchar NOT NULL,
	ZipCode varchar(25),

	CONSTRAINT FK_Privat
	FOREIGN KEY (Privat)
	REFERENCES PrivatUsers (Id),

	CONSTRAINT FK_Firm
	FOREIGN KEY (Firm)
	REFERENCES FirmUsers (Id),
)

-----------------Accounts
CREATE TABLE Transactions(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	Date DateTime,
	Status varchar,
	Ammount decimal,
)

CREATE TABLE Accounts(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	PrivatUser int,
	FirmUser int,
	Transactions int,
	Credit decimal,

	CONSTRAINT FK_PrivatUser
	FOREIGN KEY (PrivatUser)
	REFERENCES PrivatUsers (Id),

	CONSTRAINT FK_FirmUser
	FOREIGN KEY (FirmUser)
	REFERENCES FirmUsers (Id),

	CONSTRAINT FK_Transactions
	FOREIGN KEY (Transactions)
	REFERENCES Transactions (Id),
)