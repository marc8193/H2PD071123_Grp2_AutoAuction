using System;

namespace AutoAuctionProjekt.Models
{
    public class PrivatePersonalCar : PersonalCar
    {
        public PrivatePersonalCar(
            string name,
            double km,
            string VIN,
            DateTime year,
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
            //TODO: V19 - PrivatePersonalCar constructor. DriversLicense should be 'B'
            //TODO: V20 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Isofix Fittings proberty
        /// </summary>
        public bool HasIsofixFittings { get; set; }
        /// <summary>
        /// Returns the PrivatePersonalCar in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            //TODO: V21 - ToString for PrivatePersonalCar
            throw new NotImplementedException();
        }
    }
}
