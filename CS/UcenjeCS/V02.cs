using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class V02
    {
        public static void Izvedi()
        {
            // Program učitava brojeve sve dok se ne unese broj -1.
            // Program ispisuje:
            // 1. zbroj unesenih brojeva
            // 2. najmanji broj
            // 3. najveći broj
            // 4. prosjek svih unesenih brojeva

            int broj = UcitajBroj("Unesite broj: ");
            Zbroj();
            Prosjek();


        }

        private static string UcitajBroj(string v)
        {
            int brojac = 1;
            while (true)
            {
                if (brojac != -1)
                {
                    try
                    {
                        Console.WriteLine("Unjeli ste dobar broj.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Niste unjeli dobar broj.");
                        brojac++;
                    }
                }
            }

        }

        private static void Prosjek()
        {
            throw new NotImplementedException();
        }


        private static void Zbroj()
        {
        }
    }
}
