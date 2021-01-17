using System;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            Klient klient = new Klient("Jan", "Kowalski", "12345678910", "123-456-789");
            Klient klient1 = new Klient("Joanna", "Kowal", "24345678910", "123-444-789");
            Klient klient2 = new Klient("Ryszard", "Sasin", "12345555555", "111-456-789");
            Pracownik pracownik = new Pracownik("Adam", "Nowak", "22233344455", "987-654-321");
            Pracownik pracownik2 = new Pracownik("Wacław", "Cetnarski", "22233344231", "987-444-321");
            Samochod samochod = new Samochod("VW", "Golf", "KR43252", "WVWAUZ1023141");
            Samochod samochod1 = new Samochod("Audi", "A6", "KR941202", "WVWAUZ1214124");
            Samochod samochod2 = new Samochod("Volvo", "V90", "KR21121", "WVWAUZ1213124");
            Naprawa naprawa = new Naprawa("Malowanie maski", Kategoria.lakiernicza, "2020-10-11", pracownik, samochod, klient);
            Naprawa naprawa1 = new Naprawa("Wymiana opon na zimowe", Kategoria.wymiana_opon, "2020-10-14", pracownik2, samochod1, klient1);
            Naprawa naprawa2 = new Naprawa("Wyciąganie wgniotkli", Kategoria.blacharska, "2020-10-12", pracownik, samochod2, klient2);
            Warsztat app = new Warsztat("Audi-service");
            app.DodajNaprawe(naprawa);
            app.DodajNaprawe(naprawa1);
            app.DodajNaprawe(naprawa2);
            app.DodajPracownika(pracownik);
            app.DodajPracownika(pracownik2);
            //Warsztat w = Warsztat.OdczytZBazy(1);
            /*
            Console.WriteLine(app);
            Console.WriteLine();
            //Console.WriteLine(app.UsunNaprawe("KL-00002/2/WVWAUZ1214124"));
            app.SortujPoKliencie();
            Console.WriteLine(app);
            Console.WriteLine("xml");
            app.ZapiszXML("app.xml");
            Warsztat app1 = Warsztat.OdczytajXML("app.xml");
            Console.WriteLine(app1);
            Console.WriteLine(app.Nazwa);*/
        }
    }
}
