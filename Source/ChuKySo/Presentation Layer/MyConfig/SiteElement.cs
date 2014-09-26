using System.Configuration;

namespace MyConfig
{
    public class SiteElement : ConfigurationElement
    {
        [ConfigurationProperty("SiteId", DefaultValue = "0")]
        public int SiteId
        {
            get { return (int)this["SiteId"]; }
        }

        [ConfigurationProperty("SiteUrl", DefaultValue = "")]
        public string SiteUrl
        {
            get { return (string)this["SiteUrl"]; }
        }

        [ConfigurationProperty("Visible", DefaultValue = "true")]
        public bool Visible
        {
            get { return (bool)this["Visible"]; }
        }
    }

    public class SiteElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SiteElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SiteElement)element).SiteId;
        }
    }
}
