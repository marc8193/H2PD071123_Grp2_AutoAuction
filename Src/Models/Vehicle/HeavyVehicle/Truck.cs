using System;

namespace AutoAuctionProjekt.Models
{
    class Truck : HeavyVehicle
    {
        public Truck(
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
            double LoadCapacity) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats, height, width, depth)
        {
            this.DriversLisence = this.HasTowbar ? DriversLisenceType.CE : DriversLisenceType.C;

            //TODO: V11 - Add to database and set ID
        }
        
        public double LoadCapacity { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Number of seats: {this.numberOfSeats}";
        }
    }
}
