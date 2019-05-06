using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WM.Register.MD5
{
    public class Common
    {
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static string HMACHSA1(string message, string secretKey)
        {
            string result;
            var keyByte = Encoding.ASCII.GetBytes(secretKey);
            using (var hmac = new HMACSHA1(keyByte))
            {
                hmac.ComputeHash(Encoding.ASCII.GetBytes(message));
                result = ByteToString(hmac.Hash);
            }
            return result;
        }
        public static string ByteToString(byte[] buffer)
        {
            string result = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                result += buffer[i].ToString("X2");
            }
            return result;
        }
       public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}