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
        }
        
        public IDimensions TrunkDimension { get; set; }

        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                EngineSize = value;
                
                //TODO: V13 - EngineSize: must be between 0.7 and 10.0 L or cast an out of range exection.
                throw new NotImplementedException();
            }
        }
        public override string ToString()
        {
            //TODO: V15 - ToString for PersonalCar
            throw new NotImplementedException();
        }
    }
}