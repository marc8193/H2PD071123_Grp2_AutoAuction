using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace AutoAuctionProjekt.Models
{

    public abstract class User
    {
        //Username, Password og ZipCode sættes op
        protected User(string userName, string password, uint zipCode)
        {
             this.UserName = userName;
            this.Password = password;
            this.ZipCode = zipCode;
           
//skal denne encryption blive? Skal serveren ikke styre det? spørg simon.
            //HashAlgorithm sha = SHA256.Create();
            //byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            //PasswordHash = result;

            this.UserName = userName;
            this.Password = password;
            this.Zipcode = zipCode;
        }

        public string UserName { get; set; }
        public int DbId { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public uint Zipcode { get; set; }

        private bool ValidateLogin(string loginUserName, string loginPassword)
        {
            //   HashAlgorithm sha = SHA256.Create(); // HashAlgorithm object for making hash computations.
            //  byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(loginPassword)); // Encodes password to hash as a Byte array.

            //  return PasswordHash == result;

            //ÆNDRER NÅR LOGINS ER LAVET I DATABASE
            bool grantAccess = true;
            bool denyAccess = false;
            //Hent Fra database
            string DBUserName = "navn";
                string DBPassword = "password";

            if (loginUserName == DBUserName && loginPassword == DBPassword) {
                return grantAccess;
            }
            return denyAccess;

      
            //U6, Lav user i database og brug den til authentication
        }
        public override string ToString()
        {
            return @$"User - ({this.DbId}): Username: {this.UserName}, 
            Balance: {this.Balance}, Zipcode: {this.Zipcode}";
        }
    }

}
