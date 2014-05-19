using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log;

namespace ChuKySo.Tools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            #region Log init

            var severity = ConfigurationManager.AppSettings.Get("LogSeverity");
            SingletonLogger.Instance.Severity = (LogSeverity)Enum.Parse(typeof(LogSeverity), severity, true);
            ILog log = new ObserverLogToConsole();
            SingletonLogger.Instance.Attach(log);
            log = new ObserverLogToFile("filename");
            SingletonLogger.Instance.Attach(log);

            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
