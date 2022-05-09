using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BaseClass
{
    public class DeviceBase
    {
        public string id { get; private set; }
        public string productId { get; private set; }
        public string nodeId { get; private set; }
        public string name { get; private set; }
        public string sn { get; private set; }
        public string model { get; private set; }
        public string fwVersion { get; private set; }
        public bool isOnline { get; private set; }
        public string protocolVersion { get; private set; }
        public WorkingMode workingMode { get; private set; }
        public long loginTime { get; private set; }
        public long registerTime { get; private set; }

        public DeviceBase(string _productId, string _nodeId, string _name, string _sn, string _model, string _fwVersion, string _protocolVersion)
        {
            id = DevIdGen();
            SetWorkMode(WorkingMode.Idle);
            nodeId = _nodeId;
            name = _name;
            sn = _sn;
            model = _model;
            fwVersion = _fwVersion;
            protocolVersion = _protocolVersion;
        }
        private string DevIdGen()
        {
            return "UUID_Dev";
        }
        public void UpdateDevName(string _name)
        {
            this.name = _name;
        }
        public void UpdateDevFwVersion(string _version)
        {
            this.fwVersion = _version;
        }
        public void SetWorkMode(WorkingMode _mode)
        {
            workingMode = _mode;
        }
        public string GetWorkModeInString()
        {
            switch(workingMode)
            {
                case WorkingMode.Idle: return "idle";
                case WorkingMode.Interactive:return "work";
                case WorkingMode.Continuous: return "work";
                default: return "unknown";
            }
        }
        public void UpdateOnlineStatus(bool _isOnline)
        {
            this.isOnline = _isOnline;
        }
        public void UpdateLoginTime(long _time)
        {
            this.loginTime = _time;
        }
        public void UpdateRegisterTime(long _time)
        {
            this.registerTime = _time;
        }
    }
}

