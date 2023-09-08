﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class ProfessionalPersonalCar : PersonalCar
    {
        public ProfessionalPersonalCar(
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            ushort numberOfSeat,
            TrunkDimentionsStruct trunkDimentions,
            bool hasSafetyBar,
            double loadCapacity)
            : base(name, km, registrationNumber, year, newPrice, true, engineSize, kmPerLiter, fuelType, numberOfSeat, trunkDimentions)
        {
            //TODO: V16 - ProfessionalPersonalCar constructor. DriversLicense should be 'B' if load capasity is below 750 otherwise it should be 'BE'
            //TODO: V17 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Safety Bar proberty
        /// </summary>
        public bool HasSafetyBar { get; set; }
        /// <summary>
        /// Load Capacity proberty
        /// </summary>
        public double LoadCapacity { get; set; }
        /// <summary>
        /// Returns the ProfessionalPersonalCar in a string with relivant information.
        /// </summary>
        /// <returns>The Veihcle as a string</returns>
        public override string ToString()
        {
            //TODO: V18 - ToString for ProfessionalPersonalCar 
            throw new NotImplementedException();
        }
    }
}