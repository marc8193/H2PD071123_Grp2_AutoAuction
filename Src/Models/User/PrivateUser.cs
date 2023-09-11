using System;
using System.Diagnostics.Contracts;

namespace AutoAuctionProjekt.Models
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, string password, uint zipCode, uint cprNummer) : base(userName, password, zipCode)
        {
            //TODO: U10 - Set constructor
            //TODO: U11 - Add to database and set ID
            throw new NotImplementedException();
        }
        public  IBuyer Buyer { get; set; }
        public uint CPRNumber { get; set; }
        public uint Credit { get; set; }
        public uint CVrNumber { get; set; }
    }
}
