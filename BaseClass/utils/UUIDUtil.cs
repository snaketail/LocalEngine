using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass.utils
{
    public class UUIDUtil
    {
        private static String[] chars = new String[]{"a", "b", "c", "d", "e", "f",
            "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
            "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5",
            "6", "7", "8", "9"};

        private static int DEFAULT_SHORT_UUID_LENGTH = 8;

        public static String generateShortUuid()
        {
            return generateShortUuid(DEFAULT_SHORT_UUID_LENGTH);
        }

        public static String generateShortUuid(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String uuid = Guid.NewGuid().ToString().Replace("-", "");
            for (int i = 0; i < length; i++)
            {
                String str = uuid.Substring(i * 4, i * 4 + 4);
                int x = Convert.ToInt32(str, 16);
                stringBuilder.Append(chars[x % 0x24]);
            }
            return stringBuilder.ToString();
        }

        private static long makeEpoch()
        {
            // UUID v1 timestamp must be in 100-nanoseconds interval since 00:00:00.000 15 Oct 1582."GMT-0"
            DateTime c = new DateTime(1582, 10, 0, 0, 0, 0,0, DateTimeKind.Utc); ;

            return c.Ticks/10000;
        }

        private static long START_EPOCH = makeEpoch();

        public static Guid timeBasedUUID()
        {
            DateTime dt = new DateTime();
            dt = DateTime.UtcNow;
            var bytes = BitConverter.GetBytes(dt.Ticks);

            Array.Resize(ref bytes, 16);

            return new Guid(bytes);
        }
    }
}
