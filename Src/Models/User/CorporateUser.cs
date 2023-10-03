using System;

namespace AutoAuctionProjekt.Models
{
    public class CorporateUser : User
    {
        public CorporateUser(string userName, string password, uint zipCode, uint cvrNummer, decimal credit) : base(userName, password, zipCode)
        {
            this.CVRNumber = cvrNummer;
            this.Credit = credit;
        }
        public uint CVRNumber { get; set; }
        public decimal Credit { get; set; }

        public override string ToString()
        {
            return @$"User - ({this.DbId}): Username: {this.UserName}, 
            Cvr nummer: {this.CVRNumber}, Credit: {this.Credit}";
        }
    }
}