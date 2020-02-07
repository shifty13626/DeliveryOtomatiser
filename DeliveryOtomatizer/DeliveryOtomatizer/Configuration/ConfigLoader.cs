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
        private const string NODE_SONAR = "sonar";

        private const string NODE_NAME = "name";
        private const string NODE_VERSION = "version";

        private const string NODE_USERNAME_SONAR = "username";
        private const string NODE_PASSWORD_SONAR = "password";
        private const string NODE_ADDRESS_SONAR = "address";
        private const string NODE_PORT_SONAR = "port";

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

        /// <summary>
        /// To load configuration of SonarQube gorup
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public configSonar LoadConfigSonar (string url)
        {
            var doc = XDocument.Load(url);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return null;
            }

            var config = new configSonar()
            {
                Username = root.Element(NODE_SONAR).Element(NODE_USERNAME_SONAR).Value,
                Password = root.Element(NODE_SONAR).Element(NODE_PASSWORD_SONAR).Value,
                Address = root.Element(NODE_SONAR).Element(NODE_ADDRESS_SONAR).Value,
                Port = root.Element(NODE_SONAR).Element(NODE_PORT_SONAR).Value
            };

            return config;
        }
    }
}
