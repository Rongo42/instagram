using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Business.Encription
{
    public static class BCryptEncryption 
    {
        public static string Encrypt(this string plaintext)
        {
            //Encrypting the string argument utilizing the SHA512 algorythm
            return BCrypt.Net.BCrypt.EnhancedHashPassword(plaintext, BCrypt.Net.HashType.SHA512);
        }

        public static bool Verify(this string plaintext, string hashedText)
        {
            //Utilizing SHA512 algorythm to verify if the two arguments match
            return BCrypt.Net.BCrypt.EnhancedVerify(plaintext, hashedText, BCrypt.Net.HashType.SHA512);
        }
    }
}
