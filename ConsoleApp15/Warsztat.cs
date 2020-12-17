using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp15
{
    [Serializable]
    public class Warsztat : ICloneable
    {
        private List<Naprawa> naprawy;
        private List<Pracownik> pracownicy;
        private string nazwa;

        public Warsztat()
        {
            naprawy = new List<Naprawa>();
            pracownicy = new List<Pracownik>();
        }

        public Warsztat(string nazwa):this()
        {
            this.nazwa = nazwa;
        }

        public List<Naprawa> Naprawy { get => naprawy; set => naprawy = value; }
        public List<Pracownik> Pracownicy { get => pracownicy; set => pracownicy = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }

        public object Clone()
        {
            Warsztat warsztat = new Warsztat();
            List<Naprawa> lista = new List<Naprawa>();
            foreach (Naprawa n in naprawy)
            {
                warsztat.DodajNaprawe((Naprawa)n.Clone());
            }
            return warsztat;
        }

        public void DodajPracownika(Pracownik pracownik)
        {
            pracownicy.Add(pracownik);
        }

        public void UsunPracownika(Pracownik pracownik)
        {
            pracownicy.Remove(pracownik);
        }

        public void UsunNaprawe(Naprawa naprawa)
        {
            naprawy.Remove(naprawa);
        }
        public bool UsunPracownika(string idPrac)
        {
           bool tmp = false;
            Pracownik p = null;
            foreach(Pracownik pracownik in pracownicy)
            {
                if (pracownik.IdPrac.Equals(idPrac))
                {
                    p = pracownik;
                    tmp = true;
                }
            }
            pracownicy.Remove(p);
            return tmp;
        }
        public void DodajNaprawe(Naprawa naprawa)
        {
            naprawy.Add(naprawa);
        }

        public bool UsunNaprawe(string idNaprawa)
        {
            bool tmp = false;
            Naprawa n = null;
            foreach (Naprawa naprawa in naprawy)
            {
                if (idNaprawa.Equals(naprawa.IdNaprawa))
                {
                    n = naprawa;
                    tmp = true;
                }
            }
            naprawy.Remove(n);
            return tmp;
        }

        public void UsunWszystkich()
        {
            naprawy.Clear();
        }

        public List<Naprawa> WyszukajNaprawy(Kategoria kategoria)
        {
            return naprawy.Where(x => x.Kategoria.Equals(kategoria)).ToList();
        }

        public void SortujPoKliencie()
        {
            naprawy.Sort();
        }

        public void ZapiszXML(string plik)
        {
            using (StreamWriter file = new StreamWriter(plik))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Warsztat));
                xs.Serialize(file, this);
            }
        }

        public static Warsztat OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader file = new StreamReader(plik))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Warsztat));
                return (Warsztat)xs.Deserialize(file);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nazwa: " + Nazwa);
            foreach (Naprawa n in naprawy)
            {
                sb.AppendLine(n.ToString());
            }
            return sb.ToString();
        }

    }
}
