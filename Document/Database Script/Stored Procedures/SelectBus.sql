USE auction
GO

CREATE PROCEDURE SelectBus (
	@BaseVehicleId int
)
AS
BEGIN
	SELECT
		B.Id AS BusId,
        B.HeavyVehicleId,
        B.Seats,
        B.Sleep,
        B.Toilet,

        --Heavy
        HV.Id AS HeavyId,
        HV.Height,
        HV.Weight,
        HV.Length,

        --Basic
        BV.Id AS BasicId,
        BV.LicensTypeId,
        BV.EnergyId,
        BV.Name,
        BV.Km,
        BV.Registration,
        BV.Year,
        BV.Price,
        BV.Towbar,
        BV.EngineSize,
        BV.KmPr
	FROM 
        Bus AS B
    INNER JOIN 
        dbo.HeavyVehicles AS HV ON B.HeavyVehicleId = HV.Id
    INNER JOIN 
        dbo.BaseVehicles AS BV ON HV.BaseVehicleId = BV.Id
    WHERE 
        BV.Id = @BaseVehicleId;
END;