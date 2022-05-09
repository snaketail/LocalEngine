using LogMgr;
using _BaseClass;
using MQTTLib;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using System;
using System.Threading.Tasks;
using _BaseClass.utils;
using System.Text.Json;
using System.Threading;

namespace LocalEngineConsole.Mqtt.LocalMqttNodeTest
{
    public static class LocalMqttNodeTest
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private static string productKey = "demo_edge_node";
        private static string sn = "JSUEI2876DNKS";
        // /{productKey}/{sn}/{type}/{name}/{method}
        private static string test_topic = "/" + productKey + "/" + sn + "/config/test";
        private static string report_topic = "/" + productKey + "/" + sn + "/config/report";

        public static NodeMqttSession hsNodeMqttTestSession = new NodeMqttSession(true);

        private static string clientId;
        private static long timestamp;
        private static string username;
        private static string password;

        static IMqttClientOptions mqttClientOptions;
        public static ManagedMqttClientOptions managedMqttClientOptions;
        public static ManagedMqttClient nodeMqttClient = hsNodeMqttTestSession.mqttClient;


        public static void testNodeConfig()
        {
            clientId = ClientIdUtil.getClientId(productKey, sn);
            timestamp = DateTime.UtcNow.Ticks / 10000;
            username = UsernameUtil.getUsername(sn, timestamp);
            password = HsMqtt.buildPassword(sn, clientId, username);

            mqttClientOptions = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V311)
                .WithTcpServer("39.97.185.188", 1883)
                .WithCredentials(username, password)
                .WithKeepAlivePeriod(new TimeSpan(0, 0, 1, 0))
                .Build();

            managedMqttClientOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(mqttClientOptions)
                .Build();

        }

        public static async Task HsMqttDemoClientTest(ManagedMqttClient mqttClient)
        {
            MqttMessage<int> message = buildTestMessage();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(2000);
                log.Info("publishing");

                await publishTestMessageAsync(mqttClient, message);
            }
        }


        #region Test Node functions
        public static MqttMessage<int> buildTestMessage()
        {
            MqttMessage<int> message = new MqttMessage<int>();

            message.setName("test");
            message.setPrefixCode("/");
            message.setType(MessageType.CONFIG);
            message.setMessage("hello word");


            return message;
        }

        public static async Task publishTestMessageAsync(ManagedMqttClient client, MqttMessage<int> message)
        {
            var hsMqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic("test_topic")
                .WithPayload(JsonSerializer.Serialize(message))
                .Build();

            try
            {
                await client.PublishAsync(hsMqttMessage);
            }
            catch (Exception)
            {

                Console.WriteLine("Publish Error");
            }

        }


        #endregion


    }
}
