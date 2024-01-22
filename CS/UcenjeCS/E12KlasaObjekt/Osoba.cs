using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UcenjeCS.E12KlasaObjekt
{
    // Klasa je opisnik objekta
    // Objekt je instanca (pojavnost) klase
    internal class Osoba
    {
        // Svojstva koja opisuju klasu
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Grad Grad { get; set; }

        public string ImePrezime() 
        {
            return Ime + " " + Prezime; // Ovo može bolje
        }


    }
}
