namespace UcenjeCS.V04LjubavniKalkulator
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
            Console.WriteLine(new LjubavniKalkulator(Unos("Prvo ime: "), Unos("Drugo ime: ")).Rezultat());
        }
    }
}
