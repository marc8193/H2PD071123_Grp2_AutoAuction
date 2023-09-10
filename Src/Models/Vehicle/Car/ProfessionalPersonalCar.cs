using System;

namespace AutoAuctionProjekt.Models
{
    public class ProfessionalPersonalCar : PersonalCar
    {
        public ProfessionalPersonalCar(
            string name,
            double km,
            string VIN,
            DateTime year,
            decimal newPrice,
            double engineSize,
            double kmPerLiter,
            FuelType fuel,
            uint numberOfSeats,
            IDimensions trunkDimension,
            bool hasSafetyBar,
            double loadCapacity)
            : base(name, km, VIN, year, newPrice, true, engineSize, kmPerLiter, fuel, numberOfSeats, trunkDimension)
        {
            this.DriversLisence = this.LoadCapacity > 750 ? DriversLisenceType.BE : DriversLisenceType.B;
         
            //TODO: V17 - Add to database and set ID
            throw new NotImplementedException();
        }

        public bool HasSafetyBar { get; set; }
        public double LoadCapacity { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}, Trunk Dimensions: {this.TrunkDimension}";
        }
    }
}
