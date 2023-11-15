using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Business.Encription
{
    public interface IEncryption
    {
        public string Encrypt (string plaintext);

        public bool Verify (string plaintext, string hashedText);
    }
}
