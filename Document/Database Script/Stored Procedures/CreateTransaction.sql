CREATE TRIGGER CreateTransaction
ON Auction
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Visible)
    BEGIN
        --Code here

		--Find Bid WHERE Bid.AuctionId = AuctionId

		--Exec SelectUser WHERE UserId = Bid.UserId
		--Update Balance -Bid.BidAmount

		--Exec SelectUser WHERE UserId = Auction.UserId
		--Update Balance +Bid.BidAmount

		--INSERT Into Transaction Bid.UserId
		--Date = CURRENT_TIMESTAMP
		--Status = Gone through
		--Ammount = Bid.BidAmount

		--INSERT Into Transaction Auction.UserId
		--Date = CURRENT_TIMESTAMP
		--Status = Gone through
		--Ammount = Bid.BidAmount

    END
END;