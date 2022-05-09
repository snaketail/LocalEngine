using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass.utils
{
    public class Base64Util
    {
        public static byte[] decode4byte(string data)
        {
            if (data == null) return null;
            return Convert.FromBase64String(data);
        }
        
        public static string decode(string data)
        {
            if (data == null) return null;

            return Encoding.ASCII.GetString(decode4byte(data));
            //return BitConverter.ToString(decode4byte(data));
            //Encoding.ASCII.GetString(bytes)
        }

        public static string encode4byte(byte[] data)
        {
            if (data == null) return null;
            return Convert.ToBase64String(data);
        }

        public static string encode(string data)
        {
            if  (data == null) return null;
            return (encode4byte(Encoding.ASCII.GetBytes(data)));
        }


    }
}
