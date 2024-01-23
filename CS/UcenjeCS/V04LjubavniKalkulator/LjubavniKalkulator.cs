﻿using System.Diagnostics.CodeAnalysis;

namespace UcenjeCS.V04LjubavniKalkulator
{

    // Upiši dva imena, potom u novi niz ispiši koliko se puta svako slovo ponovilo
    // Zbroji prvi i zadnji element, pa drugi i predzadnji, itd. Ako je zadnji element neparan prepiši ga.
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
            if (brojevi.Length < 3) // Ako niz ima dva elementa onda prekini sa rekurzijom i vrati KonvertNiz
            {
                return FinalNiz(brojevi);
            }

            int[] zbrojevi = new int[brojevi.Length / 2 + brojevi.Length % 2]; // Zbraja prvi i zadnji element niza

            for (int i = 0; i < (brojevi.Length + 1) / 2; i++)
            {
                int sum = brojevi[i] + brojevi[brojevi.Length - 1 - i];

                if (i >= (brojevi.Length - 1) / 2 && brojevi.Length % 2 != 0) // Ako 'i' nema para
                {
                    zbrojevi[i] = brojevi[i]; // Prepiši 'i'
                }
                else
                {
                    zbrojevi[i] = sum; // Zbroji prvi i zadnji element
                }

            }

            Console.WriteLine(string.Join(",", zbrojevi));

            // Svaki puta kada se dogodi rekurzija, prvo se odradi ProvjeraDvoznamenkastogBroja
            return Izracunaj(KonvertNiz(zbrojevi)); // Rekurzivni način metode izračunaj
        }

        private int[] KonvertNiz(int[] brojevi) // Radi isto kao i ProvjeraDvoznamenkastogBroja samo bez lambde
        {
            int maksimalnaDuzina = brojevi.Length * 2;
            int[] rezultat = new int[maksimalnaDuzina];
            int Index = 0;

            foreach (int num in brojevi) // Za svaki element u brojevi
            {
                if (num < 10) // Ako je rezultat manji od 10 onda ispiši element u rezultat
                {
                    rezultat[Index++] = num;
                }
                else // Razdvoji element na deseticu i jedinicu pa upiši u rezultat pazeći na Index
                {
                    int Desetica = num / 10;
                    int Jedinica = num % 10;

                    rezultat[Index++] = Desetica;
                    rezultat[Index++] = Jedinica;
                }

            }

            Array.Resize(ref rezultat, Index); // Reže niz na točnu veličinu, odnosno koliki je Index tolika je veličina niza

            return rezultat;
        }

        private int[] ProvjeraDvoznamenkastogBroja(int[] brojevi) // Pretvara niz u string bez zareza i vraća ga nazad u int
        {
            // Nez kako drukčije LOL
            // Koristio lambdu a pretpostavljam, ne smijemo.

            string[] stringNiz = Array.ConvertAll(brojevi, x => x.ToString());

            string spojeniNiz = string.Join("", stringNiz);

            int[] intNiz = spojeniNiz.Select(c => int.Parse(c.ToString())).ToArray();

            return intNiz;
        }

        private int FinalNiz(int[] niz) // Briše zareze iz niza
        {
            string stringNiz = string.Join("", niz);

            int rezultat = int.Parse(stringNiz);

            return rezultat;
        }

        private int[] SlovaNiz(string imena) // Vraća niz koji se sastoji od broja ponavljanja svakog slova
        {
            int Ukupno;
            int Index = 0;
            imena = imena.Replace(" ", "").ToLower(); // Briše zareze iz imena

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
            Console.WriteLine(string.Join(",", brojevi)); // Odvaja elemente sa zarezom

            return brojevi;
        }
    }
}
