using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.Commons.Util
{
    public class MD5Helper
    {
        public static string CreateHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert string to bytes
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create an StringBuilder
            StringBuilder sBuilder = new StringBuilder();

            // Format every byte as an hex
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
