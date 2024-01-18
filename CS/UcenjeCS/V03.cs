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

            UcitajBrojeve();


        }

        private static void UcitajBrojeve()
        {
            int Zbroj = 0;
            int Min = int.MaxValue;
            int Max = int.MinValue;
            int Brojac = 0;

            for ( ; ; )
            {
                Console.Write("Unesite broj: ");

                try
                {

                    int Broj = int.Parse(Console.ReadLine());

                    if (Broj < Min)
                    {
                        Min = Broj;
                    }
                    if (Broj > Max)
                    {
                        Max = Broj;
                    }

                    Brojac++;
                    Zbroj += Broj;
                    double Prosjek = (double)Zbroj / Brojac;

                    if (Broj == -1)
                    {

                        Console.WriteLine("Zbroj unesenih brojeva: " + Zbroj);
                        Console.WriteLine("Najmanji broj: " + Min);
                        Console.WriteLine("Najveći broj: " + Max);
                        Console.WriteLine("Prosjek svih unesenih brojeva: " + Prosjek);

                        break;
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
