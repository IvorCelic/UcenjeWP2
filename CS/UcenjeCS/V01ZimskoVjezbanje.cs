namespace UcenjeCS
{
    internal class V01ZimskoVjezbanje
    {
        public static void Izvedi()
        {


            // ZAD 1
            Console.WriteLine("Napisati program koji ispisuje sve brojeve od 1 do 100.");
            Console.WriteLine(" ");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + 1);
            }


            Console.WriteLine(" ");
            Console.WriteLine("= = = = = = = = = =");
            Console.WriteLine(" ");


            // ZAD 2
            Console.WriteLine("Napisati program koji ispisuje sve brojeve od 100 do 1.");
            Console.WriteLine(" ");
            for (int i = 100; i > 0; i--)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine(" ");
            Console.WriteLine("= = = = = = = = = =");
            Console.WriteLine(" ");


            // ZAD 3
            Console.WriteLine("Napisati program koji ispisuje sve brojeve od 1 do 100 koji su cjelobrojno djeljivi s 7");

            for (int i = 0; i < 100; i += 7)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine(" ");
            Console.WriteLine("= = = = = = = = = =");
            Console.WriteLine(" ");


            // ZAD 4
            Console.WriteLine("Napisati program koji unosi brojeve sve dok ne unese broje veći od 100,");
            Console.WriteLine("a zatim ispisuje koliko je bilo pokušaja unosa.");
            int Broj;
            for (int Brojac = 1; ; )
            {
                Console.Write("Unesite broj veći od 100: ");
                Broj = int.Parse(Console.ReadLine());
                if (Broj < 101)
                {
                    Brojac++;
                    Console.WriteLine("Krivi unos!");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Unjeli ste: {Broj} iz {Brojac}. pokušaja.");
                    Brojac = 1;
                }
                continue;
            }



        }
    }
}
