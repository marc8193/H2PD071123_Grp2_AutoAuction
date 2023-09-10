using System;

namespace AutoAuctionProjekt.Models
{
    public abstract class HeavyVehicle : Vehicle
    {
        public HeavyVehicle(
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
         IDimensions vehicleDimension) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats)
        {
            this.VehicleDimension = vehicleDimension;
        }
        
        public IDimensions VehicleDimension { get; set; }

        public sealed override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                if (value < 4.2 || value > 15.0)
                {
                    throw new ArgumentOutOfRangeException();
                } else
                {
                    EngineSize = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Dimensions: {this.VehicleDimension}";
        }
    }
}
