CREATE PROCEDURE SelectUserData
    @Table VARCHAR(255),
    @Id INT,
	@UserId int
AS
BEGIN

    DECLARE @SQL NVARCHAR(600);

	-- Dynamic SQL
	SET @SQL = 'SELECT * FROM dbo.Users LEFT JOIN ' + QUOTENAME(@Table) + ' ON Users.Id = ' +
	CASE WHEN @Table = 'PrivatUsers' THEN 'PrivatUsers.Id' ELSE 'FirmUsers.Id' END +
	' LEFT JOIN Accounts ON Users.Id = ' + CASE WHEN @Table = 'PrivatUsers' THEN 'Accounts.PrivatUserId' ELSE 'Accounts.FirmUserId' END +
	' LEFT JOIN dbo.Transactions ON Accounts.Id = dbo.Transactions.AccountId ' + 
	' WHERE Users.Id = ' + CAST(@UserId AS NVARCHAR(20)) + ';';

	EXEC sp_executesql @SQL;

END;



-- NOTES

--SELECT *
--FROM Users
--LEFT JOIN FirmUsers ON Users.Id = FirmUsers.Id AND IS NOT NULL
--LEFT JOIN PrivatUsers ON Users.Id = PrivatUsers.Id AND IS NOT NULL
--LEFT JOIN Accounts ON Users.Id = Accounts.PrivatUserId OR Users.Id = Accounts.FirmUserId
--LEFT JOIN dbo.Transactions ON Accounts.Id = dbo.Transactions.AccountId
--WHERE Users.Id = 1;

--SELECT *
--FROM Users
--LEFT JOIN FirmUsers ON Users.Id = FirmUsers.Id AND Users.FirmId IS NOT NULL
--LEFT JOIN PrivatUsers ON Users.Id = PrivatUsers.Id AND Users.PrivatId IS NOT NULL
--LEFT JOIN Accounts ON Users.Id = Accounts.PrivatUserId OR Users.Id = Accounts.FirmUserId
--LEFT JOIN dbo.Transactions ON Accounts.Id = dbo.Transactions.AccountId
--WHERE Users.Id = 1;