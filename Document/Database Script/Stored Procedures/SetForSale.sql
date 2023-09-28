USE auction
GO

CREATE PROCEDURE SetForSale (
	--For Base
	@VehicleId int,
	@UserId int,
	@Visable bit,
	@MinPrice Decimal(18,0),
	@EndDate datetime,

	@BidId int OUT
) AS
BEGIN
	--BEGIN TRY
	--	BEGIN TRANSACTION;

			INSERT INTO Auction(VehicleId, UserId, visable, MinPrice, EndDate)
			VALUES (@VehicleId, @UserId, @Visable, @MinPrice, @EndDate)

			SET @BidId = SCOPE_IDENTITY();
		
	--	COMMIT;
	--END TRY
	--BEGIN CATCH
	--	-- We can log Error here
	--	ROLLBACK;
	--	THROW;
	--END CATCH
END;