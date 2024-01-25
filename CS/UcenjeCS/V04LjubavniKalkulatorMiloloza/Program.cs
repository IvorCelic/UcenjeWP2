using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.V04LjubavniKalkulatorMiloloza
{
    internal class Program
    {
        public static void Izvedi()
        {
            LjubavniZov();
        }

        private static string Unos(string poruka)
        {
            string Unos;

            while (true)
            {

                Console.Write(poruka);
                Unos = Console.ReadLine();

                if (Unos.Trim().Length == 0)
                {
                    Console.WriteLine("Unos obavezan.");
                    continue;
                }

                return Unos;
            }
        }
        private static void LjubavniZov()
        {
            Console.WriteLine(new LjubavniKalkulatorMiloloza(Unos("Prvo ime: "), Unos("Drugo ime: ")).Rezultat());
        }
    }
}
