using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTLib;
using LogMgr;
using _BaseClass.utils;
using _BaseClass;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using System.Text.Json;
using MQTTnet.Protocol;

namespace LocalEngineConsole.Mqtt
{
    public static class HsMqtt
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public static string buildPassword(string sn, string clientId, string username)
        {
            string sign = sn + clientId + Base64Util.encode(username).Substring(5, 14);
            return MD5Util.md5(sign);
        }

        public static async Task mqttNodeStart(ManagedMqttClient mqttClient, ManagedMqttClientOptions managedMqttClientOptions)
        {
            if (mqttClient.IsConnected == false)
            {
                await mqttClient.StartAsync(managedMqttClientOptions);

                while (mqttClient.IsConnected == false) ;

                log.Info("Status Report Connected, Node is in working mode");
            }

            else log.Warn("Node Still Connected");
        }

        public static async Task mqttNodeStop(ManagedMqttClient mqttClient)
        {
            log.Info("Disconnecting From MQTT server");
            await mqttClient.StopAsync();
        }
    }
}
