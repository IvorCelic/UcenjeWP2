using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.V04LjubavniKalkulatorMiloloza
{
    internal class LjubavniKalkulatorMiloloza
    {
        public string PrvoIme { get; set; }
        public string DrugoIme { get; set; }


        public LjubavniKalkulatorMiloloza() 
        {
        
        }


        public LjubavniKalkulatorMiloloza(string prvoIme, string drugoIme)
        { 
            PrvoIme = prvoIme;
            DrugoIme = drugoIme;
        }


        public string Rezultat()
        {
            return Izracunaj(SlovaUNiz(PrvoIme + DrugoIme)) + " %";
        }


        private int[] SlovaUNiz(string Imena)
        {
            //Spajam imena u jedan string i prebacujem u znakovni niz
            string SpojImena = PrvoIme.Trim().ToLower() + DrugoIme.Trim().ToLower();
            char[] ZnakovniNiz = SpojImena.ToCharArray();

            //Kreiram brojevni niz dužine znakovnog niza
            int[] BrojevniNiz = new int[ZnakovniNiz.Length];
            int Zbroj;
            int index = 0;

            //Prebrojavam elemente znakovnog niza i zapisujem u brojevni niz 
            foreach (char c in ZnakovniNiz)
            {
                Zbroj = 0;
                foreach (char cc in ZnakovniNiz)
                {
                    if (c == cc)
                    {
                        Zbroj++;
                    }
                }
                BrojevniNiz[index++] = Zbroj;
            }

            Console.WriteLine(SpojImena);

            return BrojevniNiz;

        }

        private int Izracunaj(int[] BrojevniNiz)
        {

            int Rezultat = 0;
            int[] NoviNiz;

            //Kreiram NoviNiz upola manji od BrojevnogNiza ako je ovaj paran
            //Ili upola + 1 ako je BrojevniNiz neparan
            if (BrojevniNiz.Length % 2 == 0)
            {
                NoviNiz = new int[BrojevniNiz.Length / 2];
            }
            else
            {
                NoviNiz = new int[(BrojevniNiz.Length / 2) + 1];
            }

            //Zbrajam elemente BrojevnogNiza do sredine
            //(ako je niz neparan, središnji element ne diram)
            for (int i = 0, j = BrojevniNiz.Length - 1; i < BrojevniNiz.Length / 2 && j >= BrojevniNiz.Length / 2; i++, j--)
            {
                NoviNiz[i] = BrojevniNiz[i] + BrojevniNiz[j];
            }
            
            //Ako je BrojevniNiz neparan, središnji element stavljam na kraj NovogNiza
            if (BrojevniNiz.Length % 2 != 0)
            {
                NoviNiz[NoviNiz.Length - 1] = BrojevniNiz[(BrojevniNiz.Length / 2) + 1];
            }
            
            //Prebacujem NoviNiz u string da bi se riješio dvoznamenkastih brojeva
            //i provjeravam Rezultat
            string Brojevi = string.Join("", NoviNiz);
            Rezultat = Int32.Parse(Brojevi);
            if (Rezultat > 100)
            {
                NoviNiz = Brojevi.Select(c => Convert.ToInt32(c.ToString())).ToArray();
                Izracunaj(NoviNiz);
            }
            
            return Rezultat;

        }

    }
}
