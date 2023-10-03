using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using H2PD071123_Grp2_AutoAuction;

namespace AutoAuctionProjekt.Models
{
    public static class AuctionHouse
    {
        public static List<Auction> Auctions = new List<Auction>();
        
        public static int SetForSale(Vehicle vehicle, int userId, decimal minimumBid)
        {
            // TODO: Insert vehicle, seller, minimumBid into database, and use 'vehicle.GetType().Name' to select what stored procedure should be used.
            var db = Database.Instance;
            int baseVehicleId = 0;

            switch (vehicle.GetType().Name)
            {
                case "PrivatePersonalCar":
                    baseVehicleId = db.InsertPrivatePersonalCar((PrivatePersonalCar) vehicle);

                    Console.WriteLine($"PrivatePersonalCar - Id: {baseVehicleId}");

                    break;

                case "ProfessionalPersonalCar":
                    baseVehicleId = db.InsertProfessionalPersonalCar((ProfessionalPersonalCar) vehicle);

                    Console.WriteLine($"ProfessionalPersonalCar - Id: {baseVehicleId}");

                    break;
                
                case "Bus":
                    baseVehicleId = db.InsertBus((Bus) vehicle);

                    Console.WriteLine($"Bus - Id: {baseVehicleId}");

                    break;
                
                case "Truck":
                    baseVehicleId = db.InsertTruck((Truck) vehicle);

                    Console.WriteLine($"Truck - Id: {baseVehicleId}");

                    break;
            }


            return db.SetForSale(baseVehicleId, userId, minimumBid);
        }
        
        public static bool RecieveBid(User buyer, int auctionID, decimal bid)
        {
            //TODO: A5 - RecieveBid
            throw new NotImplementedException();
        }

        public static bool AcceptBid(User seller, int auctionID)
        {
            //TODO: A6 - AcceptBid
            throw new NotImplementedException();
        }
        
        // The only purpose of regions is to provide an easy way to collapse code
        #region Search Methods
        
        // public static async Task<Auction> FindAuctionByID(int auctionID)
        // {
        //     //TODO: A7 - FindAuctionByID
        //     throw new NotImplementedException();
        // }
        
        // public static async Task<List<Vehicle>> FindVehiclesByName(string searchWord)
        // {
        //     //TODO: AS1 - FindVehiclesByName
        //     throw new NotImplementedException();
        // }
        
        // public static async Task<List<Vehicle>> FindVehiclesBynumberOfSeatss(int seats, bool hasToilet)
        // {
        //     //TODO: AS2 - FindVehiclesBynumberOfSeatss
        //     throw new NotImplementedException();
        // }
        
        // public static async Task<List<Vehicle>> FindVehiclesByDriversLisence(double maxWeight)
        // {
        //     //TODO: AS3 - FindVehiclesByDriversLisence
        //     throw new NotImplementedException();
        // }
        
        // public static async Task<List<Vehicle>> FindVehiclesByKmAndPrice(double maxKm, decimal maxPrice)
        // {
        //     //TODO: AS4 - FindVehiclesByKmAndPrice
        //     throw new NotImplementedException();
        // }

        // public static async Task<List<User>> FindSellersByZipcodeRange(uint zipCode, uint range)
        // {
        //     //TODO: AS5 - FindSellersByZipcodeRange
        //     throw new NotImplementedException();
        // }
        #endregion
    }
}
