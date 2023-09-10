using System;

namespace AutoAuctionProjekt.Models
{
    class Bus : HeavyVehicle
    {
        public Bus (
            string name,
            double km,
            string VIN,
            DateTime year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelType fuel,
            uint numberOfSeatss,
            IDimensions vehicleDimension,
            uint numberOfSleepingSpaces,
            bool hasToilet) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeatss, vehicleDimension)
        {
            this.NumberOfSleepingSpaces = numberOfSleepingSpaces;
            this.HasToilet = hasToilet;
            this.DriversLisence = this.HasTowbar ? DriversLisenceType.DE : DriversLisenceType.D;
            this.EngineSize = engineSize;            

            //TODO: V8 - Add to database and set ID
            throw new NotImplementedException();
        }

        public uint NumberOfSleepingSpaces { get; set; }
        public bool HasToilet { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Number of seats: {this.numberOfSeats}";
        }
    }
}
