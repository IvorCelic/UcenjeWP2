namespace UcenjeCS.V04LjubavniKalkulator
{
    internal class Program
    {
        public static void Izvedi()
        {
            Ljubav();
        }

        private static void Ljubav()
        {
            LjubavniKalkulator ljubavniKalkulator = new();

            ljubavniKalkulator.PrvoIme = Unos("Unesite prvo ime: ");
            ljubavniKalkulator.DrugoIme = Unos("Unesite drugo ime: ");

            int[] prvoImePrebroj = PrebrojSlova(ljubavniKalkulator.PrvoIme);
            int[] drugoImePrebroj = PrebrojSlova(ljubavniKalkulator.DrugoIme);

            Console.WriteLine(prvoImePrebroj);
            Console.WriteLine(drugoImePrebroj);
        }

        private static string Unos(string poruka)
        {
            int[] Slova = new int[Unos(poruka).Length];
            int Index = 0;
            int Ukupno;
            string unos;

            while (true)
            {
                Console.Write(poruka);
                unos = Console.ReadLine();

                if (unos.Trim().Length == 0)
                {
                    Console.WriteLine("Morate unijeti ime!");
                    continue;
                }

                return string.Join(",", Slova);
            }

        }

        private static int[] PrebrojSlova(string unos)
        {
            int[] prebrojSlova = new int[unos.Length];

            for (int i = 0; i < unos.Length; i++)
            {
                int Ukupno = 0;
                foreach (char c in unos)
                {
                    if (unos[i] == c)
                    {
                        Ukupno++;
                    }
                }

                prebrojSlova[i] = Ukupno;
            }

            return prebrojSlova;
        }


    }
}
