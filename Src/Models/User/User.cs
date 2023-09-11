﻿using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace AutoAuctionProjekt.Models
{
    //TODO: U4 - Implement interfaces
    public abstract class User
    {
        //Username, Password og ZipCode sættes op
        protected User(string userName, string password, uint zipCode)
        {
             this.UserName = userName;
            this.Password = password;
            this.ZipCode = zipCode;
           
//skal denne encryption blive? Skal serveren ikke styre det? spørg simon.
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            PasswordHash = result;

            throw new NotImplementedException();

            //TODO: U2 - Initalize det fra database i constructor


        }
        public string UserName  { get; set; }
        public string Password {  get; set; }
        public uint ZipCode { get; set; }
        public uint ID { get; private set; }

        private byte[] PasswordHash { get; set; }

        private bool ValidateLogin(string loginUserName, string loginPassword)
        {
            //TODO: U5 - Implement the rest of validation for password and user name

            //   HashAlgorithm sha = SHA256.Create(); // HashAlgorithm object for making hash computations.
            //  byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(loginPassword)); // Encodes password to hash as a Byte array.

            //  return PasswordHash == result;

            //Indsættes med at tilladelse i GUIen
            bool grantAccess = true;
            bool denyAccess = false;
            //Hent Fra database
            string DBUserName = "navn";
                string DBPassword = "password";

            if (loginUserName == DBUserName && loginPassword == DBPassword) {
                return grantAccess;
            }
            return denyAccess;

            //U5, Hent fra database
            //U6, Lav user i database og brug den til authentication







        }



        public override string ToString()
        {
           return @$"User - ({this.ID}): Name: {this.UserName}, Password: {this.Password},
                    Zipcode: {this.ZipCode}";
        }
    }

}
