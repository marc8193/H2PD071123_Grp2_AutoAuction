using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Models
{
    public static class AuctionHouse
    {
        public static List<Auction> Auctions = new List<Auction>();
        
        public static Guid SetForSale(Vehicle vehicle, ISeller seller, decimal minimumBid)
        {
            var guid = Guid.NewGuid();

            // TODO: Insert vehicle, seller, minimumBid and guid into database, and use 'vehicle.GetType()' to select what table the vehicle should be added to.        

            return guid;
        }
        
        public static bool RecieveBid(IBuyer buyer, Guid auctionID, decimal bid)
        {
            //TODO: A5 - RecieveBid
            throw new NotImplementedException();
        }

        public static bool AcceptBid(ISeller seller, Guid auctionID)
        {
            //TODO: A6 - AcceptBid
            throw new NotImplementedException();
        }
        
        // The only purpose of regions is to provide an easy way to collapse code
        #region Search Methods 
        
        public static async Task<Auction> FindAuctionByID(Guid auctionID)
        {
            //TODO: A7 - FindAuctionByID
            throw new NotImplementedException();
        }
        
        public static async Task<List<Vehicle>> FindVehiclesByName(string searchWord)
        {
            //TODO: AS1 - FindVehiclesByName
            throw new NotImplementedException();
        }
        
        public static async Task<List<Vehicle>> FindVehiclesBynumberOfSeatss(int seats, bool hasToilet)
        {
            //TODO: AS2 - FindVehiclesBynumberOfSeatss
            throw new NotImplementedException();
        }
        
        public static async Task<List<Vehicle>> FindVehiclesByDriversLisence(double maxWeight)
        {
            //TODO: AS3 - FindVehiclesByDriversLisence
            throw new NotImplementedException();
        }
        
        public static async Task<List<Vehicle>> FindVehiclesByKmAndPrice(double maxKm, decimal maxPrice)
        {
            //TODO: AS4 - FindVehiclesByKmAndPrice
            throw new NotImplementedException();
        }

        public static async Task<List<ISeller>> FindSellersByZipcodeRange(uint zipCode, uint range)
        {
            //TODO: AS5 - FindSellersByZipcodeRange
            throw new NotImplementedException();
        }
        #endregion
    }
}
