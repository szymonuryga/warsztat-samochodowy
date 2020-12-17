using System;

namespace ConsoleApp15
{
    [Serializable]
    public abstract class Person : ICloneable
    {
        protected string imie;
        protected string nazwisko;
        protected string pesel;
        protected string nrTel;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string NrTel { get => nrTel; set => nrTel = value; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public string number(int index)
        {
            int copy = index;
            string result = "";
            int iloscCyfr = 0;
            while (copy > 0)
            {
                iloscCyfr++;
                copy /= 10;
            }
            for (int i = 0; i < 5 - iloscCyfr; i++)
            {
                result += "0";
            }
            return result + index.ToString();
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
