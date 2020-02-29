using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryOtomatizer.Configuration
{
    /// <summary>
    /// Class with all properties for the software to delivred
    /// </summary>
    public class ConfigSoft
    {
        /// <summary>
        /// Name of new software
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Version of software to deliver
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Type of software
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Language use on code
        /// </summary>
        public string Language { get; set; }
    }
}
