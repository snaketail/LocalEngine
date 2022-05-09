using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass
{
    public class MqttMessageBase:IDisposable
    {
        public string id { get; private set; }
        public string name { get; private set; }
        public string prefixCode { get; private set; }
        public long timeStamp { get; private set; }
        public bool report { get; private set; }
        public MessageType type { get; private set; }
        public List<string> content { get; private set; }
        public int code { get; private set; }
        public string message { get; private set; }
        public long version { get; private set; }


        private string MsgIdGen()
        {
            return "UUID_Msg";
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
