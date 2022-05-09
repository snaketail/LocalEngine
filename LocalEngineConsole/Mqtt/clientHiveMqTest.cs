using LogMgr;
using MQTTLib;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using System;
using System.Threading.Tasks;

namespace LocalEngineConsole.Mqtt.clientHiveMqTest
{
    public class clientHiveMqTest
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private static NodeMqttSession hiveMqttClientSession = new NodeMqttSession(true);

        private static string username;
        private static string password;

        static IMqttClientOptions mqttClientOptions;
        public static ManagedMqttClientOptions managedMqttClientOptions;
        public static ManagedMqttClient nodeMqttClient = hiveMqttClientSession.mqttClient;


        public static void testNodeConfig()
        {
            username = "HarryMQTT";
            password = "Test1234";

            mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("f5d69094265948daa019846bb8da6607.s1.eu.hivemq.cloud", 8883)
                .WithCredentials(username, password)
                .WithTls()
                .WithKeepAlivePeriod(new TimeSpan(0, 0, 1, 0))
                .Build();

            managedMqttClientOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(mqttClientOptions)
                .Build();

        }


        #region HiveMQ server functions
        public static async Task HiveMqMsgTest(ManagedMqttClient mqttClient)
        {
            await mqttClient.SubscribeAsync(topic: "Step", qualityOfServiceLevel: MqttQualityOfServiceLevel.AtMostOnce);

            await mqttClient.PublishAsync(topic: "Step", payload: "1", MqttQualityOfServiceLevel.AtLeastOnce);
            await mqttClient.PublishAsync(topic: "Step", payload: "2", MqttQualityOfServiceLevel.AtLeastOnce);
            await mqttClient.PublishAsync(topic: "Step", payload: "3", MqttQualityOfServiceLevel.AtLeastOnce);

            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic("Step")
                .WithPayload("Built Messages")
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await mqttClient.PublishAsync(applicationMessage);

            string stopSign = "Start";

            while (stopSign != "exit")
            {
                log.Debug("start publish message  " + stopSign);

                await mqttClient.PublishAsync(topic: "Step", payload: stopSign, MqttQualityOfServiceLevel.AtLeastOnce);

                stopSign = Console.ReadLine();
            }


            log.Debug("Message publish done");

        }



        #endregion

    }

}

