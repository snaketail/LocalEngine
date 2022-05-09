using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeStatus
{
    public class mqttSvrStatus
    {
        public bool Connected { get; private set; }

        public string SrvReturnCode { get; private set; }

        public int MyProperty { get; set; }
        public mqttSvrStatus()
        {

        }


    }
}
