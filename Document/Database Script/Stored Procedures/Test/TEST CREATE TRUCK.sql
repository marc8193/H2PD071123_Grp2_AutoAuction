USE [auction]
GO

DECLARE	@return_value int,
		@BaseVehicleId int,
		@HeavyVehicleId int,
		@VehicleId int

EXEC	@return_value = [dbo].[CreateTruck]
		@LicensTypeId = 1,
		@EnergyId = 1,
		@Name = N'Test Bus',
		@Km = 200,
		@Registration = N'H12A',
		@Year = 2023,
		@Price = 200,
		@Towbar = 0,
		@EngineSize = 2,
		@KmPr = 20,
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = 20,
		@Weight = 20,
		@Length = 20,
		@HeavyVehicleId = @HeavyVehicleId OUTPUT,
		@Capacity = 20,
		@VehicleId = @VehicleId OUTPUT

SELECT	@BaseVehicleId as N'@BaseVehicleId',
		@HeavyVehicleId as N'@HeavyVehicleId',
		@VehicleId as N'@VehicleId'

SELECT	'Return Value' = @return_value

GO
