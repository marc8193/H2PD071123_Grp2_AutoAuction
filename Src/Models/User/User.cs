﻿using System;
using System.Text;
using System.Security.Cryptography;

namespace AutoAuctionProjekt.Models
{
    //TODO: U4 - Implement interfaces
    public abstract class User : IBuyer, ISeller
    {
        protected User(string userName, string password, uint zipCode)
        {
            this.UserName = userName;
            this.Password = password;
            this.Zipcode = zipCode;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public uint Zipcode { get; set; }
        public uint ID { get; private set; }

        public string ReceiveBidNodification(string message)
        {
            throw new NotImplementedException();
        }
        private bool ValidateLogin(string loginUserName, string loginPassword)
        {
            //TODO: U5 - Implement the rest of validation for password and user name

            throw new NotImplementedException();
        }

        //TODO: U4 - Implement interface proberties and methods.

        public override string ToString()
        {
            return @$"User - ({this.ID}): Username: {this.UserName}, 
            Balance: {this.Balance}, Zipcode: {this.Zipcode}";
        }
    }
}
