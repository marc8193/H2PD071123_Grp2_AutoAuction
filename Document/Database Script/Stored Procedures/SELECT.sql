DECLARE 
	@BaseVehicleId INT = 9,

	-- Id gemt
	@Bus int,
	@Truck int,
	@Business int,
	@Privat int,

	-- Steps
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
			--bv.Id AS BaseVehicleId,
			--hv.Id AS HeavyVehicleId,
			b.Id AS BusId,
			t.Id AS TruckId,
			--lv.Id AS LightVehicleId,
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
		SET @SecTable = 'dbo.HeavyVehicle'
		SET @Id = @Bus;
		SELECT @Bus AS BusId
	END
ELSE IF @Truck IS NOT NULL
	BEGIN
		SET @FirstTable = 'dbo.Truck'
		SET @SecTable = 'dbo.HeavyVehicle'
		SET @Id = @Truck;
		SELECT @Truck AS TrickId
	END
ELSE IF @Business IS NOT NULL
	BEGIN
		SET @FirstTable = 'dbo.BusinessCar'
		SET @SecTable = 'dbo.LightVehicles'
		SET @Id = @Business;
		SELECT @Business AS BusinessCarId
	END
ELSE IF @Privat IS NOT NULL
	BEGIN
		SET @FirstTable = 'dbo.PrivarCar'
		SET @SecTable = 'dbo.LightVehicles'
		SET @Id = @Privat;
		SELECT @Privat AS PrivatCarId
	END

	EXEC SelectVehicleData @FirstTable, @SecTable, @Id
--Procedure to select data according to @table
--EXEC 