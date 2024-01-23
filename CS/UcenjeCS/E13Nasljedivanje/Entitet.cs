using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal abstract class Entitet // ABSTRACT označava da ju ne možeš instancirati
    {
        public int Sifra { get; set; }

        public Entitet()
        {
            Console.WriteLine("Konstruktor Entitet");
        }

        public Entitet(int sifra)
        {
            Sifra = sifra;
        }
    }
}
