use auction

--Connected to BaseVehicle Table
--CREATE TABLE LicensTypes(
--	Id int IDENTITY(1, 1) PRIMARY KEY,
--	Name varchar(2)
--)

--Connected to BaseVehicle Table
--CREATE TABLE Energys(
--	Id int IDENTITY(1, 1) PRIMARY KEY,
--	Klass int
--)

--Will get a trigger to be filled?
--CREATE TABLE Fuel(
--	Id int IDENTITY(1, 1) PRIMARY KEY,
--	Name varchar(20)
--)

CREATE TABLE BaseVehicles(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	--LicensTypeId int,
	--EnergyId int,
	Name varchar(50) NOT NULL,
	Km int CHECK(Km >= 0),
	Registration varchar(7),
	Year int,
	Price decimal CHECK(Price >= 0),
	Towbar bit,
	EngineSize decimal CHECK(EngineSize >= 0.7 AND EngineSize <= 15),
	KmPr decimal,
	LicensTypes varchar(2),
	EnergyClass varchar(2),
	Fuel varchar(20)
	
	----OR use Check constraint connected to Enum
	--CONSTRAINT FK_LicensType
	--FOREIGN KEY (LicensTypeId)
	--REFERENCES LicensTypes (Id),

	--CONSTRAINT FK_Energy
	--FOREIGN KEY (EnergyId)
	--REFERENCES Energys (Id)
)

-----------------

--Connected to BaseVehicle Table
CREATE TABLE HeavyVehicles(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	BaseVehicleId int,
	Height decimal,
	Weight decimal,
	Length decimal,

	CONSTRAINT FK_BaseVehicle
	FOREIGN KEY (BaseVehicleId)
	REFERENCES BaseVehicles (Id),
)

--Connected to HeavyVehicles Table
CREATE TABLE Bus(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	HeavyVehicleId int,
	Seats int,
	Sleep int,
	Toilet bit,

	CONSTRAINT FK_HeavyVehicle
	FOREIGN KEY (HeavyVehicleId)
	REFERENCES HeavyVehicles (Id),
)

--Connected to HeavyVehicles Table
CREATE TABLE Trucks(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	HeavyVehicleId int,
	Capacity decimal,

	CONSTRAINT FK_HeavyVehicleTruck
	FOREIGN KEY (HeavyVehicleId)
	REFERENCES HeavyVehicles (Id),
)

-----------------

--Connected to BaseVehicles Table
CREATE TABLE LightVehicles(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	BaseVehicleId int,
	Seats int CHECK(Seats >= 2 AND Seats <= 7),
	Height decimal,
	Width decimal,
	Length decimal,

	CONSTRAINT FK_BaseVehicleLight
	FOREIGN KEY (BaseVehicleId)
	REFERENCES BaseVehicles (Id),
)

--Connected to LightVehicles Table
CREATE TABLE BusinessCar(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	LightVehicleId int,
	SafetyBar bit,
	Capacity decimal,

	CONSTRAINT FK_LightVehiclesBusCar
	FOREIGN KEY (LightVehicleId)
	REFERENCES LightVehicles (Id),
)

--Connected to LightVehicles Table
CREATE TABLE PrivateCar(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	LightVehicleId int,
	IsoFix bit,

	CONSTRAINT FK_LightVehiclesPrivCar
	FOREIGN KEY (LightVehicleId)
	REFERENCES LightVehicles (Id),
)