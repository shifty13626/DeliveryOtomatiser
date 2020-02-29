using DeliveryOtomatizer.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using DeliveryOtomatizer.Controller;

namespace DeliveryOtomatizer.Views
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private static ActionManager actionManager;

        public Settings()
        {
            actionManager = new ActionManager();

            InitializeComponent();

            updateAllFields();
        }

        /// <summary>
        /// Method to update all fields of the settings windows
        /// </summary>
        private void updateAllFields()
        {
            TextBoxNameServerSonarAddress.Text = actionManager.GetSonarAddress();
            TextBoxNameServerNexusAddress.Text = actionManager.GetNexusAddress();
        }

        /// <summary>
        /// Action when click on save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // luanch save of new configuration of sonar
            actionManager.SaveAddressSonar(TextBoxNameServerSonarAddress.Text);

            // luanch save of new configuration of nexus
            actionManager.SaveAddressNexus(TextBoxNameServerNexusAddress.Text);

            this.Close();
        }
    }
}
