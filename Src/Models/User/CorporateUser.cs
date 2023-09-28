using System;

namespace AutoAuctionProjekt.Models
{
    public class CorporateUser : User 
    {
        public CorporateUser(string userName, string password, uint zipCode, uint cvrNummer, decimal credit) : base(userName, password, zipCode)
        {

            //TODO: U8 - Add to database and set ID
            throw new NotImplementedException();
        }
        public ISeller Seller { get; set; }
        public uint CVRNumber { get; set; }
        public decimal Credit { get; set; }

        public override string ToString()
        {
            return @$"UserName ({this.UserName}): Password: {this.Password}, ZipCode: {this.ZipCode},
                    CVRNumber: {this.CVRNumber}, Credit: {this.Credit}";
        }
    }
}
