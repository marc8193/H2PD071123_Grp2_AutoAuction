using System;
using System.Diagnostics.Contracts;

namespace AutoAuctionProjekt.Models
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, string password, uint zipCode, uint cprNummer) : base(userName, password, zipCode)
        {
            //TODO: U11 - Add to database and set ID
            throw new NotImplementedException();
        }
        public IBuyer Buyer { get; set; }
        public uint CPRNumber { get; set; }
        public uint Credit { get; set; }
       

        public override string ToString()
        {
            return @$"User - ({this.ID}): Name: {this.UserName}, Password: {this.Password},
                    Zipcode: {this.ZipCode}";
        }
    }
}
