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
        private const string NODE_SONAR = "Sonar";

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

            /*
            _log.Info("Software name loaded : " + config.Name);
            _log.Info("Software version loaded : " + config.Version);
            */

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

            var username = root.Element(NODE_SONAR).Element(NODE_USERNAME_SONAR).Value;
            var password = root.Element(NODE_SONAR).Element(NODE_PASSWORD_SONAR).Value;
            var address = root.Element(NODE_SONAR).Element(NODE_ADDRESS_SONAR).Value;
            var port = 0;
            if (!String.IsNullOrEmpty(root.Element(NODE_SONAR).Element(NODE_PORT_SONAR).Value))
                port = Convert.ToInt32(root.Element(NODE_SONAR).Element(NODE_PORT_SONAR).Value);

            var config = new configSonar()
            {
                Username = username,
                Password = password,
                Address = address,
                Port = port
            };

            /*
            _log.Info("SonarQube username loaded : " + config.Username);
            _log.Info("SonarQube address loaded : " + config.Address);
            _log.Info("SonarQube port loaded : " + config.Port);
            */

            return config;
        }
    }
}
