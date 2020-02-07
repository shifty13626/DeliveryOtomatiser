using DeliveryOtomatizer.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace DeliveryOtomatizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ConfigLoader _configLoader;
        private static ConfigSoft _configSoft;

        public MainWindow()
        {
            _configLoader = new ConfigLoader();
            _configSoft = _configLoader.LoadConfigSoftware(Path.Combine(Directory.GetCurrentDirectory(), "config.xml"));

            InitializeComponent();
        }
    }
}
