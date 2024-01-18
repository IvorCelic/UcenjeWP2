using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt
{
    internal class Ljubav
    {
        public string PrvoIme { get; set; }
        public string DrugoIme { get; set; }


        // Ovo je konstruktor - 5. vrsta metoda
        public Ljubav()
        { 
        // Ovdje se dolazi kada se izvodi ključna riječ new
        }

        public Ljubav(string prvoIme, string drugoIme)
        {
            this.PrvoIme = prvoIme;
            DrugoIme = drugoIme;
        }
        public string Rezultat()
        {
            return Izracunaj(SlovaNiz(PrvoIme+DrugoIme)) + " %";
        }

        private int Izracunaj(int[] brojevi)
        {
            // Tu dolazi rekurzivni algoritam
            return 67;
        }

        private int[] SlovaNiz(string imena)
        {
            return new int[2]; 
        }

    }
}
