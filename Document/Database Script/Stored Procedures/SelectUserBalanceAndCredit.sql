CREATE PROCEDURE SelectUserBalanceAndCredit
    @Table VARCHAR(255),
    @UserId INT
AS
BEGIN
    DECLARE 
	@SQL NVARCHAR(600);

    -- Dynamic SQL
    SET @SQL = 'SELECT ' +
               CASE WHEN @Table = 'PrivatUsers' THEN 'PrivatUsers.Balance' ELSE 'FirmUsers.Balance' END +
               ' AS Balance, ' +
               'Accounts.Credit AS Credit ' +
               'FROM dbo.Users ' +
               'LEFT JOIN ' + QUOTENAME(@Table) + ' ON Users.Id = ' +
               CASE WHEN @Table = 'PrivatUsers' THEN 'PrivatUsers.Id' ELSE 'FirmUsers.Id' END +
               ' LEFT JOIN Accounts ON Users.Id = ' +
               CASE WHEN @Table = 'PrivatUsers' THEN 'Accounts.PrivatUserId' ELSE 'Accounts.FirmUserId' END +
               ' WHERE Users.Id = ' + CAST(@UserId AS NVARCHAR(20)) + ';';

    EXEC sp_executesql @SQL;
END;
