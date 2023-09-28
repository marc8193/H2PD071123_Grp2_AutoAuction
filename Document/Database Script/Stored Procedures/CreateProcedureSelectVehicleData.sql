CREATE PROCEDURE SelectVehicleData
    @FirstTable VARCHAR(255),
    @SecTable VARCHAR(255),
    @Id INT
AS
BEGIN
    DECLARE @SQL NVARCHAR(600)

    SET @SQL = 'SELECT * FROM ' + QUOTENAME(@FirstTable) + ' WHERE Id = @Id'

    EXEC sp_executesql @SQL, N'@Id INT', @Id
END
