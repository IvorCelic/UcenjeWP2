﻿namespace UcenjeCS.V04LjubavniKalkulator
{

    // Upiši dva imena, potom ispod svakog slova ispiši koliko se puta ono ponavlja.
    // Zbroji prvi broj ispod prvog imena i zadnji broj ispod drugog imena, tako ponovi sa svakim sljedećim brojem.
    // Kada završiš s prvim retkom, prijeđi u drugi , pa u treći, itd.. Na kraju dobiti ćeš 100 ili manji postotak zaljubljenosti.

    internal class LjubavniKalkulator
    {
        public string PrvoIme { get; set; }
        public string DrugoIme { get; set; }

        public LjubavniKalkulator()
        { 
            
        }

        public LjubavniKalkulator(string prvoIme, string drugoIme)
        {
            PrvoIme = prvoIme;
            DrugoIme = drugoIme;
        }

        public string Rezultat()
        {
            return Izracunaj(SlovaNiz(PrvoIme+DrugoIme)) + " %";
        }

        private int Izracunaj(int[] brojevi)
        {
            int rezultat;
            int[] zbrojevi;

            while (brojevi.Length >= 3)
            {
                zbrojevi = new int[brojevi.Length / 2 + brojevi.Length % 2];

                for (int i = 0; i < (brojevi.Length + 1) / 2; i++)
                {
                    int sum = brojevi[i] + brojevi[brojevi.Length - 1 - i];

                    if (i >= (brojevi.Length - 1) / 2 && brojevi.Length % 2 != 0)
                    {
                        zbrojevi[i] = brojevi[i];
                    }
                    else if (sum >= 10)
                    {
                        Splitter(zbrojevi, i, sum);
                        i++;
                    }
                    else
                    {
                        zbrojevi[i] = sum;
                    }

                }

                Console.WriteLine(string.Join(",", zbrojevi));

                brojevi = zbrojevi;
            }

            int[] intBrojevi = brojevi;

            rezultat = KonvertNiz(intBrojevi);

            return rezultat;
        }

        private int KonvertNiz(int[] niz)
        {
            string stringNiz = string.Join("", niz);

            int rezultat = int.Parse(stringNiz);

            return rezultat;
        }

        private int[] Splitter(int[] niz, int index, int sum)
        {
            niz[index] = sum / 10;
            niz[index + 1] = sum % 10;

            return niz;
        }

        private int[] SlovaNiz(string imena)
        {
            int Ukupno;
            int Index = 0;
            imena = imena.Replace(" ", "").ToLower();

            int[] brojevi = new int[imena.Length];

            foreach (char c in imena)
            {
                Ukupno = 0;
                foreach (char cc in imena)
                {
                    if (c == cc)
                    {
                        Ukupno++;
                    }
                }
                brojevi[Index++] = Ukupno;
            }

            Console.WriteLine(imena);
            Console.WriteLine(string.Join(",", brojevi));

            return brojevi;
        }
    }
}
