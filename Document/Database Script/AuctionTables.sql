USE auction

CREATE TABLE Auction(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	VehicleId int,
	UserId int,
	Status varchar(25),
	MinPrice decimal,
	EndDate dateTime

	CONSTRAINT FK_Vehicle
	FOREIGN KEY (VehicleId)
	REFERENCES BaseVehicles (Id),

	CONSTRAINT FK_User
	FOREIGN KEY (UserId)
	REFERENCES Users (Id),
)

CREATE TABLE Bid(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	UserId int,
	AuctionId int,
	Status varchar(25),
	BidAmount decimal,
	Date datetime

	CONSTRAINT FK_Users
	FOREIGN KEY (UserId)
	REFERENCES Users (Id),

	CONSTRAINT FK_Auction
	FOREIGN KEY (AuctionId)
	REFERENCES Auction (Id),
)