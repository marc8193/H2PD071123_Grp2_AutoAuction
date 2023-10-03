using System;

namespace AutoAuctionProjekt.Models
{
    public class Bus : HeavyVehicle
    {
        public Bus (
            string name,
            double km,
            string VIN,
            int year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelType fuel,
            uint numberOfSeats,
            double height,
            double width,
            double depth,
            uint numberOfSleepingSpaces,
            bool hasToilet) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats, height, width, depth)
        {
            this.NumberOfSleepingSpaces = numberOfSleepingSpaces;
            this.HasToilet = hasToilet;
            this.DriversLisence = this.HasTowbar ? DriversLisenceType.DE : DriversLisenceType.D;
            this.EngineSize = engineSize;
        }

        public uint NumberOfSleepingSpaces { get; set; }
        public bool HasToilet { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Number of seats: {this.numberOfSeats}";
        }
    }
}
