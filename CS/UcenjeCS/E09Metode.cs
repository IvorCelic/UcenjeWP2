using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E09Metode
    {


// Do OOP-a (Objektno Orijentirano Programiranje) sve metode će biti static u ovom projektu UcenjeCS
        public static void Izvedi()
        {

            // POZIVANJE METODE
            Tip1();
            Tip2(1, 25);
            var ImeRacunala = Tip3();
            Console.WriteLine(ImeRacunala);
            Console.WriteLine(Tip4(1222222345) ? "PRIM" : "NIJE");
            SviPrimBrojevi(27, 99);

        }


// 1. vrsta => tipa VOID, ne prima vrijednost, prima praznu listu parametara
        static void Tip1()
        {
            Console.WriteLine("Hello iz tip 1 :P");
        }


// 2. vrsta => tipa VOID, prima parametre
        static void Tip2(int Od, int Do)
        {
            // Ispišite sve parne brojeve između dva primljena parametre
            for (int i = Od; i <= Do; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                else continue;

            }
        }


// 3. vrsta => određenog tipa koji vraća pozivatelju, ne prima parametre
        static string Tip3()
        {
            return System.Net.Dns.GetHostName();
        }


// 4. vrsta => NAJKORISNIJA - određenog tipa koji vraća pozivatelju, prima parametre
        static bool Tip4(int Broj)
        {
            // Ispišite je li primljeni broj zaista prost (prime)
            for (int i = 2; i < Broj; i++)
            {
                if (Broj % i == 0)
                {
                    return false; // shortcuircuting => kratki spoj, odnosno ako nađe broj djeljiv s 0, staje i vraća false
                }
            }

            return true;
        }


        // Zadatak:
        // Ispiši sve prim brojeve između dva broja
        static void SviPrimBrojevi(int Od, int Do)
        {
            for (int i = Od; i <= Do; i++)
            {
                // Koristimo prijašnju metodu koja provjerava je li primljeni broj prim broj
                if (Tip4(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}
