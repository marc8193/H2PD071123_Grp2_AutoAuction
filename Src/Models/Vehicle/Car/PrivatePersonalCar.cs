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
            double height,
            double width,
            double length,
            bool hasIsofixFittings)
            : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, numberOfSeats, height, width, length)
        {
            this.HasIsofixFittings = hasIsofixFittings;
        }

        public bool HasIsofixFittings { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} - Isofix: {this.HasIsofixFittings}";
        }
    }
}
