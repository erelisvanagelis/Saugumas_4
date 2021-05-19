using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Saugumas_4.Utilities
{
    class EncryptionTool
    {
        public static string GeneratePassword()
        {
            RandomNumberGenerator randomNumberGenerator = RNGCryptoServiceProvider.Create();
            byte[] data = new byte[32];
            randomNumberGenerator.GetBytes(data);
            return Convert.ToBase64String(data);
        }
    }
}
