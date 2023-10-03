USE [auction]
GO

DECLARE	@return_value int,
		@PrivatUserId int,
		@FirmUserId int,
		@UserId int

EXEC	@return_value = [dbo].[CreateUser]
		@UserName = N'tests',
		@Password = N'12345678',
		@SocialSecurityNumber = N'202020',
		--@Cvr = N'20',
		@Balance = 200,
		@PrivatUserId = @PrivatUserId OUTPUT,
		@FirmUserId = @FirmUserId OUTPUT,
		@ZipCode = N'9320',
		@UserId = @UserId OUTPUT,
		@Credit = 0

SELECT	@PrivatUserId as N'@PrivatUserId',
		@FirmUserId as N'@FirmUserId',
		@UserId as N'@UserId'

SELECT	'Return Value' = @return_value

GO
