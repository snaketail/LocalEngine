using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogMgr;
using MQTTLib;
using MQTTnet.Extensions.ManagedClient;

namespace LocalEngineConsole.Mqtt.LocalMqttNode

{
    public class LocalMqttNode
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private static NodeMqttSession hsNodeMqttSession = new NodeMqttSession(true);

        public static ManagedMqttClientOptions managedMqttClientOptions;
        public static ManagedMqttClient nodeMqttClient = hsNodeMqttSession.mqttClient;

    }

}
