using System;
using System.Text;
using System.Security.Cryptography;

namespace AutoAuctionProjekt.Models
{
    //TODO: U4 - Implement interfaces
    public abstract class User 
    {
        protected User(string userName, string password, uint zipCode)
        {
            //TODO: U1 - Set constructor and field

            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            PasswordHash = result;

            throw new NotImplementedException();
        }

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
            //TODO: U3 - ToString for User
            throw new NotImplementedException();
        }
    }
}
