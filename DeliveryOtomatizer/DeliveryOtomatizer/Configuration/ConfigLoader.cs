using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace DeliveryOtomatizer.Configuration
{
    /// <summary>
    /// Class to load all parameter on config file
    /// </summary>
    public class ConfigLoader
    {
        #region Tag label cong

        private const string NODE_CONFIG = "Config";
        private const string NODE_SOFT = "Soft";
        private const string NODE_SONAR = "Sonar";
        private const string NODE_NEXUS = "Nexus";

        private const string NODE_NAME = "name";
        private const string NODE_VERSION = "version";
        private const string NODE_TYPE = "type";
        private const string NODE_LANGUAGE = "language";

        private const string NODE_USERNAME_SONAR = "username";
        private const string NODE_PASSWORD_SONAR = "password";
        private const string NODE_ADDRESS_SONAR = "address";

        private const string NODE_ADDRESS_NEXUS = "address";
        private const string NODE_USERNAME_NEXUS = "username";
        private const string NODE_PASSWORD_NEXUS = "password";

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
                Version = root.Element(NODE_SOFT).Element(NODE_VERSION).Value,
                Type = root.Element(NODE_SOFT).Element(NODE_TYPE).Value,
                Language = root.Element(NODE_SOFT).Element(NODE_LANGUAGE).Value
            };

            /*
            _log.Info("Software name loaded : " + config.Name);
            _log.Info("Software version loaded : " + config.Version);
            _log.Info("Type of software loaded : " +config.Type);
            _log.Info("Language of software laoded : " +config.Language);
            */

            return config;
        }

        /// <summary>
        /// To load configuration of SonarQube gorup
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ConfigSonar LoadConfigSonar (string url)
        {
            var doc = XDocument.Load(url);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return null;
            }

            var config = new ConfigSonar()
            {
                Username = root.Element(NODE_SONAR).Element(NODE_USERNAME_SONAR).Value,
                Password = root.Element(NODE_SONAR).Element(NODE_PASSWORD_SONAR).Value,
                Address = root.Element(NODE_SONAR).Element(NODE_ADDRESS_SONAR).Value
            };

            /*
            _log.Info("SonarQube username loaded : " + config.Username);
            _log.Info("SonarQube address loaded : " + config.Address);
            _log.Info("SonarQube port loaded : " + config.Port);
            */

            return config;
        }


        public ConfigNexus LoadConfigNexus(string url)
        {
            var doc = XDocument.Load(url);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return null;
            }

            var config = new ConfigSonar()
            {
                Username = root.Element(NODE_SONAR).Element(NODE_USERNAME_SONAR).Value,
                Password = root.Element(NODE_SONAR).Element(NODE_PASSWORD_SONAR).Value,
                Address = root.Element(NODE_SONAR).Element(NODE_ADDRESS_SONAR).Value
            };

            return config;
        }

    }
}
