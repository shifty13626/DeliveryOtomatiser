using DeliveryOtomatizer.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DeliveryOtomatizer.Managers
{
    /// <summary>
    /// Class for all action related to SonarQube 
    /// </summary>
    public class SonarActions
    {
        private IWebDriver driver;


        #region Open / Close

        public bool OpenSonar(string url)
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(2000);
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

        #region - Login / Logout -

        /// <summary>
        /// Mathod to connect on sonar
        /// </summary>
        /// <returns></returns>
        public bool ConnectOnSonar(string id, string password)
        {
            try
            {
                // Go to page login
                IWebElement btnGoToLogin = driver.FindElement(By.CssSelector(".navbar-login"));
                btnGoToLogin.Click();

                // field username
                var fieldUsername = driver.FindElement(By.CssSelector("#login"));
                fieldUsername.SendKeys(id);

                // field password
                var fieldPassword = driver.FindElement(By.CssSelector("#password"));
                fieldPassword.SendKeys(password);

                // Btn password
                var btnLogin = driver.FindElement(By.CssSelector(".button"));
                btnLogin.Click();

                return true;
            }
            catch (Exception e)
            {
                // _log.Error(e.Message());
                // _log.Error(e.StackTrace());
                return false;
            }
        }

        #endregion



        /// <summary>
        /// Get all project name for this Sonar sever
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllProject()
        {
            try
            {
                List<string> returnProjectName = new List<string>();

                // Click on tab "Projects"
                IWebElement listTab = driver.FindElement(By.CssSelector(".global-navbar-menu"));
                var listBtn = listTab.FindElements(By.CssSelector("li"));
                var btnProjects = listBtn.ElementAt(0);
                btnProjects.Click();

                // get all name project
                Thread.Sleep(1000);
                var tabProjects = driver.FindElement(By.CssSelector(".ReactVirtualized__Grid__innerScrollContainer"));
                var panelsProject = tabProjects.FindElements(By.CssSelector(".boxed-group"));
                foreach (var panel in panelsProject)
                {
                    returnProjectName.Add(panel.FindElement(By.CssSelector(".project-card-name")).Text);
                }

                return returnProjectName;
            }
            catch(Exception e)
            {
                // _log.Error(e.Message());
                // _log.Error(e.StackTrace());
                return null;
            }
        }




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
