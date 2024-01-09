using System.Security.Cryptography.X509Certificates;

namespace UcenjeCS
{
    internal class E06WhilePetlja
    {
        public static void Izvedi()
        {
            // Izvodi se sve dok se nešto ne zadovolji
            bool uvjet = true;
            int i = 0;
            while (uvjet)
            {
                Console.WriteLine(i);
                uvjet = ++i < 10;
            }

            Console.WriteLine("========================");

            i = 0;
            while (i++ < 10)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("========================");

            // continue
            i = 0;
            while (++i < 10)
            {
                if (i == 2) // Prilikom ispisa preskače se vrijednost 2
                {
                    continue;
                }
                Console.WriteLine(i);
            }

            // break
            while (true) // Beskonačna petlja
            {
                Console.WriteLine("Edunova");
                break; // Prekida beskonačnu petlju
            }

            Console.WriteLine("========================");

            // Ugnježđivanje
            i = 0;
            while (++i < 10) // Komplicirani način ispisa do 9
            {
                while (true)
                {
                    Console.WriteLine(i);
                    break;
                }
            }

            Console.WriteLine("========================");

            // Korisnik unosi broj
            // Program ispisuje sve brojeve od unesenog do 100 koristeći while petlju

            Console.Write("Unesi jedan broj: ");
            int broj = int.Parse(Console.ReadLine());
            Console.WriteLine(broj);

            if (broj < 100)
            {
                while (broj <= 100)
                {
                    Console.WriteLine(broj++);
                }
            }
            else
            {
                while (broj >= 100)
                {
                    Console.WriteLine(broj--);
                }
            }



        }
    }
}
