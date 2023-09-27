using System;

namespace AutoAuctionProjekt.Models
{
    public class PrivatePersonalCar : PersonalCar
    {
        public PrivatePersonalCar(
            string name,
            double km,
            string VIN,
            int year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelType fuelType,
            uint numberOfSeats,
            IDimensions trunkDimension,
            bool hasIsofixFittings)
            : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, numberOfSeats, trunkDimension)
        {
            //TODO: V20 - Add to database and set ID
            throw new NotImplementedException();
        }

        public bool HasIsofixFittings { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Trunk Dimensions: {this.TrunkDimension}";
        }
    }
}
