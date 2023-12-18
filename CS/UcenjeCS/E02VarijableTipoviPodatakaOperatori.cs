namespace UcenjeCS
{
    internal class E02VarijableTipoviPodatakaOperatori
    {
        public static void Izvedi()
        {
            int Varijabla = 3;

            Console.WriteLine(Varijabla);

            int i=1, j=0, k;

            Console.WriteLine("{0},{1}", i, j);

            bool Istina = i == 1;

            Console.WriteLine(Istina);

            double Broj = 4.89;
            decimal VeciBroj = 2.99M;

            Console.WriteLine(int.MaxValue);
            int Mv = int.MaxValue;
            Console.WriteLine(Mv+1);

            i = 3; j = 2; k = 1;

            Console.WriteLine(i + j);
            Console.WriteLine(i - j);
            Console.WriteLine(i * j);
            Console.WriteLine(i / j);
            Console.WriteLine((float)i/j); // dijeljenje s decimalnim rezultatom

            // Za dvoznamenkasti broj ispiši prvu znamenku
            int db = 56;
            Console.WriteLine(db/10);

            bool Uvjet = i > j;
            Uvjet = i >= j;
            Uvjet = i <= j;
            Uvjet = i < j;
            Uvjet = i == j; //provjera jednakosti
            Uvjet = i != j; //provjera nejednakosti


            // operator mmodulo
            // ostatak nakon cjelobrojnog dijeljenja
            int Ostatak = 9 % 2;

                // za dvoznamenkasti broj ispiši vrijednost jedinice
                Console.WriteLine(52 % 10);

            i = 1;
            Console.WriteLine(i); //1
            i = i + 1; // uvećavam za 1
            Console.WriteLine(i); //2
            i += 1; // uvećavam za 1
            Console.WriteLine(i); //3
            i++; // uvećavam za 1
            Console.WriteLine(i); //4

            // specifičnosti incrementa ++
                // i++ prvo koristi trenutnu vrijednost pa onda uvećava
            Console.WriteLine(i++); //4
            Console.WriteLine(i); //5
                // ++i prvo uvećava pa onda koristi trenutnu vrijednost
            Console.WriteLine(++i); //6
            Console.WriteLine(i); //6

            // SVE VRIJEDI ISTOVJETNO i ZA DEKREMENT (--)



            // PRIMJER ZADATKA ZA VJEŽBATI
            // prvo postaviti zadatak pa za 15tak minuta riješiti
            int t = 1, l = 2;
            t = ++t - l;
            Console.WriteLine("t = ++t - l => t={0}, l={1}", t, l);

            l -= t - l;
            Console.WriteLine("l -= t - l => t={0}, l={1}", t, l);

            Console.WriteLine(++t - --l);
            Console.WriteLine("++t - --l => t={0}, l={1}", t, l); 


        }
    }
}
