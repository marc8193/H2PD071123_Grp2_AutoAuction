USE auction
GO

CREATE PROCEDURE CreateBid(
	@UserId int,
	@AuctionId int,
	@Status varchar(25),
	@BidAmount decimal(18,0)
) AS
BEGIN
	DECLARE
	--Auction data
	@EndDate datetime,
	@MinPrice Decimal(18,0),
	@bidId int;

	--User
	DECLARE @Result TABLE (
        Balance DECIMAL(18, 0),
        Credit DECIMAL(18, 0)
    );

	--User data
	INSERT INTO @Result
    EXEC SelectUser @UserId, 1;

	--Select Auction
	SELECT @EndDate = EndDate, @MinPrice = MinPrice
	FROM auction
	WHERE Id = @AuctionId;

	IF(CURRENT_TIMESTAMP <= @EndDate AND @BidAmount >= @MinPrice AND EXISTS (SELECT 1 FROM @Result WHERE Balance + Credit >= @BidAmount))
	BEGIN
		BEGIN
			INSERT INTO dbo.Bid (UserId, AuctionId, Status, BidAmount, Date)
			VALUES (@UserId, @AuctionId, @Status, @BidAmount, CURRENT_TIMESTAMP);

			SET @bidId = SCOPE_IDENTITY();
		END;
	END;

	SELECT @bidId AS BidId;
END;
