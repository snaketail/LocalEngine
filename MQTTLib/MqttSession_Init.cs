using LogMgr;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Receiving;
using MQTTnet.Diagnostics.Logger;
using MQTTnet.Extensions.ManagedClient;
using System;

namespace MQTTLib
{

    public partial class NodeMqttSession : IDisposable
    {
        //private static readonly log4net.ILog log = LogHelper.GetLogger();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Mqtt Session");

        private MqttNetEventLogger mqttEventLogger;

        public ManagedMqttClient mqttClient;
        /// <summary>
        /// Initialize Mqtt session
        /// --Event Logger
        /// --Client
        /// --Client event handler
        /// </summary>
        public NodeMqttSession(bool enableLogger)
        {
            ///initialize the Mqtt event logger
            mqttEventLogger = new MqttNetEventLogger("mqttLogger");
            MqttNetConsoleLogger.ForwardToConsole(mqttEventLogger);
            mqttEventLogger.IsEnabled = enableLogger;


            var mqttFactory = new MqttFactory();

            mqttClient = new ManagedMqttClient(mqttFactory.CreateMqttClient(mqttEventLogger), mqttEventLogger);

            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(DoMsgReceived);

            mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(DoMqttConnected);

            mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(DoMqttDisconnected);

        }



        public void Dispose()
        {
            mqttClient?.Dispose();
            mqttEventLogger = null;
        }

    }
}
