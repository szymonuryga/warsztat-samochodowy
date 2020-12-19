using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp15
{
    [Serializable]
    public class Samochod : ICloneable
    {
        string marka;
        string model;
        string nrRejestracyjny;
        string nrVIN;
        [Key]
        public int samochodId { get; set; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string NrRejestracyjny { get => nrRejestracyjny; set => nrRejestracyjny = value; }
        public string NrVIN { get => nrVIN; set => nrVIN = value; }

        public Samochod() { }
        public Samochod(string marka, string model, string nrRejestracyjny, string nrVIN)
        {
            this.Marka = marka;
            this.model = model;
            this.nrRejestracyjny = nrRejestracyjny;
            this.nrVIN = nrVIN;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public override string ToString()
        {
            return $"{Marka} {Model} {NrVIN}";
        }
    }
}
