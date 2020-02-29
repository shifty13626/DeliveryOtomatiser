using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryOtomatizer.Configuration
{
    /// <summary>
    /// Class contains all properties for Nexus
    /// </summary>
    public class ConfigNexus
    {
        /// <summary>
        /// Address of Nexus server
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Username for Nexus credential
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password for Nexus credential
        /// </summary>
        public string Password { get; set; }
    }
}
