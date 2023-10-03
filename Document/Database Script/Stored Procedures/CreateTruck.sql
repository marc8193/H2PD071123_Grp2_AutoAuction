USE auction
GO

CREATE PROCEDURE CreateTruck (
--For Base
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
	@BaseVehicleId int output,

	--For Heavy
	@Height decimal(18,0),
	@Weight decimal(18,0),
	@Length decimal(18,0),
	@HeavyVehicleId int output,

	--For Bus
	@Capacity decimal(18,0),
	@VehicleId int output
) 
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

			Exec CreateHeavyVehicle @Name, @Km, @Registration, @Year, @Price, @Towbar, @EngineSize, @KmPr, @LicensTypes, @EnergyClass, @Fuel, @BaseVehicleId = @BaseVehicleId OUTPUT, @Height = @Height, @Weight = @Weight, @Length = @Length, @HeavyVehicleId = @HeavyVehicleId OUTPUT;
		
			INSERT INTO Trucks (HeavyVehicleId, Capacity)
			VALUES (@HeavyVehicleId, @Capacity)

			SET @VehicleId = SCOPE_IDENTITY();
		
		COMMIT;
	END TRY
	BEGIN CATCH
		-- We can log Error here
		ROLLBACK;
		THROW;
	END CATCH
END;