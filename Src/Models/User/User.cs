using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace AutoAuctionProjekt.Models
{
    //TODO: U4 - Implement interfaces
    public abstract class User
    {
        protected User(string userName, string password, uint zipCode)
        {
             this.UserName = userName;
            this.Password = password;
            this.ZipCode = zipCode;
           

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

            HashAlgorithm sha = SHA256.Create(); // HashAlgorithm object for making hash computations.
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(loginPassword)); // Encodes password to hash as a Byte array.

            return PasswordHash == result;

            throw new NotImplementedException();
        }

        //TODO: U4 - Implement interface proberties and methods.

        public override string ToString()
        {
           return @$"User - ({this.ID}): Name: {this.UserName}, Password: {this.Password},
                    Zipcode: {this.ZipCode}";
        }
    }
}
