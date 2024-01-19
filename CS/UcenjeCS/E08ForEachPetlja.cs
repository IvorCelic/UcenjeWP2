namespace UcenjeCS
{
    internal class E08ForEachPetlja
    {
        public static void Izvedi()
        {
            int[] Niz = { 1, 2, 3, };

            for (int i = 0; i < Niz.Length; i++)
            {
                Console.WriteLine(Niz[i]);
            }

            // Gornji kod je ekvivalent donjem

            foreach (int Element in Niz)
            {
                Console.WriteLine(Element);
            }

            // Sve ostale značajke petlji jednako funkcioniraju

            Console.WriteLine("========================");

            // TIP PODATKA STRING
            string Ime = "Edunova";
            Console.WriteLine(Ime);
            foreach (char c in Ime)
            {
                Console.WriteLine(c + ": " + (int)c);
            }

            Console.WriteLine("========================");

            // Korisnik unosi tekst a program ispisuje koje slovo je unio koliko puta
            Console.WriteLine("Unesite neki tekst: ");
            string Unos = Console.ReadLine();
            int[] Slova = new int[Unos.Length];
            int Index = 0;
            int Ukupno;

            foreach (char c in Unos)
            {
                Ukupno = 0;
                foreach(char cc in Unos)
                {
                    if (c == cc)
                    {
                        Ukupno++;
                    }
                }
                Slova[Index++] = Ukupno;
            }

            Console.WriteLine(string.Join(",", Slova));

            char[] JedinstvenaSlova = new char[Unos.Length]; // Ne treba mi toliko prostora,
            bool Postoji;                                    // Najveći nedostatak nizova je taj što se na početku mora reći koliko
            Index = 0;
            
            foreach (char c in Unos)
            {
                Postoji = false;
                foreach (char cc in JedinstvenaSlova)
                {
                    if (c == cc)
                    {
                        Postoji = true;
                        break;
                    }
                }
                
                if (!Postoji)
                {
                    JedinstvenaSlova[Index++] = c;
                }
            }

            Console.WriteLine(string.Join(",", JedinstvenaSlova));

            foreach (char c in JedinstvenaSlova)
            {
                Console.Write(c + " ");
                Index = 0;
                foreach (char cc in Unos)
                {
                    if (c == cc)
                    {
                        Console.WriteLine(Slova[Index]);
                        break; 
                    }
                    Index++;
                }
            }
        }
    }
}
