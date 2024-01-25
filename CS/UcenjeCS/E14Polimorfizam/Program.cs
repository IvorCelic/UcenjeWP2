using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E14Polimorfizam
{
    internal class Program
    {
        private List<Osoba> Osobe;
        public Program() // Kreiramo konstruktor i pozivamo ga u metodu koja se poziva u glavnom programu
        {
            this.Osobe = new List<Osoba>();
            NapuniListu();
            PozdraviOsobe();
        }

        private void PozdraviOsobe()
        {
            Osobe.ForEach(osoba =>
            {
                Console.WriteLine(osoba.Pozdravi()); // Ovdje je manifestacija polimorfizma
            });
        }

        private void NapuniListu() // Pomoću ove metode punimo listu Osobe
        {
            Osobe.Add(new Polaznik() // Dodjeljuje listi Osobe novi objekt iz klase Polaznik
            {
                Ime = "Marko",
                Prezime = "Kas"
            });

            Osobe.Add(new Predavac()
            {
                Ime = "Ivana",
                Prezime = "Kas"
            });
        }

        public static void Izvedi()
        {
            new Program();
        }
    }
}
