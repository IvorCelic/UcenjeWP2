using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt
{
    internal class Program
    {
        public static void Izvedi()
        {
            Osoba o = new Osoba();
            Grad g = new()
            {
                Naziv = "Osijek",
                BrojStanovnika = 100000
            };

            o.Grad = g;

            Console.WriteLine(o.Grad.Naziv);

        }

        private static string Unos(string poruka)
        {
            string Unos;

            while (true)
            {

                Console.Write(poruka);
                Unos = Console.ReadLine();

                if (Unos.Trim().Length == 0)
                {
                    Console.WriteLine("Unos obavezan.");
                    continue;
                }

                return Unos;
            }
        }

        private static void E01OsnovnaSintaksa()
        {
            // Objekt je pojavnost (instanca) klase
            Osoba osoba = new Osoba();

            osoba.Ime = "Pero";
            osoba.Prezime = "Perić";

            Console.WriteLine(osoba.Ime + " " + osoba.Prezime);
        }

        private static void E02DrugaSintaksa()
        {
            Osoba o = new Osoba
            {
                Ime = Console.ReadLine(),
                Prezime = Console.ReadLine()
            };

            Console.WriteLine(o.ImePrezime());
        }

        private static void E03Najcesce()
        {
            // Najčešći način deklaracije
            // Umjesto Osoba osoba = new Osoba();

            Osoba osoba = new();

            var pjevac = new Osoba();

            // pjevac.Ime = "Mirko";
            Console.WriteLine(pjevac.Ime?.Substring(0, 1)); // ? stavljamo kako bi Ime moglo biti null
        }

        private static void LjubavniZov()
        {
            Ljubav ljubav = new(); // s new se poziva konstruktor

            // Pomoću metode Unos skratili smo kod

            // Console.Write("Unesi ime prve osobe: ");
            // ljubav.PrvoIme = Console.ReadLine();
            ljubav.PrvoIme = Unos("Unesi ime prve osobe: ");
            ljubav.DrugoIme = Unos("Unesi ime druge osobe: ");

            Console.WriteLine(ljubav.Rezultat());

            Console.WriteLine(new Ljubav(Unos("Prvo ime: "), Unos("Drugo ime: ")).Rezultat()); // Ova linija je ekvivalent ovog iznad - POMOĆU KONSTRUKTORA
        }
    }
}
