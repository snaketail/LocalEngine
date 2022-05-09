using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ivi.Visa;
using NationalInstruments.Visa;

namespace VISALib
{
    public static class rMgr
    {
        public static void FindResources()
        {

            using (var rm = new ResourceManager())
            {
                try
                {
                    IEnumerable<string> resources = rm.Find("(ASRL|GPIB|TCPIP|USB)?*");
                    foreach (string s in resources)
                    {
                        string intType;
                        ParseResult parseResult = rm.Parse(s);
                        switch (parseResult.InterfaceType)
                        {
                            case HardwareInterfaceType.Gpib:
                                intType = "GPIB";
                                break;
                            case HardwareInterfaceType.Vxi:
                                intType = "Vxi";
                                break;
                            case HardwareInterfaceType.Serial:
                                intType = "Serial";
                                break;
                            case HardwareInterfaceType.Pxi:
                                intType = "PXI";
                                break;
                            case HardwareInterfaceType.Tcp:
                                intType = "TCP";
                                break;
                            case HardwareInterfaceType.Usb:
                                intType = "USB";
                                break;
                            default:
                                intType = "Unknown";
                                break;
                        }
                        Console.WriteLine(intType + " device, resource name is: " + s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class VisaSession : IDisposable
    {
        //Define Session Variables
        private string visaResName;
        private int timeOutInMilliSecond;
        string ModelNum = "";
        string SerialNum = "";
        public MessageBasedSession visaSession;

        private string textToWrite = null;
        private string readText = null;

        public byte[] Real32Data = new byte[50000];

        // Define constructors

        public VisaSession(string resName)
        {
            visaResName = resName;
            timeOutInMilliSecond = 10000;
        }

        public VisaSession(string resName, int timeout)
        {
            visaResName = resName;
            timeOutInMilliSecond = timeout;
        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        public void visaSessionInit()
        {
            using (var rmSession = new ResourceManager())
            {
                try
                {
                    visaSession = (MessageBasedSession)rmSession.Open(visaResName);
                    //SetupControlState(true);
                    visaSession.TimeoutMilliseconds = timeOutInMilliSecond;
                }
                catch (InvalidCastException e)
                {
                    string message = "Resource selected must be a message-based session";
                    Exception e2 = (Exception)Activator.CreateInstance(e.GetType(), message, e);
                    throw e2;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Dispose()
        {
            if (visaSession != null)
            {
                visaSession.Dispose();
            }
        }

        public void visaLockSession()
        {
            try
            {
                visaSession.LockResource();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void visaUnlockSession()
        {
            try
            {
                visaSession.UnlockResource();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void visaSendStr(string stringToSent)
        {
            textToWrite = ReplaceCommonEscapeSequences(stringToSent);
            try
            {
                visaSession.RawIO.Write(textToWrite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string visaReadStr()
        {
            try
            {
                readText = InsertCommonEscapeSequences(visaSession.RawIO.ReadString(10000));
            }
            catch (Exception e)
            {
                readText = null;
                Console.WriteLine(e.Message);
            }
            return readText;
        }

        public void visaReadBytes(long count, out long readcount, out Ivi.Visa.ReadStatus rdStatus)
        {
            try
            {
                visaSession.RawIO.Read(Real32Data, 0, count, out readcount, out rdStatus);
            }
            catch (Exception e)
            {
                Real32Data = null;
                readcount = 0;
                rdStatus = ReadStatus.Unknown;

                Console.WriteLine(e.Message);
            }
        }

        public string visaQuery(string stringToSent)
        {
            try
            {
                visaSendStr(stringToSent);
                readText = visaReadStr();
            }
            catch (Exception e)
            {
                readText = null;
                Console.WriteLine(e.Message);
            }
            return readText;
        }


        /// <summary>
        /// The following tasks are async tasks to be used while communicate with VISA Devices
        /// </summary>
        /// <returns></returns>
        #region Async Function

        public Task<int> visaSessionInitAsync()
        {
            using (var rmSession = new ResourceManager())
            {
                try
                {
                    visaSession = (MessageBasedSession)rmSession.Open(visaResName);
                    //SetupControlState(true);
                    visaSession.TimeoutMilliseconds = timeOutInMilliSecond;
                }
                catch (InvalidCastException e)
                {
                    string message = "Resource selected must be a message-based session";
                    Exception e2 = (Exception)Activator.CreateInstance(e.GetType(), message, e);
                    throw e2;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Task.FromResult(0);
        }

        public Task<int> visaSendStrAsync(string stringToSent)
        {
            textToWrite = ReplaceCommonEscapeSequences(stringToSent);
            try
            {
                visaSession.RawIO.Write(textToWrite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Task<int>.FromResult(textToWrite.Length);
        }

        public Task<string> visaReadStrAsync()
        {
            try
            {
                readText = InsertCommonEscapeSequences(visaSession.RawIO.ReadString(10000));
            }
            catch (Exception e)
            {
                readText = null;
                Console.WriteLine(e.Message);
            }
            return Task.FromResult(readText);
        }

        public async Task<string> visaQueryAsync(string stringToSent)
        {
            try
            {
                await visaSendStrAsync(stringToSent);
                readText = await visaReadStrAsync();
            }
            catch (Exception e)
            {
                readText = null;
                Console.WriteLine(e.Message);
            }
            return readText;
        }

        #endregion

    }
}