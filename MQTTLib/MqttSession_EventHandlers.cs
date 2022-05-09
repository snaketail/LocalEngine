using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Diagnostics;
using MQTTnet.Diagnostics.Logger;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;

namespace MQTTLib
{
    public partial class NodeMqttSession : IDisposable
    {
        #region Managed Client Event Handler
        /// <summary>
        /// Handle Mqtt Message Received (from subscription) Event
        /// </summary>
        /// <param name="e">Event argument, contain like topic, payload, etc</param>
        private void DoMsgReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            log.Debug("Mqtt Infomation received event generated");
            //Can enQ msg
            log.Info("Message is: Topic - " + e.ApplicationMessage.Topic + " and payload - " + System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        }

        /// <summary>
        /// Event raised when Mqtt client connected to the mqtt server
        /// </summary>
        /// <param name="e">Argument result code to show connection status</param>
        private void DoMqttConnected(MqttClientConnectedEventArgs e)
        {
            log.Debug("Info generated from connected server");
            //Can enQ msg
            log.Info("Connection result is: " + e.ConnectResult.ResultCode);
        }

        /// <summary>
        /// Event raised when Mqtt client disconnected from the server
        /// </summary>
        /// <param name="e"></param>
        private void DoMqttDisconnected(MqttClientDisconnectedEventArgs e)
        {
            log.Debug("Disconnected Event Generated, client successfully disconnected");
            //Can enQ msg
        }

        #endregion
    }
}