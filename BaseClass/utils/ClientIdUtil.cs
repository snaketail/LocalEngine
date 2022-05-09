using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass.utils
{
    public class ClientIdUtil
    {
        public static string getProductKey(string clientId)
        {
            string[] temp = clientId.Split(":");
            return temp[0];
        }

        public static string getSn(string clientId)
        {
            string[] temp = clientId.Split(":");
            return temp[1];
        }

        public static string getClientId(string productKey, string sn)
        {
            return productKey + ":" + sn;
        }
    }
}
