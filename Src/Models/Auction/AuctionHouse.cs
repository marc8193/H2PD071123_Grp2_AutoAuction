using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Models
{
    public static class AuctionHouse
    {
        public static List<Auction> Auctions = new List<Auction>();
        
        public static uint SetForSale(Vehicle vehicle, ISeller seller, decimal miniumBid)
        {
            //TODO: A3 - SetForSale
            throw new NotImplementedException();
        }
        
        public static bool RecieveBid(IBuyer buyer, uint auctionID, decimal bid)
        {
            //TODO: A5 - RecieveBid
            throw new NotImplementedException();
        }

        public static bool AcceptBid(ISeller seller, uint auctionID)
        {
            //TODO: A6 - AcceptBid
            throw new NotImplementedException();
        }
        
        // The only purpose of regions is to provide an easy way to collapse code
        #region Search Methods 
        
        public static async Task<Auction> FindAuctionByID(uint auctionID)
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
