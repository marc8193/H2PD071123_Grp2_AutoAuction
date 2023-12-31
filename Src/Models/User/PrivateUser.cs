﻿using System;

namespace AutoAuctionProjekt.Models
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, string password, uint zipCode, uint cprNummer) : base(userName, password, zipCode)
        {
            this.CPRNumber = cprNummer;
        }
        public uint CPRNumber { get; set; }

        public override string ToString()
        {
            return @$"User - ({this.DbId}): Username: {this.UserName}, 
            Cpr nummer: {this.CPRNumber}";
        }
    }
}
