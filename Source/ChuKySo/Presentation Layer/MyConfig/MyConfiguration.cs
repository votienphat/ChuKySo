using System.Configuration;

namespace MyConfig
{
    public class MyConfiguration
    {
        private static MyConfigSection _instance;

        private static MyConfigSection Instance
        {
            get
            {
                return _instance ?? (_instance = (MyConfigSection) ConfigurationManager.GetSection("MyConfig"));
            }
        }

        public static SiteElementCollection Sites
        {
            get { return Instance.SiteElements; }
        }

        public static DefaultElement Default
        {
            get { return Instance.DefaultElement; }
        }
    }
}
