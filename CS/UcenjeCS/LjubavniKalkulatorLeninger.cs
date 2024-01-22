using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class LjubavniKalkulatorLeninger
    {
        public static void Izvedi()
        {
            string PrvoIme = UnesiIme("Unesite prvo ime: ");
            string DrugoIme = UnesiIme("Unesite drugo ime: ");
            //int ZbrojInt = Kalkulator(PocetniNiz(PrvoIme, DrugoIme));

            //int[] KonacniRezultat = Kalkulator(PocetniNiz(PrvoIme, DrugoIme));
            string KonacniRezultat = string.Join(" ", VratiNiz(PocetniNiz(PrvoIme, DrugoIme)));


            Console.WriteLine(KonacniRezultat);
        }

        private static string UnesiIme(string v)
        {
            for (; ; )
            {
                Console.Write(v);
                try
                {
                    return Console.ReadLine();
                }
                catch (Exception e)
                {

                    Console.WriteLine("Nisi unio Ime");
                }
            }
        }


        private static int[] PocetniNiz(string PrvoIme, string DrugoIme)
        {
            string SpojenaImena = PrvoIme + DrugoIme;
            int[] NizZaAnalizu = new int[SpojenaImena.Length];
            int i = 0;


            // Sada cemo prebrojati koliko se puta koje slovo pojavljuje u nizu koji se sastoji od prvog i  drugog imena

            foreach (char c in SpojenaImena)
            {
                int Brojac = 0;

                foreach (char cc in SpojenaImena)
                {
                    if (c == cc) // Ako se isti znak vec pojavljuje
                    {
                        Brojac++;
                    }
                }
                NizZaAnalizu[i++] = Brojac;
            }

            Console.WriteLine(SpojenaImena + "\n" + string.Join(" ", NizZaAnalizu));

            return NizZaAnalizu;
        }

        private static int[] Kalkulator(int[] PrimjeniNiz)
        {
            ///Definiramo "pozicije s kojih nam ide brojac unutar niza Min i Max
            //int Min = 0;
            //int Max = PrimjeniNiz.Length;
            string Novi = null;
            int Brojac = 0;
            int Rez;
            int DuzinaPocetnogNiza = PrimjeniNiz.Length;
            int[] Rezultat = new int[DuzinaPocetnogNiza / 2 + (DuzinaPocetnogNiza % 2)];
            for (int i = 0; i < DuzinaPocetnogNiza / 2; i++)
            {
                Rezultat[i] = PrimjeniNiz[i] + PrimjeniNiz[DuzinaPocetnogNiza - i - 1];
                PrimjeniNiz[i] = Rezultat[i];
            }

            if (DuzinaPocetnogNiza % 2 == 1)
            {
                Rezultat[DuzinaPocetnogNiza / 2] = PrimjeniNiz[DuzinaPocetnogNiza / 2];
                PrimjeniNiz = Rezultat;
            }

            //Rez = int.Parse(string.Concat(Rezultat));

            return PrimjeniNiz;
        }

        private static int[] VratiNiz(int[] PrimjeniNiz)
        {
            int NovaVelicinaNiza = PrimjeniNiz.Length / 2 + PrimjeniNiz.Length % 2;
            int[] NoviAnaliziraniNiz = new int[NovaVelicinaNiza];

            Kalkulator(PrimjeniNiz);

            Array.Copy(PrimjeniNiz, NoviAnaliziraniNiz, Math.Min(PrimjeniNiz.Length, NovaVelicinaNiza));

            if (NoviAnaliziraniNiz.Length == 2)
            {
                return NoviAnaliziraniNiz;
            }

            Console.WriteLine(string.Join(" ", NoviAnaliziraniNiz));
            return VratiNiz(NoviAnaliziraniNiz);
        }

    }
}
