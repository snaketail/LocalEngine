using MQTTnet;
using LogMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Client.Receiving;

namespace LocalEngineConsole
{
    internal class LocalEngineEHs
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private LocalEngine _localEngine;
        public LocalEngineEHs(LocalEngine localEngine)
        {
            _localEngine = localEngine; 
        }

        //public void MqttEventsSubscription()
        //{
        //    _localEngine._mqttSession._mqttClient. += (sender, args) =>
        //    {
        //        log.Info("msg received");
        //    };
        //}


    }
}
