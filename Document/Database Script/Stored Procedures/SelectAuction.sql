--USE auction
--GO

CREATE PROCEDURE SelectAuction
(
    @AuctionId INT
)
AS
BEGIN
    --Declare variables to store VehicleId and UserId
    DECLARE
	@VehicleId INT, 
	@UserId INT;

    --Select the VehicleId and UserId from the Auction table based on AuctionId
    SELECT @VehicleId = VehicleId, @UserId = UserId
    FROM Auction
    WHERE Id = @AuctionId

	--Call the SelectVehicles procedure with VehicleId
    EXEC SelectVehicles @VehicleId

    --Call the SelectUser procedure with UserId
    EXEC SelectUser @UserId

     --Display the selected Auction data
    SELECT *
    FROM Auction
    WHERE Id = @AuctionId
END
