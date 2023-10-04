USE [auction]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SelectAuction]
		@AuctionId = 1

SELECT	'Return Value' = @return_value

GO
