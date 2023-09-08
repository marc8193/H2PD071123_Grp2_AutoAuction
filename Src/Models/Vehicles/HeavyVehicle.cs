﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public abstract class HeavyVehicle : Vehicle
    {
        public HeavyVehicle(
         string name,
         double km,
         string registrationNumber,
         ushort year,
         decimal newPrice,
         bool hasTowbar,
         double engineSize,
         double kmPerLiter,
         FuelTypeEnum fuelType,
         VehicleDimensionsStruct vehicleDimentions) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType)
        {
            this.VehicleDimensions = vehicleDimentions;
        }
        /// <summary>
        /// Vehicle dimentions proberty and struct
        /// </summary>
        public VehicleDimensionsStruct VehicleDimensions { get; set; }
        /// <summary>
        /// The dimensions of the vehicle i meters.
        /// </summary>
        public struct VehicleDimensionsStruct
        {
            public VehicleDimensionsStruct(double height, double weight, double length)
            {
                Height = height;
                Weight = weight;
                Length = length;
            }
            public double Height { get; }
            public double Weight { get; }
            public double Length { get; }
            public override string ToString() => $"(Height: {Height}, Weight: {Weight}, Depth: {Length})";
        }
        /// <summary>
        /// Returns the HeavyVehicle in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            //TODO: V6 - ToString for HeavyVehicle
            throw new NotImplementedException();
        }
    }
}