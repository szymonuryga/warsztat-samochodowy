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
    /// Logika interakcji dla klasy PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        Person _person;
        public PersonWindow()
        {
            InitializeComponent();
        }

        public PersonWindow(Person person) : this()
        {
            _person = person;
            if(person is Klient)
            {
                txtPesel.Text = person.Pesel;
                txtImie.Text = person.Imie;
                txtNazwisko.Text = person.Nazwisko;
                txtNrTel.Text = person.NrTel;
            }
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool ret = false;
            if (txtPesel.Text != "" && txtImie.Text != "" && txtNazwisko.Text != "")
            {
                _person.Imie = txtImie.Text;
                _person.Nazwisko = txtNazwisko.Text;
                _person.Pesel = txtPesel.Text;
                _person.NrTel = txtNrTel.Text;
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
