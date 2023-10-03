using System;

namespace AutoAuctionProjekt.Models
{
    public abstract class PersonalCar : Vehicle, IDimensions
    {
        protected PersonalCar(
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
            double length)
            : base(name, km, VIN, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuel, numberOfSeats)
        {
            this.Height = height;
            this.Width = width;
            this.Length = length;

            this.DriversLisence = DriversLisenceType.B;
        }
        
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }

        private double _engineSize;
        public sealed override double EngineSize
        {
            get { return _engineSize; }
            set
            {
                if (value < 0.7 || value > 10.0)
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
            return $"{base.ToString()}, Trunk Dimensions: W: {this.Width} H: {this.Height} L: {this.Length}";
        }
    }
}