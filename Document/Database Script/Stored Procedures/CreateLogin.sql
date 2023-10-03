USE auction
GO

CREATE PROCEDURE CreateLogin(
	@UserName varchar(300),
	@Password varchar(max)
) AS
BEGIN
	EXEC('CREATE LOGIN ' + @UserName + ' WITH PASSWORD = ''' + @password + ''', CHECK_POLICY=OFF');
	EXEC('CREATE USER ' + @UserName + ' FOR login ' + @UserName + ';')

	--Add table names
	EXEC ('GRANT CONTROL ON  Accounts TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  Auction TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  BaseVehicles TO ' + @UserName);
	EXEC ('GRANT CONTROL ON Bid TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  Bus TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  BusinessCar TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  FirmUsers TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  HeavyVehicles TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  LightVehicles TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  PrivateCar TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  PrivatUsers TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  Transactions TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  Trucks TO ' + @UserName);
	EXEC ('GRANT CONTROL ON  Users TO ' + @UserName);
	EXEC ('GRANT EXEC TO ' + @UserName);
END;


