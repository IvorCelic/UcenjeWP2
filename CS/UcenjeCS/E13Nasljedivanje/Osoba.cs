using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal abstract class Osoba : Entitet
    {
        private int NeVidim; // Private znači da se vidi samo u Osobi
        protected int Vidim; // Protected se vidi u trenutnoj klasi i podklasama
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }

        public Osoba()
        {
            Console.WriteLine("Konstruktor Osoba");
        }

        public Osoba(int sifra, string ime, string prezime, string oib, string email) : base(sifra) // Proslijedi gore ono što nije tvoje
        {
            // Ideja je da klasa odradi samo one parametre koje se nje tiču
            // base.Sifra = sifra --> Ovome tu nije mjesto, to treba odraditi neka klasa iznad što je Entitet

            Ime = ime;
            Prezime = prezime;
            Oib = oib;
            Email = email;

        }
        public override string ToString()
        {
            // return Ime + " " + Prezime; Ovo je užas

            return new StringBuilder(Ime).Append(' ').Append(Prezime).ToString(); // Ovako samo jednom alocira memoriju
        }
    }
}
