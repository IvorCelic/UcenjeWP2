using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E17Delegati
{
    internal class ObradaSmjer
    {
        // Delegati su mogućnost da ponašanje prebacim u neku drugu klasu

        public delegate void IspisPozivSmjer(Smjer s); // DELEGAT

        private readonly List<Smjer> Smjerovi;

        public ObradaSmjer()
        {
            Smjerovi = new List<Smjer>()
            {
                new Smjer() {Naziv = "Prvi"},
                new Smjer() {Naziv = "Drugi"},
            };
        }

        public void IspisSmjer(IspisPozivSmjer poziv)
        {
            Smjerovi.ForEach(s => poziv(s));
        }

        // Za ovo gore ne treba delegat
        public void IspisSmjerAction(Action<Smjer> poziv)
        {
            Smjerovi.ForEach(s => poziv(s));
        }
    }
}
