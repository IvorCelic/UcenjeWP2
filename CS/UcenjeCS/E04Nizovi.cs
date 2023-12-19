namespace UcenjeCS
{
    internal class E04Nizovi
    {
        public static void Izvedi()
        {
            // Kreirao sam niz s 12 elemenata
            int[] Temperature = new int[12];

            // Prvi element niza je na indexu 0

            // Siječanj
            Temperature[0] = 2;
            // Veljača
            Temperature[1] = 1;
            // ... idu ostali mjeseci
            // Prosinac
            Temperature[11] = 7;

            Console.WriteLine(Temperature);
            Console.WriteLine(string.Join(",", Temperature));


            // Višedimenzionalni nizovi
            int[,] Tablica =
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };

                // Ispisati broj 5
                Console.WriteLine(Tablica[1, 1]);
                // Ispisati broj 9
                Console.WriteLine(Tablica[2, 2]);


            // Trodimenzionalni niz - kocka
            int[,,] Kocka;

            // Zvjezdane staze
            int[,,,,,] ZvjezdaneStaze;

        }
    }
}
