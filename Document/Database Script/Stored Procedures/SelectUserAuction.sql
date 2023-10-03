USE auction
GO

CREATE PROCEDURE SelectUserAuction(
	@UserId int
) AS
BEGIN
    SELECT a.*, b.Name AS BaseVehicleName
    FROM Auction AS a
    LEFT JOIN Basevehicles AS b ON a.VehicleId = b.Id
	WHERE a.UserId = @UserId;
END;