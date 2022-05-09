using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass
{
    public class EdgeNodeBase
    {
        public string id { get; private set; }
        public string productId { get; private set; }
        public string name { get; private set; }
        public string sn { get; private set; }
        public string hwVersion { get; private set; }
        public string fwVersion { get; private set; }
        public string ip { get; private set; }
        public bool isOnline { get; private set; }
        public bool isGpsOn { get; private set; }
        public string protocolVersion { get; private set; }
        public long loginTime { get; private set; }

        public EdgeNodeBase(string _productId, string _name, string _sn, string _hwVersion, string _fwVersion, string _ip, string _protocolVersion)
        {
            id = NodeIdGen();
            productId = _productId;
            name = _name;
            sn = _sn;
            hwVersion = _hwVersion;
            fwVersion = _fwVersion;
            ip = _ip;
            isOnline = false;
            isGpsOn = false;
            protocolVersion = _protocolVersion;
        }
        private string NodeIdGen()
        {
            return "UUID_Node";
        }
        public void UpdateNodeName(string _name)
        {
            this.name = _name;
        }
        public void UpdateIp (string _ip)
        {
            this.ip = _ip;
        }
        public void UpdateOnlineStatus(bool _isOnline)
        {
            this.isOnline = _isOnline;
        }
        public void UpdateGpsStatus(bool _isGpsOn)
        {
            this.isGpsOn= _isGpsOn;
        }
        public void UpdateLoginTime(long _time)
        {
            this.loginTime = _time;
        }
    }
}

///
