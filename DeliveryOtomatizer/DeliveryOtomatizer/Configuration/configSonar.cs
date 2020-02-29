using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryOtomatizer.Configuration
{
    /// <summary>
    /// All property for SonarQube analizer
    /// </summary>
    public class ConfigSonar
    {
        /// <summary>
        /// User name use to connect on Sonar server
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password use to connect to Sonar server
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Address of Sonar server
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Port of Sonar server
        /// </summary>
        public int Port { get; set; }
    }
}
