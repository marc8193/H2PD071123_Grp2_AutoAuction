CREATE PROCEDURE SelectVehicleData
    @FirstTable VARCHAR(255),
    @SecTable VARCHAR(255),
    @Id INT
AS
BEGIN

    DECLARE @SQL NVARCHAR(600)

	--Dynamic SQL
	SET @SQL = 'SELECT * FROM ' + QUOTENAME(@FirstTable) + ' AS B ' +
	'INNER JOIN ' +
		QUOTENAME(@SecTable) + ' AS HV ON B.' +
		CASE WHEN @SecTable = 'LightVehicles' THEN 'LightVehicleId' ELSE 'HeavyVehicleId' END +
		' = HV.Id ' +
	'INNER JOIN ' +
		'dbo.BaseVehicles AS BV ON HV.BaseVehicleId = BV.Id ' +
	'WHERE B.Id = ' + CAST(@Id AS NVARCHAR(20)) + ';'

    EXEC sp_executesql @SQL
END