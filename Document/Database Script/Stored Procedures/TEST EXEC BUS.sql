USE [auction]
GO



DECLARE	@return_value int,
		@BaseVehicleId int,
		@HeavyVehicleId int,
		@VehicleId int

EXEC	@return_value = [dbo].[CreateBus]
		@LicensTypeId = 1,
		@EnergyId = 1,
		@Name = N'Haraldur',
		@Km = 20,
		@Registration = N'Ha2088',
		@Year = 2023,
		@Price = 2000,
		@Towbar = 0,
		@EngineSize = 2,
		@KmPr = 20,
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = 203,
		@Weight = 33,
		@Length = 433,
		@HeavyVehicleId = @HeavyVehicleId OUTPUT,
		@Seats = 2,
		@Sleep = 1,
		@Toilet = 1,
		@VehicleId = @VehicleId OUTPUT

SELECT	@BaseVehicleId as N'@BaseVehicleId',
		@HeavyVehicleId as N'@HeavyVehicleId'

SELECT	'Return Value' = @return_value

GO
