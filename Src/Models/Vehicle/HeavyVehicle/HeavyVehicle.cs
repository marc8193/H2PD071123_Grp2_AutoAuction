using System;

namespace AutoAuctionProjekt.Models
{
    public abstract class HeavyVehicle : Vehicle, IDimensions
    {
        public HeavyVehicle(
         string name,
         double km,
         string VIN,
         int year,
         decimal newPrice,
         bool hasTowbar,
         double engineSize,
         double kmPerLiter,
         FuelType fuel,
         uint numberOfSeats,
         double height,
         double weight,
         double length) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats)
        {
            this.Height = height;
            this.Length = length;
            this.Weight = weight;
        }
        
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double Weight { get; set; }

        private double _engineSize;
        public sealed override double EngineSize
        {
            get { return _engineSize; }
            set
            {
                if (value < 4.2 || value > 15.0)
                {
                    throw new ArgumentOutOfRangeException();
                } else
                {
                    _engineSize = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Dimensions: H: {this.Height}, D: {this.Length}";
        }
    }
}
