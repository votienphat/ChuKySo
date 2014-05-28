using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Dsms.Back.Util
{
    public class ConstantApi
    {
        public class Config
        {
            public static string LogSeverity
            {
                get { return ConfigurationManager.AppSettings.Get("LogSeverity"); }
            }
        }

        public static readonly IEnumerable<string> ExceptionApis = new ReadOnlyCollection<string>
            (new List<string>
                 {
                     "api/login",
                 });
    }
}