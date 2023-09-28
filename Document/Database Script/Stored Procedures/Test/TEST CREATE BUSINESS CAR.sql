USE [auction]
GO

DECLARE	@return_value int,
		@BaseVehicleId int,
		@LightVehicleId int,
		@VehicleId int

EXEC	@return_value = [dbo].[CreateBusinessCar]
		@Name = N'Hey',
		@Km = 200,
		@Registration = N'30A',
		@Year = 2032,
		@Price = 200,
		@Towbar = 0,
		@EngineSize = 2,
		@KmPr = 20,
		@LicensTypes = N'1',
		@EnergyClass = N'1',
		@Fuel = N'Benzin',
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = 20,
		@Width = 20,
		@Length = 20,
		@LightVehicleId = @LightVehicleId OUTPUT,
		@SafetyBar = 0,
		@Capacity = 20,
		@VehicleId = @VehicleId OUTPUT

SELECT	@BaseVehicleId as N'@BaseVehicleId',
		@LightVehicleId as N'@LightVehicleId',
		@VehicleId as N'@VehicleId'

SELECT	'Return Value' = @return_value

GO
