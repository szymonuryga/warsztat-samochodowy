using ConsoleApp15;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy SamochodWindow.xaml
    /// </summary>
    public partial class SamochodWindow : Window
    {
        Samochod _samochod;
        public SamochodWindow()
        {
            InitializeComponent();
        }

        public SamochodWindow(Samochod samochod):this()
        {
            _samochod = samochod;
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool ret = false;
            if(txtMarka.Text != "" && txtModel.Text != "" && txtNrRej.Text != "" && txtNrVIN.Text != "")
            {
                _samochod.Marka = txtMarka.Text;
                _samochod.Model = txtModel.Text;
                _samochod.NrRejestracyjny = txtNrRej.Text;
                _samochod.NrVIN = txtNrVIN.Text;
                ret = true;
            }
            DialogResult = ret;
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
