Use auction
Go

CREATE PROCEDURE UpdateAuctionVisibility
AS
BEGIN
	UPDATE Auction -- Replace with your actual table name
    SET Visible = 0
    WHERE EndDate >= CURRENT_TIMESTAMP;
END;