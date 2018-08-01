using System;
using System.Security.Cryptography;
using System.Text;

namespace REFEstoqueDotNetV3.system.security
{
   public static class REFHash
    {
        public static String getMD5Hash(String valor)
        {
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] valorHash = HashProvider.ComputeHash(UTF8Encoding.UTF8.GetBytes(valor));

            return BitConverter.ToString(valorHash).Replace("-", "").ToLower();
        }
    }
}
