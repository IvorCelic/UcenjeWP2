using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal class Program
    {
        // Nasljeđivanje 
        public static void Izvedi()
        {
            var p = new Polaznik()
            {
                Sifra = 1,
                Ime = "Pero",
                Prezime = "Perić",
                BrojUgovora = "2/2024"
            };

            Console.WriteLine(p.Sifra); // Ispisuje Sifru objekta p

            var pr1 = new Predavac();
            pr1.Ime = "Mario";

            var pr2 = new Predavac();
            pr2.Ime = "Mario";

            // Ispisati će false zato što su pr1 i pr2 različita objekta
            Console.WriteLine((pr1 == pr2) + ", " + pr1.GetHashCode() + " == " + pr2.GetHashCode());

            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");

            string a = "Osijek";
            Console.WriteLine("a na početku: " + a.GetHashCode());
            a += " je super";
            Console.WriteLine("a nakon promjene: " + a.GetHashCode());

            Console.WriteLine("pr1 na početku: " + pr1.GetHashCode());
            pr1.Prezime = "Perić";
            Console.WriteLine("pr1 nakon promjene: " + pr1.GetHashCode());

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Osijek");
            Console.WriteLine("sb na početku: " + sb.GetHashCode());
            sb.AppendLine(" je super");
            Console.WriteLine("sb nakon promjene: " + sb.GetHashCode());

            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");

            Console.WriteLine(pr1);
            Console.WriteLine(p);
        }
    }
}
