USE auction
GO

CREATE PROCEDURE SelectAllAuction
AS
BEGIN
    SELECT a.*, b.Name AS BaseVehicleName
    FROM Auction AS a
    LEFT JOIN Basevehicles AS b ON a.VehicleId = b.Id;

	--Get latest Bid
END;