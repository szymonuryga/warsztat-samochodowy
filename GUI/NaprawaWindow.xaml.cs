using ConsoleApp15;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Logika interakcji dla klasy NaprawaOkno.xaml
    /// </summary>
    public partial class NaprawaOkno : Window
    {
        Naprawa _naprawa;
        public NaprawaOkno()
        {
            InitializeComponent();
        }

        public NaprawaOkno(Naprawa naprawa, Warsztat warsztat) : this()
        {
            _naprawa = naprawa;
            comboBoxPracownicy.ItemsSource = new ObservableCollection<Pracownik>(warsztat.Pracownicy);
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool ret = false;
            if (txtOpis.Text != "" && txtDataPrzyj.Text != "" && txtKlient.Text != "" && txtSamochod.Text != "" && comboBoxPracownicy.SelectedIndex > -1)
            {
                _naprawa.Opis = txtOpis.Text;
                if (cbKategoria.Text == "mechaniczna") { _naprawa.Kategoria = Kategoria.mechaniczna; }
                if (cbKategoria.Text == "blacharska") { _naprawa.Kategoria = Kategoria.blacharska; }
                if (cbKategoria.Text == "lakiernicza") { _naprawa.Kategoria = Kategoria.lakiernicza; }
                if (cbKategoria.Text == "blacharsko_lakiernicza") { _naprawa.Kategoria = Kategoria.blacharsko_lakiernicza; }
                if (cbKategoria.Text == "wymiana_opon") { _naprawa.Kategoria = Kategoria.wymiana_opon; }
                string[] fdate = { "dd-MM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" };
                DateTime.TryParseExact(txtDataPrzyj.Text, fdate, null, DateTimeStyles.None, out DateTime date);
                _naprawa.DataPrzyjęcia = date;
                _naprawa.Pracownik = (Pracownik)comboBoxPracownicy.SelectedItem;

                ret = true;
            }
            DialogResult = ret;
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnDodajSamo_Click(object sender, RoutedEventArgs e)
        {
            Samochod samochod = new Samochod();
            SamochodWindow o = new SamochodWindow(samochod);
            o.ShowDialog();
            _naprawa.Samochod = samochod;
            txtSamochod.Text = samochod.ToString();
        }

        private void btnDodajKlient_Click(object sender, RoutedEventArgs e)
        {
            Klient klient = new Klient();
            PersonWindow o = new PersonWindow(klient);
            o.ShowDialog();
            _naprawa.Klient = klient;
            txtKlient.Text = klient.ToString();
        }
    }
}
