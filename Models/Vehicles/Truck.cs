using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    class Truck : HeavyVehicle
    {
        public Truck(
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            VehicleDimensionsStruct vehicleDimentions,
            //V10
            string height,
            string weight,
            string length,

            double loadCapacity) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions)
        {
            //TODO: V10 - Constructor for Truck, DriversLisence should be CE if the truck has a towbar, otherwise it should be C
            this.Height = height;
            this.Weight = weight;
            this.Length = length;
            this.LoadCapacity = loadCapacity;



            //TODO: V11 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
        /// <returns>The size the the engine as a double</returns>
        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                //TODO: V10 - EngineSize must be between 4.2 and 15.0 L or cast an out of range exection.
                throw new NotImplementedException();

                EngineSize = value;
            }
        }
        /// <summary>
        /// Load Capacity field and proberty
        /// </summary>
        public double LoadCapacity { get; set; }

        //V10
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public double LoadCapacity { get; set; }

        public bool hasTowbar {
            get { return DriversLisence };
            set
            {
                if (hasTowbar == true)
                {
                    DriversLisence = DriversLisenceEnum.CE;
                }
                else
                {
                    DriversLisence = DriversLisenceEnum.C;
                }
            };
        }

        public double engineSize
        {
            get { return engineSize; }
            set
            {
                if (engineSize >= 4.2 && engineSize <= 15.0)
                {
                    engineSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Engine size must be between 4.2 and 15.0 L");
                }
            }
        }








        /// <summary>
        /// Returns the Truck in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            //TODO: V12 - ToString for Truck 
            throw new NotImplementedException();
        }
    }
}
