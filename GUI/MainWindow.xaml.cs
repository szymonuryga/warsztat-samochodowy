using ConsoleApp15;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Warsztat warsztat;
        public MainWindow()
        {
            InitializeComponent();
 
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Naprawa naprawa = new Naprawa();
            NaprawaOkno o = new NaprawaOkno(naprawa, warsztat);
            o.ShowDialog();
            warsztat.DodajNaprawe(naprawa);
            lvNaprawy.ItemsSource = new ObservableCollection<Naprawa>(warsztat.Naprawy);
        }

        private void BtnRozlicz_Click(object sender, RoutedEventArgs e)
        {
            if (warsztat is object && lvNaprawy.SelectedIndex > -1)
            {
                Naprawa x = (Naprawa)lvNaprawy.SelectedItem;
                warsztat.UsunNaprawe(x);
                lvNaprawy.ItemsSource = new ObservableCollection<Naprawa>(warsztat.Naprawy);
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                warsztat.Nazwa = txtNazwaWarsztatu.Text;
                warsztat.ZapiszXML(filename);
            }
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                warsztat = Warsztat.OdczytajXML(filename);
                txtNazwaWarsztatu.Text= warsztat.Nazwa ;

                if (warsztat is object)
                {
                    txtNazwaWarsztatu.Text = warsztat.Nazwa;
                    lstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(warsztat.Pracownicy);
                    lvNaprawy.ItemsSource = new ObservableCollection<Naprawa>(warsztat.Naprawy);
                }
            }
        }

        private void BtnDodajPrac_Click(object sender, RoutedEventArgs e)
        {
            Pracownik pracownik = new Pracownik();
            PersonWindow o = new PersonWindow(pracownik);
            o.ShowDialog();
            pracownik.initializeFields();
            warsztat.DodajPracownika(pracownik);
            lstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(warsztat.Pracownicy);
        }

        private void BtnUsunPrac_Click(object sender, RoutedEventArgs e)
        {
            if (warsztat is object && lstPracownicy.SelectedIndex > -1)
            {
                Pracownik p = (Pracownik)lstPracownicy.SelectedItem;
                warsztat.UsunPracownika(p);
                lstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(warsztat.Pracownicy);
            }
        }


    }
}
