using System;

namespace AutoAuctionProjekt.Models
{
    public class Auction
    {
        public Auction(Vehicle vehicle, User seller, decimal minimumPrice)
        {
            this.Vehicle = vehicle;
            this.Seller = seller;
            this.MinimumPrice = minimumPrice;
            
            //TODO: A2 - Add to database and set ID
            throw new NotImplementedException();
        }
        
        public uint ID { get; private set; }
        public decimal MinimumPrice { get; set; }
        public decimal StandingBid { get; set; }
        internal Vehicle Vehicle { get; set; }
        internal User Seller { get; set; }
        internal User Buyer { get; set; }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}