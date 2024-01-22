using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class LjubavniKalkulatorPavkovic
    {
        public static void Izvedi()
        {

            Console.WriteLine("Unesi prvo ime: ");
            string PrvoIme = Console.ReadLine();
            Console.WriteLine("Unesi drugo ime: ");
            string DrugoIme = Console.ReadLine();

            Console.WriteLine(Kalkulacija(VratiNiz(PrvoIme, DrugoIme)));
            Console.ReadKey();
        }

       
        

        private  static int[] VratiNiz(string prvoIme, string drugoIme)
        {
            string spojenaImena = prvoIme + drugoIme;
            int[] niz = new int[spojenaImena.Length];
            int i = 0;

            foreach (char c in spojenaImena)
            {
                int brojac = 0;
                foreach (char d in spojenaImena)
                {
                    if(c == d)
                    {
                        brojac++; 
                    }
                }
                niz[i++] = brojac;
            }

            Console.WriteLine(spojenaImena + "\n " + string.Join(" ", niz));

            return niz;
            
        }

        private static  string  Kalkulacija(int[] ints)
        {
            int min = ints.Length - ints.Length;
            int max = (ints.Length);
            int brojac = 0;
            int rez;
            string a = null;
            int[] rezultat = new int[max];

            while (min < max)
            {

                int lijevi = ints[min];
                int desni = ints[max - 1];


                for (int i = min; i < max; i++)
                {


                    rezultat[i] = lijevi + desni;


                }
                min++;
                max--;


            }


            return string.Join(" ", rezultat);
        }

        private static int[] JNizuM(int[] stari, int novaVelicina)
        {
            int[] noviNiz = new int[novaVelicina];
            Array.Copy(stari, noviNiz, Math.Min(stari.Length, novaVelicina));

            return noviNiz;
        }






    }
}
