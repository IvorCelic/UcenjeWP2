namespace UcenjeCS
{
    internal class E11Rekurzija
    {

        public static void Izvedi()
        {
            // Rekurzija je kada metoda zove samu sebe

            // Izvedi(); // Dobijamo StackOverFlow iznimku ako nema uvjeta (radi beskonačno)

            Console.WriteLine(Zbroj(100));

        }

        private static int Zbroj(int v)
        {
            // Uvjet prekida rekurzije
            if (v == 1)
            {
                return 1;
            }

            return v + Zbroj(v - 1);

        }
    }
}
