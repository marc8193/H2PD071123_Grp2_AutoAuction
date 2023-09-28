USE auction
Go

DECLARE @BaseVehicleId INT = 1; -- Replace with the actual BaseVehicleId you have

SELECT
    bv.Id AS BaseVehicleId,
    hv.Id AS HeavyVehicleId,
    b.Id AS BusId,
    t.Id AS TruckId,
    lv.Id AS LightVehicleId,
    bc.Id AS BusinessCarId,
    pc.Id AS PrivateCarId
FROM
    dbo.BaseVehicles bv

--Heavy
LEFT JOIN
    dbo.HeavyVehicles hv ON bv.Id = hv.BaseVehicleId
LEFT JOIN
    Bus b ON hv.Id = b.HeavyVehicleId
LEFT JOIN
    Trucks t ON hv.Id = t.HeavyVehicleId

--Light
LEFT JOIN
    dbo.LightVehicles lv ON bv.Id = lv.BaseVehicleId
LEFT JOIN
    BusinessCar bc ON lv.Id = bc.LightVehicleId
LEFT JOIN
    PrivateCar pc ON lv.Id = pc.LightVehicleId
WHERE
    bv.Id = @BaseVehicleId;
