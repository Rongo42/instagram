using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Business.Encription
{
    public class BCryptEncryption : IEncryption
    {
        public string Encrypt(string plaintext)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(plaintext, BCrypt.Net.HashType.SHA512);
        }

        public bool Verify(string plaintext, string hashedText)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(plaintext, hashedText, BCrypt.Net.HashType.SHA512);
        }
    }
}
