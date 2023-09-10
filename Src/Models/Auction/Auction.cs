using System;

namespace AutoAuctionProjekt.Models
{
    public class Auction
    {
        public Auction(Vehicle vehicle, ISeller seller, decimal minimumPrice)
        {
            //TODO: A1 - Set constructor
            //TODO: A2 - Add to database and set ID
            throw new NotImplementedException();
        }
        
        public uint ID { get; private set; }
        public decimal MinimumPrice { get; set; }
        public decimal StandingBid { get; set; }
        internal Vehicle Vehicle { get; set; }
        internal ISeller Seller { get; set; }
        internal IBuyer Buyer { get; set; }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}