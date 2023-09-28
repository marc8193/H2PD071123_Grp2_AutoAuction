USE [auction]
GO

DECLARE	@return_value int,
		@AuctionId int

EXEC	@return_value = [dbo].[SetForSale]
		@VehicleId = 9,
		@UserId = 16,
		@Visable = 1,
		@MinPrice = 200,
		@EndDate = '2015-10-01',
		@BidId = @BidId OUTPUT

SELECT	@AuctionId as N'@BidId'

SELECT	'Return Value' = @return_value

GO
