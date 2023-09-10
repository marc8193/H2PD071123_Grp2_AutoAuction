using System;

namespace AutoAuctionProjekt.Models
{
    public abstract class PersonalCar : Vehicle
    {
        protected PersonalCar(
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
            IDimensions trunkDimension)
            : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats)
        {
            this.TrunkDimension = trunkDimension;
            this.DriversLisence = DriversLisenceType.B;
        }
        
        public IDimensions TrunkDimension { get; set; }

        public sealed override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                if (value < 0.7 || value > 10.0)
                {
                    throw new IndexOutOfRangeException();
                } else
                {
                    EngineSize = value;
                }
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Trunk Dimensions: {this.TrunkDimension}";
        }
    }
}