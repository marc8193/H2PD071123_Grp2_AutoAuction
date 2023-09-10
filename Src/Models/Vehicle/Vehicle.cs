﻿using System;
using System.Text;

namespace AutoAuctionProjekt.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(string name,
            double km,
            string VIN,
            DateTime year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelType fuel,
            uint numberOfSeats)
        {
            this.Name = name;
            this.Km = km;
            this.VIN = VIN;
            this.Year = year;
            this.NewPrice = newPrice;
            this.HasTowbar = hasTowbar;
            this.EngineSize = engineSize;
            this.KmPerLiter = kmPerLiter;
            this.Fuel = fuel;
            this.numberOfSeats = numberOfSeats;

            //TODO: V2 - Add to database and set ID
        }
        
        public uint ID { get; private set; }
        public string Name { get; set; }
        public double Km { get; set; }
        public string VIN { get; set; } // Vehicle identification number
        public DateTime Year { get; set; }
        public decimal NewPrice { get; set; }
        public bool HasTowbar { get; set; }
        public virtual double EngineSize { get; set; }
        public double KmPerLiter { get; set; }
        public DriversLisenceType DriversLisence { get; set; }
        public enum DriversLisenceType
        {
            A,
            B,
            C,
            D,
            BE,
            CE,
            DE
        }
        public FuelType Fuel { get; set; }
        public enum FuelType
        {
            Diesel,
            Petrol,
            Electric,
            Hydrogen,
        }
        public uint numberOfSeats { get; set; }

        public EnergyType EnergyClass { get { return EnergyClass; } set => GetEnergyClass(); }
        public enum EnergyType
        {
            A,
            B,
            C,
            D
        }
        private EnergyType GetEnergyClass()
        {
            if (this.Year.Year < new DateTime(2010, 1, 1).Year)
            {
                switch (this.Fuel)
                {
                    case FuelType.Electric:
                    case FuelType.Hydrogen:
                        return EnergyType.A;

                    case FuelType.Diesel:
                        switch (KmPerLiter)
                        {
                            case var km when km >= 23:
                                return EnergyType.A;
                            case var km when km >= 18:
                                return EnergyType.B;
                            case var km when km >= 13:
                                return EnergyType.C;
                            default:
                                return EnergyType.D;
                        }

                    case FuelType.Petrol:
                        switch (KmPerLiter)
                        {
                            case var km when km >= 18:
                                return EnergyType.A;
                            case var km when km >= 14:
                                return EnergyType.B;
                            case var km when km >= 10:
                                return EnergyType.C;
                            default:
                                return EnergyType.D;
                        }
                }
            }
            else
            {
                switch (this.Fuel)
                {
                    
                    case FuelType.Diesel:
                        switch (KmPerLiter)
                        {
                            case var km when km >= 25:
                                return EnergyType.A;
                            case var km when km >= 20:
                                return EnergyType.B;
                            case var km when km >= 13:
                                return EnergyType.C;
                            default:
                                return EnergyType.D;
                        }

                    case FuelType.Petrol:    
                        switch (KmPerLiter)
                        {
                            case var km when km >= 20:
                                return EnergyType.A;
                            case var km when km >= 16:
                                return EnergyType.B;
                            case var km when km >= 12:
                                return EnergyType.C;
                            default:
                                return EnergyType.D;
                        }
                }
            }
                    
            return EnergyType.D;
        }
        public new virtual string ToString()
        {
            string objStr;

            objStr = @$"Vehicle - ({this.ID}): Name: {this.Name}, Km: {this.Km},
                        Year: {this.Year}, New Price: {this.NewPrice}";

            return objStr;
        }
    }
}