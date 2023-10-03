USE [auction]
GO

DECLARE	@return_value int,
		@AuctionId int

EXEC	@return_value = [dbo].[SetForSale]
		@VehicleId = 9,
		@UserId = 16,
		@Visible = 1,
		@MinPrice = 200,
		@EndDate = '2023-09-30 14:30:00',
		@AuctionId = @AuctionId OUTPUT

SELECT	@AuctionId as N'@AuctionId'

SELECT	'Return Value' = @return_value

GO
