using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class V03
    {
        public static void Izvedi()
        {
            // Program učitava brojeve sve dok se ne unese broj -1.
            // Program ispisuje:
            // 1. zbroj unesenih brojeva
            // 2. najmanji broj
            // 3. najveći broj
            // 4. prosjek svih unesenih brojeva

            UcitajBroj("Unesite broj: ");


        }

        private static string UcitajBroj(string v)
        {
            int Zbroj = 0;
            int Min = int.MinValue;
            int Max = int.MaxValue;
            int Brojac = 0;
            double Prosjek = (double)Zbroj / Brojac;

            for ( ; ; )
            {
                Console.Write(v);

                try
                {
                    int Broj = int.Parse(Console.ReadLine());
                    Zbroj += Broj;
                    Brojac++;

                    if (Broj == -1)
                    {
                        Console.WriteLine("Zbroj unesenih brojeva: " + Zbroj);
                        Console.WriteLine("Najmanji broj: " + Min);
                        Console.WriteLine("Najveći broj: " + Max);
                        Console.WriteLine("Prosjek svih unesenih brojeva: " + Prosjek);
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("Niste unjeli dobar broj.");
                }
            }

        }

    }
}
