USE auction
GO

CREATE PROCEDURE CreateFirmUser(
	--Used for Login
	--@UserName varchar(300),
	--@Password varchar(max),

	--Used for Privat User
	--@SocialSecurityNumber varchar(25),
	--@BalancePrivat decimal(18,0),
	--@PrivatUserId int output

	--Used for Frim User
	@Cvr varchar(25),
	@BalanceFirm decimal(18,0),
	@FirmUserId int output

	--For user
	--@ZipCode varchar(25),
	--@UserId int output,

	--For Account
	--@Credit decimal(18,0)

) AS
BEGIN
	INSERT INTO FirmUsers (Cvr, Balance)
	VALUES (@Cvr, @BalanceFirm)

	SET @FirmUserId = SCOPE_IDENTITY();
END;