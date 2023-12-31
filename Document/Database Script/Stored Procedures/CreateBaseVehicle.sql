USE auction
GO

CREATE PROCEDURE CreateBaseVehicle (
	@Name varchar(50),
	@Km int,
	@Registration varchar(7),
	@Year int,
	@Price decimal(18,0),
	@Towbar bit,
	@EngineSize decimal(18,0),
	@KmPr decimal(18,0),
	@LicensTypes varchar(2),
	@EnergyClass varchar(1),
	@Fuel varchar(20),

	@BaseVehicleId INT OUTPUT
) AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

			INSERT INTO BaseVehicles (Name, Km, Registration, Year, Price, Towbar, EngineSize, KmPr, LicensTypes, EnergyClass, Fuel)
			VALUES (@Name, @Km, @Registration, @Year, @Price, @Towbar, @EngineSize, @KmPr, @LicensTypes, @EnergyClass, @Fuel)

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