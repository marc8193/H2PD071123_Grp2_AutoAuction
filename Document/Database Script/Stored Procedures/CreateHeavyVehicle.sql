USE auction
GO

CREATE PROCEDURE CreateHeavyVehicle (
	--For Base
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
	@BaseVehicleId int output,

	--For Heavy
	@Height decimal(18,0),
	@Weight decimal(18,0),
	@Length decimal(18,0),
	@HeavyVehicleId int output
) AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

			Exec CreateBaseVehicle @LicensTypeId, @EnergyId, @Name, @Km, @Registration, @Year, @Price, @Towbar, @EngineSize, @KmPr, @BaseVehicleId = @BaseVehicleId OUTPUT;

			INSERT INTO HeavyVehicles (BaseVehicleId, Height, Weight, Length)
			VALUES (@BaseVehicleId, @Height, @Weight, @Length)

			--Get newly inserted id
			SET @HeavyVehicleId = SCOPE_IDENTITY();

		COMMIT;
	END TRY
	BEGIN CATCH
		-- We can log Error here
		ROLLBACK;
		THROW;
	END CATCH
END;