using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp15
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNazwy()
        {
            Warsztat w = new Warsztat("Test1");
            string nazwa = "Test1";
            Assert.AreEqual(nazwa, w.Nazwa);
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Klient klient = new Klient("Czesław", "Nowak");
            Klient klient1 = new Klient("Adam", "Nowak");
            int wartoscOczzekiwana = 1;
            Assert.AreEqual(wartoscOczzekiwana, klient.CompareTo(klient1));
        }

        [TestMethod]
        public void TestIdPracownika()
        {
            Pracownik pracownik0 = new Pracownik("Adam", "Nowak", "12345678901", "112-333-412");
            Pracownik pracownik = new Pracownik("Adam", "Małysz", "12345678901", "112-333-412");
            string id = "AM-00002";
            Assert.AreEqual(id, pracownik.IdPrac);
        }

        [TestMethod]
        public void TestSamochod()
        {
            Samochod samochod = new Samochod("Audi", "A8", "KR43221", "VWVAUZ12390");
            string marka = "Audi";
            Assert.AreEqual(marka, samochod.Marka);
        }

        [TestMethod]
        public void TestPracownikEmail()
        {
            Pracownik pracownik = new Pracownik("Adam", "Małysz", "12345678901", "112-333-412");
            string email = "amałysz@warsztat.pl";
            Assert.AreEqual(email, pracownik.Email);
        }

        [TestMethod]
        public void TestDodawaniaNaprawy()
        {
            Warsztat warsztat = new Warsztat();
            warsztat.DodajNaprawe(new Naprawa());
            int wartoscOczekiwana = 1;
            Assert.AreEqual(wartoscOczekiwana, warsztat.Naprawy.Count);
        }
    }
}
