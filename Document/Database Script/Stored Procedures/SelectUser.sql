
CREATE PROCEDURE SelectUser
	@UserId int,
	@CreditAndBalance int = null
AS
BEGIN
	DECLARE
	--Ids
	@Firm int,
	@Privat int,
	
	--Used for Exec SelectUserData
	@Table varchar(255),
	@NextId int;

	SELECT
		@Firm = G.FirmId,
		@Privat = G.PrivatId
		FROM (
			SELECT
				fi.Id As FirmId,
				pr.Id AS PrivatId
			FROM
				dbo.Users us
			LEFT JOIN
				dbo.FirmUsers fi ON us.FirmId  = fi.Id
			LEFT JOIN
				dbo.PrivatUsers pr ON us.PrivatId = pr.Id
			WHERE
				us.Id = @UserId
		) AS G
	IF @Firm IS NOT NULL
		BEGIN
			SET @Table = 'FirmUsers'
			SET @NextId = @Firm;
			--SELECT @Firm AS FirmId
		END;
	ELSE IF @Privat IS NOT NULL
		BEGIN
			SET @Table = 'PrivatUsers'
			SET @NextId = @Privat;
			--SELECT @Privat as PrivatId
		END;
	
	IF @CreditAndBalance IS NULL
		BEGIN
			EXEC SelectUserData @Table, @NextId, @UserId;
		END;

	IF @CreditAndBalance IS NOT NULL
		BEGIN
			EXEC SelectUserBalanceAndCredit @Table, @UserId;
		END;
END;