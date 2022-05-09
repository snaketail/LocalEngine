using System;
using LogMgr;
using LocalEngineConsole.Mqtt;
using LocalEngineConsole.Mqtt.clientHiveMqTest;
using LocalEngineConsole.Mqtt.LocalMqttNodeTest;
using LocalEngineConsole.Mqtt.LocalMqttNode;
using System.Threading.Tasks;
using ComLib.VisaSession;

namespace _Test_Bench_Proj
{
    internal class Program
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();



        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //rMgr.FindResources();

            await doVISATest();


            //clientHiveMqTest.testNodeConfig();
            //await doHiveClientTest();

            //LocalMqttNodeTest.testNodeConfig();
            //await doLocalNodeTest();
        }

        /// <summary>
        /// Async function to execute HiveMQ server configuration
        /// </summary>
        /// <returns></returns>
        public static async Task doHiveClientTest()
        {
            await HsMqtt.mqttNodeStart(clientHiveMqTest.nodeMqttClient, clientHiveMqTest.managedMqttClientOptions);
            await clientHiveMqTest.HiveMqMsgTest(clientHiveMqTest.nodeMqttClient);
            await HsMqtt.mqttNodeStop(clientHiveMqTest.nodeMqttClient);
        }

        /// <summary>
        /// Async function to execute HS mqtt client test with given Demo product and node id
        /// </summary>
        /// <returns></returns>
        public static async Task doLocalNodeTest()
        {
            await HsMqtt.mqttNodeStart(LocalMqttNodeTest.nodeMqttClient, LocalMqttNodeTest.managedMqttClientOptions);
            await LocalMqttNodeTest.HsMqttDemoClientTest(LocalMqttNodeTest.nodeMqttClient);
            await HsMqtt.mqttNodeStop(LocalMqttNodeTest.nodeMqttClient);
        }

        public static async Task doVISATest()
        {
            string visaRscStr = "USB0::0x2A8D::0xB318::MY59380016::INSTR";
            string responseStr;
            VISASession demoVisaSession = new VISASession(visaRscStr);
            await demoVisaSession.visaSessionInitAsync();
            log.Debug("VISA Inited");
            Console.ReadLine(); 

            await demoVisaSession.visaSendStrAsync("*IDN?");
            responseStr = demoVisaSession.visaReadStrAsync().Result;
            Console.WriteLine(responseStr);

        }
    }
}
