using System;

namespace AutoAuctionProjekt.Models
{
    public class ProfessionalPersonalCar : PersonalCar
    {
        public ProfessionalPersonalCar(
            string name,
            double km,
            string VIN,
            int year,
            decimal newPrice,
            double engineSize,
            double kmPerLiter,
            FuelType fuel,
            uint numberOfSeats,
            double height,
            double width,
            double length,
            bool hasSafetyBar,
            double loadCapacity)
            : base(name, km, VIN, year, newPrice, true, engineSize, kmPerLiter, fuel, numberOfSeats, height, width, length)
        {
            this.LoadCapacity = loadCapacity;
            this.DriversLisence = this.LoadCapacity > 750 ? DriversLisenceType.BE : DriversLisenceType.B;
            this.HasSafetyBar = hasSafetyBar;
        }

        public bool HasSafetyBar { get; set; }
        public double LoadCapacity { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Loadcapacity: {this.LoadCapacity}";
        }
    }
}
