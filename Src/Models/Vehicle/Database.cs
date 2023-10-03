using System;
using AutoAuctionProjekt.Models;
using Microsoft.Data.SqlClient;

namespace H2PD071123_Grp2_AutoAuction;

public partial class Database
{
	public void SelectVehicle(uint baseVehicleId)
	{
		string queryString = 
		$@"DECLARE	@return_value int
		
		EXEC	@return_value = [dbo].[SelectVehicles]
		@BaseVehicleId = {baseVehicleId}

		SELECT @return_value = N'@return_value'";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			Console.WriteLine(reader["@return_value"]);
		}
	}

	public int InsertPrivatePersonalCar(PrivatePersonalCar car)
	{
		string queryString = 
		$@"DECLARE	@return_value int,
		@BaseVehicleId int,
		@LightVehicleId int,
		@VehicleId int

		EXEC [dbo].[CreatePrivateCar]
		@Name = N'{car.Name}',
		@Km = {car.Km},
		@Registration = N'{car.VIN}',
		@Year = {car.Year},
		@Price = {car.NewPrice},
		@Towbar = {car.HasTowbar},
		@EngineSize = {car.EngineSize},
		@KmPr = {car.KmPerLiter},
		@LicensTypes = {car.DriversLisence},
		@EnergyClass = {car.EnergyClass},
		@Fuel = {car.Fuel},
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = {car.Height},
		@Width = {car.Width},
		@Length = {car.Length},
		@LightVehicleId = @LightVehicleId OUTPUT,
		@IsoFix = {car.HasIsofixFittings},
		@VehicleId = @VehicleId OUTPUT

		SELECT @BaseVehicleId as N'@BaseVehicleId'";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@BaseVehicleId"]);
		}
	}

		public int InsertProfessionalPersonalCar(ProfessionalPersonalCar car)
	{
		string queryString = 
		$@"DECLARE	@return_value int,
		@BaseVehicleId int,
		@LightVehicleId int,
		@VehicleId int

		EXEC [dbo].[CreateBusinessCar]
		@Name = N'{car.Name}',
		@Km = {car.Km},
		@Registration = N'{car.VIN}',
		@Year = {car.Year},
		@Price = {car.NewPrice},
		@Towbar = {car.HasTowbar},
		@EngineSize = {car.EngineSize},
		@KmPr = {car.KmPerLiter},
		@LicensTypes = {car.DriversLisence},
		@EnergyClass = {car.EnergyClass},
		@Fuel = {car.Fuel},
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = {car.Height},
		@Width = {car.Width},
		@Length = {car.Length},
		@LightVehicleId = @LightVehicleId OUTPUT,
		@SafetyBar = {car.HasSafetyBar},
		@Capacity = {car.LoadCapacity},
		@VehicleId = @VehicleId OUTPUT

		SELECT @BaseVehicleId as N'@BaseVehicleId'";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@BaseVehicleId"]);
		}
	}

    public int InsertBus(Bus bus) 
    {
        string queryString = 
        $@"DECLARE @BaseVehicleId int,
		@HeavyVehicleId int,
		@VehicleId int
        
        EXEC [dbo].[CreateBus]
		@Name = N'{bus.Name}',
		@Km = {bus.Km},
		@Registration = N'{bus.VIN}',
		@Year = {bus.Year},
		@Price = {bus.NewPrice},
		@Towbar = {bus.HasTowbar},
		@EngineSize = {bus.EngineSize},
		@KmPr = {bus.KmPerLiter},
		@LicensTypes = {bus.DriversLisence},
		@EnergyClass = {bus.EnergyClass},
		@Fuel = {bus.Fuel},
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = {bus.Height},
		@Weight = {bus.Weight},
		@Length = {bus.Length},
		@HeavyVehicleId = @HeavyVehicleId OUTPUT,
		@Seats = {bus.numberOfSeats},
		@Sleep = {bus.NumberOfSleepingSpaces},
		@Toilet = {bus.HasToilet},
		@VehicleId = @VehicleId OUTPUT
				
		SELECT @BaseVehicleId as N'@BaseVehicleId'";

        SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@BaseVehicleId"]);
		}
    }

	public int InsertTruck(Truck truck)
	{
		string queryString = 
		$@"DECLARE	@return_value int,
		@BaseVehicleId int,
		@HeavyVehicleId int,
		@VehicleId int

		EXEC [dbo].[CreateTruck]
		@Name = N'{truck.Name}',
		@Km = {truck.Km},
		@Registration = N'{truck.VIN}',
		@Year = {truck.Year},
		@Price = {truck.NewPrice},
		@Towbar = {truck.HasTowbar},
		@EngineSize = {truck.EngineSize},
		@KmPr = {truck.KmPerLiter},
		@LicensTypes = {truck.DriversLisence},
		@EnergyClass = {truck.EnergyClass},
		@Fuel = {truck.Fuel},
		@BaseVehicleId = @BaseVehicleId OUTPUT,
		@Height = {truck.Height},
		@Weight = {truck.Weight},
		@Length = {truck.Length},
		@HeavyVehicleId = @HeavyVehicleId OUTPUT,
		@Capacity = {truck.LoadCapacity},
		@VehicleId = @VehicleId OUTPUT

		SELECT @BaseVehicleId as N'@BaseVehicleId'";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@BaseVehicleId"]);
		}
	}
}