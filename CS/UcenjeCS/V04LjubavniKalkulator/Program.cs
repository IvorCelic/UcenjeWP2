namespace UcenjeCS.V04LjubavniKalkulator
{
    internal class Program
    {
        public static void Izvedi()
        {
            Console.WriteLine("Hello, World!");

            Ljubav();
        }

        private static void Ljubav()
        {
            LjubavniKalkulator ljubavniKalkulator = new();

            ljubavniKalkulator.PrvoIme = Unos("Unesite prvo ime: ");
            ljubavniKalkulator.DrugoIme = Unos("Unesite drugo ime: ");
        }

        private static string Unos(string poruka)
        {
            string unos;

            while (true)
            {
                Console.WriteLine(poruka);
                unos = Console.ReadLine();

                if (unos.Trim().Length == 0)
                {
                    Console.WriteLine("Morate unijeti ime!");
                    continue;
                }

                return unos;
            }
        }


    }
}
