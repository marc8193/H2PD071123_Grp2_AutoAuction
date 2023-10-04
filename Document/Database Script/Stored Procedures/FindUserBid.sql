CREATE PROCEDURE FindUserBid
    @UserId INT
AS
BEGIN
    SELECT *
    FROM Bid
    WHERE Bid.UserId = @UserId
    ORDER BY Bid.Date DESC;
END;