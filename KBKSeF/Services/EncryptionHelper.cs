using KBKSeF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Services
{
    public class EncryptionHelper : IEncryptionHelper
    {
        public string EncryptToken(string token, string key, DateTimeOffset timeStamp)
        {
            string s;
            byte[] tab;

            s = token + "|" + timeStamp.ToUnixTimeMilliseconds().ToString();

            tab = System.Text.ASCIIEncoding.UTF8.GetBytes(s);

            s = Convert.ToBase64String(EncryptRSA(tab, key));
            return s;
        }

        private static byte[] EncryptRSA(byte[] tab, string key)
        {
            using (RSACryptoServiceProvider rsa = new())
            {
                rsa.ImportFromPem(key.ToCharArray());
                var result = rsa.Encrypt(tab, false);
                return result;
            }
        }
    }
}
