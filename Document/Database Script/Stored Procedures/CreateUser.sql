USE auction
GO

CREATE PROCEDURE CreateUser(
	--Used for Login
	@UserName varchar(300),
	@Password varchar(max),

	@Balance decimal(18,0) = null,

	--Used for Privat User
	@SocialSecurityNumber varchar(25) = null,
	@PrivatUserId int output,

	--Used for Frim User
	@Cvr varchar(25) = null,
	@FirmUserId int output,

	--For user
	@ZipCode varchar(25),
	@UserId int output,

	--For Account
	@Credit decimal(18,0)

) AS
BEGIN
	EXEC CreateLogin @UserName, @Password;

	IF @SocialSecurityNumber IS NOT NULL
		BEGIN
			EXEC CreatePrivatUser @SocialSecurityNumber, @Balance, @PrivatUserId = @PrivatUserId OUTPUT;
		END;
	ELSE IF @Cvr IS NOT NULL
		BEGIN
			EXEC CreateFirmUser @Cvr, @Balance, @FirmUserId = @FirmUserId OUTPUT;
		END;

		--Users
		INSERT INTO Users (PrivatId, FirmId, Name, ZipCode)
		VALUES (@PrivatUserId, @FirmUserId, @UserName, @ZipCode)

		SET @UserId = SCOPE_IDENTITY();
		
		--CreateAccounts
		INSERT INTO Accounts (PrivatUserId, FirmUserId, Credit)
		VALUES (@PrivatUserId, @FirmUserId, @Credit)
END;