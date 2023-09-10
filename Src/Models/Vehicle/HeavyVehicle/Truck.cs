using System;

namespace AutoAuctionProjekt.Models
{
    class Truck : HeavyVehicle
    {
        public Truck(
            string name,
            double km,
            string VIN,
            DateTime year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelType fuel,
            uint numberOfSeats,
            IDimensions vehicleDimension,
            double LoadCapacity) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats, vehicleDimension)
        {
            this.DriversLisence = this.HasTowbar ? DriversLisenceType.CE : DriversLisenceType.C;

            //TODO: V11 - Add to database and set ID
            throw new NotImplementedException();
        }
        
        public double LoadCapacity { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Number of seats: {this.numberOfSeats}";
        }
    }
}
