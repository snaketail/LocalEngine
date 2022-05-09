using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace _BaseClass.utils
{
    public class MD5Util
    {
        /// <summary>
        /// Normal MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string md5(string input)
        {
            MD5 md5 = MD5.Create();
            char[] charArray = input.ToCharArray();
            byte[] byteArray = new byte[charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                byteArray[i] = (byte)charArray[i];
            }
            byte[] md5Bytes = md5.ComputeHash(byteArray);
            StringBuilder hexValue = new StringBuilder();
            foreach (byte md5Byte in md5Bytes)
            {
                int val = ((int)md5Byte) & 0xff;
                if (val < 16)
                {
                    hexValue.Append("0");
                }
                hexValue.Append(Convert.ToString(val, 16));
            }
            return hexValue.ToString();
        }

    }
}
