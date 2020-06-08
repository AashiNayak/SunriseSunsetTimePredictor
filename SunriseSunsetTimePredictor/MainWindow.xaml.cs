using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SunriseSunsetTimePredictor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiConnection.Initialize();
        }

        private async void GetDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (latText.Text == "" || lngText.Text == "")
            {
                MessageBox.Show("Enter Latitude and Longitude");
            }
            else if (latText.Text == "0" || lngText.Text == "0")
            {
                MessageBox.Show("Invalid Request");
            }
            else
            {
                float latitude = float.Parse(latText.Text);
                float longitude = float.Parse(lngText.Text);

                var predict = await TimePredictor.LoadTime(latitude, longitude);

                riseLabel.Content = $"Sunrise is at {predict.Sunrise.ToLocalTime().ToShortTimeString()}";
                setLabel.Content = $"Sunset is at {predict.Sunset.ToLocalTime().ToShortTimeString()}";

            }
        }
    }
}
