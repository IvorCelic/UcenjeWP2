using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    // Utility = pomocno na eng
    internal class Pomocno
    {
        public static int UcitajInt(string poruka)
        {
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Neispravan unos");
                }
                
            }
        }

        public static string UcitajString(string poruka)
        {
            string s;

            while (true)
            {
                Console.Write(poruka);
                s = Console.ReadLine();

                if (s.Trim().Length == 0)
                {
                    Console.WriteLine("Obavezan unos");
                    continue;
                }

                return s;
            }
        }
    }
}
