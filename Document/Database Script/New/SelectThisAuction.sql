Use auction
Go

Alter PROCEDURE [dbo].[SelectThisAuction](
	@AuctionId int
) AS
BEGIN
	
	--Declare @AuctionId int  = 1

    SELECT a.*, b.*, b.Id AS BaseVehicleId, nb.BidAmount AS NewestBidAmount
	FROM Auction AS a
	LEFT JOIN Basevehicles AS b ON a.VehicleId = b.Id
	LEFT JOIN (
		SELECT Bid.AuctionId, MAX(Bid.Date) AS NewestDate
		FROM Bid
		GROUP BY Bid.AuctionId
	) AS latest_bid_dates ON a.Id = latest_bid_dates.AuctionId
	LEFT JOIN Bid AS nb ON latest_bid_dates.AuctionId = nb.AuctionId AND latest_bid_dates.NewestDate = nb.Date
	WHERE a.Id = @AuctionId;
END;
