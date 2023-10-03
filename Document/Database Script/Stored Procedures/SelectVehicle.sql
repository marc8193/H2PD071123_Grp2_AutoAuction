USE auction
GO

CREATE PROCEDURE SelectVehicles(
	@BaseVehicleId int
)
AS
BEGIN
	DECLARE 
		-- Id saved
		@Bus int,
		@Truck int,
		@Business int,
		@Privat int,

		-- Seps
		@FirstTable varchar(255),
		@SecTable varchar(255),
		@Id int;

	SELECT 
		@Bus = G.BusId,
		@Truck = G.TruckId,
		@Business = G.BusinessCarId,
		@Privat = G.PrivateCarId
		FROM (
			SELECT
				b.Id AS BusId,
				t.Id AS TruckId,
				bc.Id AS BusinessCarId,
				pc.Id AS PrivateCarId
			FROM
				dbo.BaseVehicles bv
			LEFT JOIN
				dbo.HeavyVehicles hv ON bv.Id = hv.BaseVehicleId
			LEFT JOIN
				Bus b ON hv.Id = b.HeavyVehicleId
			LEFT JOIN
				Trucks t ON hv.Id = t.HeavyVehicleId
			LEFT JOIN
				dbo.LightVehicles lv ON bv.Id = lv.BaseVehicleId
			LEFT JOIN
				BusinessCar bc ON lv.Id = bc.LightVehicleId
			LEFT JOIN
				PrivateCar pc ON lv.Id = pc.LightVehicleId
			WHERE
				bv.Id = @BaseVehicleId
		) AS G
	IF @Bus IS NOT NULL 
		BEGIN
			SET @FirstTable = 'Bus'
			SET @SecTable = 'HeavyVehicles'
			SET @Id = @Bus;
			SELECT @Bus AS BusId
		END
	ELSE IF @Truck IS NOT NULL
		BEGIN
			SET @FirstTable = 'Truck'
			SET @SecTable = 'HeavyVehicles'
			SET @Id = @Truck;
			SELECT @Truck AS TrickId
		END
	ELSE IF @Business IS NOT NULL
		BEGIN
			SET @FirstTable = 'BusinessCar'
			SET @SecTable = 'LightVehicles'
			SET @Id = @Business;
			SELECT @Business AS BusinessCarId
		END
	ELSE IF @Privat IS NOT NULL
		BEGIN
			SET @FirstTable = 'PrivateCar'
			SET @SecTable = 'LightVehicles'
			SET @Id = @Privat;
			SELECT @Privat AS PrivatCarId
		END;

		EXEC SelectVehicleData @FirstTable, @SecTable, @Id
END;