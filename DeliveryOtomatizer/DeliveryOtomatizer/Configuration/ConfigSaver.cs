using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace DeliveryOtomatizer.Configuration
{
    /// <summary>
    /// Class to contain all method to save new properties on config file
    /// </summary>
    public class ConfigSaver
    {
        private static string pathConfig;

        #region Nodes

        private const string NODE_CONFIG = "Config";
        private const string NODE_SONAR = "Sonar";
        private const string NODE_NEXUS = "Nexus";

        private const string NODE_USERNAME_SONAR = "username";
        private const string NODE_PASSWORD_SONAR = "password";
        private const string NODE_ADDRESS_SONAR = "address";

        private const string NODE_ADDRESS_NEXUS = "address";
        private const string NODE_USERNAME_NEXUS = "username";
        private const string NODE_PASSWORD_NEXUS = "password";

        #endregion

        public ConfigSaver (string url)
        {
            pathConfig = url;
        }

        #region - Save Address -

        /// <summary>
        /// Save new parameters of Sonar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="addressSonar"></param>
        /// <returns></returns>
        public bool SaveAddressSonar(string addressSonar)
        {
            var doc = XDocument.Load(pathConfig);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return false;
            }

            root.Element(NODE_SONAR).Element(NODE_ADDRESS_SONAR).Value = addressSonar;

            File.WriteAllText(pathConfig, doc.ToString());

            return true;
        }

        /// <summary>
        /// Save new parameters of Nexus
        /// </summary>
        /// <param name="addressNexus"></param>
        /// <returns></returns>
        public bool SaveAddressNexus(string addressNexus)
        {
            var doc = XDocument.Load(pathConfig);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return false;
            }

            root.Element(NODE_NEXUS).Element(NODE_ADDRESS_NEXUS).Value = addressNexus;

            File.WriteAllText(pathConfig, doc.ToString());

            return true;
        }

        #endregion

        #region - Save credentials -

        /// <summary>
        /// Save the new credential of Sonar on config file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SaveCredentialSonar(string id, string password)
        {
            var doc = XDocument.Load(pathConfig);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return false;
            }

            root.Element(NODE_SONAR).Element(NODE_USERNAME_SONAR).Value = id;
            root.Element(NODE_SONAR).Element(NODE_PASSWORD_SONAR).Value = password;

            return true;
        }

        /// <summary>
        /// Save the new credential of Nexus on config file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SaveCredentialNexus(string id, string password)
        {
            var doc = XDocument.Load(pathConfig);
            var root = doc.Element(NODE_CONFIG);
            if (root == null)
            {
                Console.WriteLine("Can't find root element of config");
                return false;
            }

            root.Element(NODE_NEXUS).Element(NODE_USERNAME_NEXUS).Value = id;
            root.Element(NODE_NEXUS).Element(NODE_PASSWORD_NEXUS).Value = password;

            return true;
        }

        #endregion
    }
}
