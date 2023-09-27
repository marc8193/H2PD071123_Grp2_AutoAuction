USE auction
GO

CREATE PROCEDURE CreateBaseVehicle (
	@LicensTypeId int,
	@EnergyId int,
	@Name varchar(50),
	@Km int,
	@Registration varchar(7),
	@Year int,
	@Price decimal(18,0),
	@Towbar bit,
	@EngineSize decimal(18,0),
	@KmPr decimal(18,0),

	@BaseVehicleId INT OUTPUT
) AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

			INSERT INTO BaseVehicles (LicensTypeId, EnergyId, Name, Km, Registration, Year, Price, Towbar, EngineSize, KmPr)
			VALUES (@LicensTypeId, @EnergyId, @Name, @Km, @Registration, @Year, @Price, @Towbar, @EngineSize, @KmPr)

			--Get newly inserted id
			SET @BaseVehicleId = SCOPE_IDENTITY();

		COMMIT;
	END TRY
	BEGIN CATCH
		-- We can log Error here
		ROLLBACK;
		THROW;
	END CATCH
END;