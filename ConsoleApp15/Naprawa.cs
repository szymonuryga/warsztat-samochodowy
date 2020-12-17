using System;
using System.Globalization;
using System.Xml.Serialization;

namespace ConsoleApp15
{
    [Serializable]
    public enum Kategoria
    {
        mechaniczna, blacharska, lakiernicza, blacharsko_lakiernicza, wymiana_opon
    }
    [Serializable]
    public class Naprawa : ICloneable, IComparable<Naprawa>
    {
        private string opis;
        private Kategoria kategoria;
        private DateTime dataPrzyjęcia;
        private Pracownik pracownik;
        private Samochod samochod;
        private Klient klient;
        private string idNaprawa;
        static int licznik;

        static Naprawa()
        {
            licznik = 0;
        }

        public Naprawa()
        {
            licznik++;
        }
        public Naprawa(string opis, Kategoria kategoria, string dataPrzyjęcia, Pracownik pracownik, Samochod samochod, Klient klient) : this()
        {
            DateTime date;
            DateTime.TryParseExact(dataPrzyjęcia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out date);
            this.opis = opis;
            this.kategoria = kategoria;
            this.dataPrzyjęcia = date;
            this.pracownik = pracownik;
            this.samochod = samochod;
            this.klient = klient;
            idNaprawa = $"{Klient.IdKlient}/{licznik}/{Samochod.NrVIN}";
        }

        public string Opis { get => opis; set => opis = value; }
        public Kategoria Kategoria { get => kategoria; set => kategoria = value; }
        public DateTime DataPrzyjęcia { get => dataPrzyjęcia; set => dataPrzyjęcia = value; }
        public Pracownik Pracownik { get => pracownik; set => pracownik = value; }
        public Samochod Samochod { get => samochod; set => samochod = value; }
        public Klient Klient { get => klient; set => klient = value; }
        [XmlAttribute]
        public string IdNaprawa { get => idNaprawa; set =>idNaprawa = value; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(Naprawa other)
        {
            int a = Klient.Nazwisko.CompareTo(other.Klient.Nazwisko);
            if (a != 0) { return a; }
            return Klient.Imie.CompareTo(other.Klient.Imie);
        }

        public override string ToString()
        {
            return $"{Opis} - {Kategoria}, {DataPrzyjęcia.ToString("dd-MM-yyyy")}-{Klient.IdKlient}, {Samochod}, {Pracownik.IdPrac} ";
        }
    }
}
