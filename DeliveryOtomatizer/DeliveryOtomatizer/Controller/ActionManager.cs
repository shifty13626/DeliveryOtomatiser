using DeliveryOtomatizer.Configuration;
using DeliveryOtomatizer.Managers;
using System;
using System.Collections.Generic;
using System.IO;

namespace DeliveryOtomatizer.Controller
{
    /// <summary>
    /// Class to launch all action of the system
    /// </summary>
    public class ActionManager
    {
        private static ConfigLoader configLoader;
        private readonly ConfigSaver configSaver;
        private static ConfigSoft configSoft;
        private static ConfigSonar configSonar;
        private static ConfigNexus configNexus;
        private static SonarActions sonarManager;

        private static string pathConfig;


        public ActionManager()
        {
            pathConfig = Path.Combine(Directory.GetCurrentDirectory(), "config.xml");
            configLoader = new ConfigLoader();
            configSaver = new ConfigSaver(pathConfig);
            sonarManager = new SonarActions();

            reloadConfigs();
        }

        #region -Config -

        /// <summary>
        /// To update all the configuration of the system
        /// </summary>
        private void reloadConfigs()
        {
            configSoft = configLoader.LoadConfigSoftware(pathConfig);
            configSonar = configLoader.LoadConfigSonar(pathConfig);
            configNexus = configLoader.LoadConfigNexus(pathConfig);
        }

        /// <summary>
        /// To save new address of Sonar server
        /// </summary>
        /// <param name="address"></param>
        public void SaveAddressSonar(string address)
        {
            configSaver.SaveAddressSonar(address);
        }

        /// <summary>
        /// To save new address of Nexus server
        /// </summary>
        /// <param name="address"></param>
        public void SaveAddressNexus(string address)
        {
            configSaver.SaveAddressNexus(address);
        }

        /// <summary>
        /// To save new credential of sonar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        public void SaveCredentialsSonar(string id, string password)
        {
            configSaver.SaveCredentialSonar(id, password);
        }

        public void SaveAddressNexus(string id, string password)
        {
            configSaver.SaveCredentialNexus(id, password);
        }


        #endregion

        #region - Getteur -

        /// <summary>
        /// Get name of software
        /// </summary>
        /// <returns></returns>
        public string GetNameSoft()
        {
            return configSoft.Name;
        }

        /// <summary>
        /// Get version of software
        /// </summary>
        /// <returns></returns>
        public string GetVersionSoft()
        {
            return configSoft.Version;
        }

        /// <summary>
        /// Get type of software
        /// </summary>
        /// <returns></returns>
        public string GetTypeSoft()
        {
            return configSoft.Type;
        }

        /// <summary>
        /// Get language of software
        /// </summary>
        /// <returns></returns>
        public string GetLanguageSoft()
        {
            return configSoft.Language;
        }

        /// <summary>
        /// Get username for sonar credential
        /// </summary>
        /// <returns></returns>
        public string GetUserSonar()
        {
            return configSonar.Username;
        }

        /// <summary>
        /// Get address of Sonar server
        /// </summary>
        /// <returns></returns>
        public string GetSonarAddress()
        {
            return configSonar.Address;
        }

        /// <summary>
        /// Get password for sonar credential
        /// </summary>
        /// <returns></returns>
        public string GetPasswordSonar()
        {
            return configSonar.Password;
        }

        /// <summary>
        /// Get Nexus address
        /// </summary>
        /// <returns></returns>
        public string GetNexusAddress()
        {
            return configNexus.Address;
        }

        /// <summary>
        /// Get username for Nexus credentials
        /// </summary>
        /// <returns></returns>
        public string GetUserNexus()
        {
            return configNexus.Username;
        }

        /// <summary>
        /// Get password for nexus credentials
        /// </summary>
        /// <returns></returns>
        public string GetPasswordNexus()
        {
            return configNexus.Password;
        }

        #endregion

        #region - Sonar Actions -

        /// <summary>
        /// Function manager to launch a Sonar analyse
        /// </summary>
        /// <returns></returns>
        public bool LaunchSonarAnalyse()
        {
            // check project exist
            if (!CheckSonarProjectExist())
            {
                // connect to Sonar server
                sonarManager.ConnectOnSonar(configSonar.Username, configSonar.Password);
            }

            return true;
        }

        /// <summary>
        /// Method to check if project already exist in this Sonar server
        /// </summary>
        /// <returns></returns>
        public bool CheckSonarProjectExist()
        {
            if (!sonarManager.OpenSonar(configSonar.Address))
                return false;

            List<string> allProjects = sonarManager.GetAllProject();
            foreach(var element in allProjects)
            {
                if (element.Equals(configSoft.Name))
                {
                    //_log.Info("Project already exist.");
                    return true;
                }
            }

            //_log.Info("Project not exist on Sonar");
            return false;
        }

        #endregion

    }
}
