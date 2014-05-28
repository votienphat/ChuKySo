using System;
using Dsms.Back.Util;
using Log;

namespace eCC.Back
{
    public class LoggingHandler
    {
        public static void Initialize()
        {
            var severity = ConstantApi.Config.LogSeverity;
            SingletonLogger.Instance.Severity = (LogSeverity)Enum.Parse(typeof(LogSeverity), severity, true);
            ILog log = new ObserverLogToConsole();
            SingletonLogger.Instance.Attach(log);
            log = new ObserverLogToFile("filename");
            SingletonLogger.Instance.Attach(log);
        }
    }
}