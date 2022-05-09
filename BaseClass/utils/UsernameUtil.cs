using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass.utils
{
    public class UsernameUtil
    {
        public static String getSn(String username)
        {
            String[] temp = username.Split("&");
            return temp[0];
        }

        public static long getTimestamp(String username)
        {
            String[] temp = username.Split("&");
            return Convert.ToInt64(temp[1]);
        }

        public static String getUsername(String sn, long timestamp)
        {
            return sn + "&" + timestamp;
        }
    }
}
