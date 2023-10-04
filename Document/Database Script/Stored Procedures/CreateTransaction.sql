ALTER TRIGGER CreateTransaction
ON Auction
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Visible) AND EXISTS (SELECT 1 FROM inserted WHERE Visible = 'False')
    BEGIN

		--Get Auction
		DECLARE 
		@AuctionId int,
		@AuctionUserID int;

		-- USED FOR TEST START--
        --SELECT @AuctionId = 1
        --FROM Auction
        ----WHERE Visible = 0;
		--USED FOR TEST END--

		SELECT @AuctionId = Id
        FROM inserted
        WHERE Visible = 'False';

		--Select AuctionUserID
		Select @AuctionUserID = userId
		FROM Auction
		WHERE Id = @AuctionId

		--Find Bid WHERE Bid.AuctionId = AuctionId
		DECLARE 
		@UserId INT,
		@BidAmount decimal(18,0);

		SELECT @UserId = UserId, @BidAmount = BidAmount 
		FROM Bid
		WHERE AuctionId = @AuctionId
		AND Date = (
			SELECT MAX(Date)
			FROM Bid
			WHERE AuctionId = @AuctionId
		)

		Select @UserId as userid;
		Select @BidAmount as bidamount;

		--Exec SelectUser WHERE UserId = Bid.UserId
		DECLARE @Results TABLE (
			Balance decimal(18,0),
			AccountId int,
			PrivatUserId int,
			FirmUserId int
		);
		INSERT INTO @Results (Balance, AccountId, PrivatUserId, FirmUserId)
		EXEC SelectUser @UserId, 2;

		DECLARE @BalanceToUpdate decimal(18,0);
		DECLARE @PrivatUserIdToUpdate int;
		DECLARE @FirmUserIdToUpdate int;
		DECLARE @AccountIdToUpdate int;

		DECLARE ResultCursor CURSOR FOR
		SELECT Balance, AccountId, PrivatUserId, FirmUserId FROM @Results;

		OPEN ResultCursor;

		FETCH NEXT FROM ResultCursor INTO @BalanceToUpdate, @AccountIdToUpdate, @PrivatUserIdToUpdate, @FirmUserIdToUpdate;

		--Update Balance -Bid.BidAmount
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @PrivatUserIdToUpdate IS NOT NULL
			BEGIN
				--Update Balance -Bid.BidAmount
				UPDATE PrivatUsers
				SET Balance = Balance - @BidAmount
				WHERE Id = @UserId;

				--Update Balance +Bid.BidAmount
				UPDATE PrivatUsers
				SET Balance = Balance + @BidAmount
				WHERE Id = @AuctionUserID
			END
			ELSE IF @FirmUserIdToUpdate IS NOT NULL
			BEGIN
				--Update Balance -Bid.BidAmount
				UPDATE FirmUsers
				SET Balance = Balance - @BidAmount
				WHERE Id = @UserId;

				--Update Balance +Bid.BidAmount
				UPDATE PrivatUsers
				SET Balance = Balance + @BidAmount
				WHERE Id = @AuctionUserID
			END;

			--INSERT Into Transaction Bid.UserId
			INSERT INTO Transactions (AccountId, Date, Status, Ammount)
			VALUES (@AccountIdToUpdate, CURRENT_TIMESTAMP, N'-', @BidAmount)

			--INSERT Into Transaction Auction.UserId
			INSERT INTO Transactions (AccountId, Date, Status, Ammount)
			VALUES (@AuctionUserID, CURRENT_TIMESTAMP, N'+', @BidAmount)

			FETCH NEXT FROM ResultCursor INTO @BalanceToUpdate, @PrivatUserIdToUpdate, @FirmUserIdToUpdate;
		END;

		CLOSE ResultCursor;
		DEALLOCATE ResultCursor;
    END
END;
