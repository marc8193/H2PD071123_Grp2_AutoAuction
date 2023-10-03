﻿using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using H2PD071123_Grp2_AutoAuction;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

namespace AutoAuctionProjekt.Models
{

    public abstract class User
    {
        //Username, Password og ZipCode sættes op
        protected User(string userName, string password, uint zipCode)
        {
            this.UserName = userName;
            this.Password = password;
            this.Zipcode = zipCode;

            this.UserName = userName;
            this.Password = password;
            this.Zipcode = zipCode;
        }
       
        public string UserName { get; set; }
        public int DbId { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public uint Zipcode { get; set; }

        //private bool ValidateLogin(string loginUserName, string loginPassword)
        //{

        //    bool grantAccess = true;
        //    bool denyAccess = false;
        //    //Hent Fra database
        //    var DB = Database.Instance;
        //     DB.InsertUser(DbId, UserName, Password, CVRNumber, Balance, zipCode, Credit);

        //    //U6, Lav user i database og brug den til authentication
        //}
        public override string ToString()
        {
            return @$"User - ({this.DbId}): Username: {this.UserName}, 
            Balance: {this.Balance}, Zipcode: {this.Zipcode}";
        }
    }

}
