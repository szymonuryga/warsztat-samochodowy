using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ConsoleApp15
{
    [Serializable]
    public class Pracownik : Person
    {
        private string email;
        private string idPrac;
        private static int licznikPracownikow;

        public string Email { get => email; set => email = value; }
        public string IdPrac { get => idPrac; set => idPrac = value; }
        [Key]
        public int pracownikId { get; set; }
        public int warsztatId { get; set; }
        public virtual Warsztat warsztatBaza { get; set; }
        static Pracownik()
        {
            licznikPracownikow = 0;
        }


        public Pracownik()
        {
            licznikPracownikow++;

        }
        public Pracownik(string imie, string nazwisko, string pesel, string nrTel) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            NrTel = nrTel;
            email = $"{Imie.Substring(0, 1).ToLower()}{Nazwisko.ToLower()}@warsztat.pl";
            idPrac = $"{Imie.Substring(0, 1).ToUpper()}{Nazwisko.Substring(0, 1).ToUpper()}-{number(licznikPracownikow)}";
        }

        public void initializeFields()
        {
            email = $"{Imie.Substring(0, 1).ToLower()}{Nazwisko.ToLower()}@warsztat.pl";
            idPrac = $"{Imie.Substring(0, 1).ToUpper()}{Nazwisko.Substring(0, 1).ToUpper()}-{number(licznikPracownikow)}";
        }

        public override string ToString()
        {
            return base.ToString() + " " + Email + " " + idPrac;
        }
    }
}
