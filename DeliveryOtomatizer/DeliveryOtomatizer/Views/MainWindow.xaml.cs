using DeliveryOtomatizer.Controller;
using DeliveryOtomatizer.Enums;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DeliveryOtomatizer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ActionManager actionManager;

        public MainWindow()
        {
            actionManager = new ActionManager();

            ComboBoxTypeSoft = new ComboBox();
            ComboBoxLanguageSoft = new ComboBox();

            InitializeComponent();

            updateAllField();
        }

        private void updateAllField()
        {

            // Complete Combobox
            // type soft
            foreach (var element in Enum.GetValues(typeof(TypeSoft)))
                ComboBoxTypeSoft.Items.Add(element);
            ComboBoxTypeSoft.SelectedIndex = 0;
            // languages
            foreach (var element in Enum.GetValues(typeof(LanguageSoft)))
                ComboBoxLanguageSoft.Items.Add(element);
            ComboBoxLanguageSoft.SelectedIndex = 0;

            // fields soft
            TextBoxNameSoft.Text = actionManager.GetNameSoft();
            TextBoxVersionSoft.Text = actionManager.GetVersionSoft();
            ComboBoxTypeSoft.SelectedItem = actionManager.GetTypeSoft();
            ComboBoxLanguageSoft.SelectedItem = actionManager.GetLanguageSoft();

            // fields sonar
            TextBoxUsernameSonar.Text = actionManager.GetUserSonar();
            PassBoxPassSonar.Password = actionManager.GetPasswordSonar();

            // fields nexus
            TextBoxUsernameNexus.Text = actionManager.GetUserNexus();
            PassBoxPassNexus.Password = actionManager.GetPasswordNexus();
        }


        /// <summary>
        /// to launch Sonarqube analyse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSonarAnalyse_Click(object sender, RoutedEventArgs e)
        {

            // get all parameters
            var softName = TextBoxNameSoft.Text;
            var softVersion = TextBoxVersionSoft.Text;
            var typeSoft = ComboBoxTypeSoft.Text.ToString();
            var languageSoft = ComboBoxLanguageSoft.Text.ToString();

            var idSonar = TextBoxUsernameSonar.Text;
            var passwordSonar = PassBoxPassSonar.Password;

            actionManager.SaveCredentialsSonar(idSonar, passwordSonar);

            // Launch Sonar analys
            actionManager.LaunchSonarAnalyse();


            /*
            // open Sonar
            if (!sonarManager.OpenSonar(configSonar.Address))
            {
             //   _log.Error("Can't open SonarQuabe");
                return;
            }
            */

            // display message to save last parmaeters on configuration file
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings windowSetting = new Settings();
            windowSetting.Show();
        }

        private void btnNexusSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
