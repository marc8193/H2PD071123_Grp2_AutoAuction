CREATE PROCEDURE FindLatestBidForAuction
    @AuctionId INT
AS
BEGIN
    SELECT TOP 1 b.Id, b.AuctionId, b.Date, b.BidAmount
    FROM Bid AS b
    WHERE b.AuctionId = @AuctionId
    ORDER BY b.Date DESC;
END;