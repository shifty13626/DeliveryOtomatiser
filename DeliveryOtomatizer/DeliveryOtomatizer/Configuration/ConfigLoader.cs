using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace DeliveryOtomatizer.Configuration
{
    public class ConfigLoader
    {
        #region Tag label cong

        private const string NODE_CONFIG = "Config";
        private const string NODE_SOFT = "Soft";

        private const string NODE_NAME = "name";
        private const string NODE_VERSION = "version";

        #endregion

        /// <summary>
        /// To load configuration of software group
        /// </summary>
        /// <returns></returns>
        public ConfigSoft LoadConfigSoftware(string url)
        {
            var doc = XDocument.Load(url);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return null;
            }

            var config = new ConfigSoft()
            {
                Name = root.Element(NODE_SOFT).Element(NODE_NAME).Value,
                Version = root.Element(NODE_SOFT).Element(NODE_VERSION).Value
            };

            return config;
        }
    }
}
