using System;
using System.Runtime.Intrinsics.Arm;

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
         double width,
         double depth) : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }
        
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

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
            return $"{base.ToString()}, Dimensions: H: {this.Height}, W: {this.Width}, D: {this.Depth}";
        }
    }
}
