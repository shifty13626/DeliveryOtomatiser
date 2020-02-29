using DeliveryOtomatizer.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeliveryOtomatizer.Managers
{
    /// <summary>
    /// Class for all action related to SonarQube 
    /// </summary>
    public class SonarActions
    {
        private static readonly ConfigSonar _configSonar;
        private IWebDriver driver;


        #region Open / Close

        public bool OpenSonar(string url)
        {
            try
            {
                driver = new ChromeDriver(Path.Combine(Directory.GetCurrentDirectory()));
                driver.Navigate().GoToUrl("www.google.com");

                return true;
            }
            catch (Exception e)
            {
                //_log.Error(e.StackTrace);
                //_log.Error("Can't open chrome window to navigate to SonarQube");
                return false;
            }
        }

        #endregion

        /*
        #region Authentification

        public bool Login(string userName, string password)
        {

        }

        #endregion

        #region Project

        public bool CheckProjectExist(string nameProject)
        {

        }

        public bool CreateProject (string nameProject)
        {

        }

        #endregion
    */
    }
}
