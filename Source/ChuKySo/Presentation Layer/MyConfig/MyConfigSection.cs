using System.Configuration;

namespace MyConfig
{
    public class MyConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("SiteElement")]
        public SiteElementCollection SiteElements
        {
            get { return (SiteElementCollection)this["SiteElement"]; }
        }

        [ConfigurationProperty("Default")]
        public DefaultElement DefaultElement
        {
            get { return (DefaultElement)this["Default"]; }
        }
    }
}
