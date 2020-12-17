using System;
using System.Xml.Serialization;

namespace ConsoleApp15
{
    [Serializable]
    public class Klient : Person, IComparable<Klient>
    {

        private string idKlient;
        private static int licznikKlientow;

        [XmlAttribute]
        public string IdKlient { get => idKlient; }

        static Klient()
        {
            licznikKlientow = 0;
        }

        public Klient()
        {

        }

        public Klient(string imie, string nazwisko, string pesel, string nrTel) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            NrTel = nrTel;
            licznikKlientow++;
            idKlient = $"KL-{number(licznikKlientow)}";
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public int CompareTo(Klient other)
        {
            int a = Nazwisko.CompareTo(other.Nazwisko);
            if (a != 0) { return a; }
            return Imie.CompareTo(other.Imie);
        }
    }
}
