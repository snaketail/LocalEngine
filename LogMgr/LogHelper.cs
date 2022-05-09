using System.IO;
using System.Runtime.CompilerServices;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config" , Watch = true)]

namespace LogMgr
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            string name = Path.GetFileNameWithoutExtension(filename);
            return log4net.LogManager.GetLogger(name);
        }
    }
}
