using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal class Polaznik : Osoba // Klasa Polaznik nasljeđuje sva public i private svojstva iz klase Osoba
    {
        private int Vidim;
        public string BrojUgovora { get; set; }

        public Polaznik()
        {
            Console.WriteLine("Konstruktor Polaznik");
        }

        public Polaznik(int sifra, string ime, string prezime, string oib, string email, string brojUgovora) : base(sifra, ime, prezime, oib, email)
        {
            BrojUgovora = brojUgovora;
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString()).Append(',').Append(BrojUgovora).ToString(); 
        }



        private void ProvjeraVidljivosti()
        {
            Vidim = 2; // obračamo se ovoj klasi
            base.Sifra = 2;
            base.Vidim = 7; // base znači da se obračamo nadklasi
            this.Vidim = 8; // this znači da se obračamo ovoj klasi

            // var 'NeVidim' se ne vidi iz klase Osoba
        }
    }
}
