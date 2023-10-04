USE auction
GO

CREATE PROCEDURE SetForSale (
	--For Base
	@VehicleId int,
	@UserId int,
	@Visible bit,
	@MinPrice Decimal(18,0),
	@EndDate datetime,

	@BidId int OUT
) AS
BEGIN
	--BEGIN TRY
	--	BEGIN TRANSACTION;

			INSERT INTO Auction(VehicleId, UserId, Visible, MinPrice, EndDate)
			VALUES (@VehicleId, @UserId, @Visible, @MinPrice, @EndDate)

			SET @BidId = SCOPE_IDENTITY();

			INSERT INTO Bid(UserId, AuctionId, Status, BidAmount, Date)
			VALUES (@UserId, @AuctionId, '', @MinPrice, CURRENT_TIMESTAMP)
		
	--	COMMIT;
	--END TRY
	--BEGIN CATCH
	--	-- We can log Error here
	--	ROLLBACK;
	--	THROW;
	--END CATCH
END;