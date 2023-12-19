namespace UcenjeCS
{
    internal class E03UvjetnaGrananja
    {
        public static void Izvedi()
        {
            int i = 7; // Namjerno ne radim čitanje iz konzole kako bi

            // Binarno grananje

            bool Uvjet = i == 7;


            // Uvjet ima vrijednost true
            if(Uvjet)
            {
                Console.WriteLine("Ušao sam u true dio if naredbe");
            }

            // Ovo gore i sada sljedeće je minimalni dio if naredbe
            // Inače se u pravilu ovako piše
            if(i == 7)
            {
                Console.WriteLine("Isti uvjet kao i prethodno");
            }


            // Drugi dio if naredbe (neobavezni) ELSE
            if (i < 5)
            {
                Console.WriteLine("i je manji od 5");
            }
            else
            {
                Console.WriteLine("i nije manje od 5");
            }


            // Puni izgled if naredbe
            if(i == 2)
            {
                Console.WriteLine("i je 2");
            } else if (i == 3)
            {
                Console.WriteLine(3);
            } else
            {
                Console.WriteLine("i nije 2 niti je 3");
            }

            int j = 2;
            if (i == 7)
            {
                if (j == 2)
                {
                    Console.WriteLine("Oba uvjeta su zadovoljena ugnježđeno");
                }
            }


            // Korištenje logičkih operatora

                // Logičko & i uvjetovano &&
                i = 5;
                if (i == 7 & j == 2)
                {
                    Console.WriteLine("Oba uvjeta su zadovoljena");
                }
                // & -> Provjeravaju se oba uvjeta bez obzira ako se na prvom padne

                if (i == 7 && j == 2)
                {
                    Console.WriteLine("Oba uvjeta su zadovoljena");
                }
                // && -> Ukoliko padne (false) na prvom uvjetu, ne provjerava se drugi


                // Logičko | i uvjetovano ||
                if (i == 5 | j == 1)
                {
                    Console.WriteLine("Dovoljno je da jedan od uvjeta bude zadovoljen");
                }
                // | -> Provjerava oba uvjeta bez obzira ako je prvi prošao (true)

                if (i == 5 || j == 1)
                {
                    Console.WriteLine("Ako je prvi uvjet zadovoljen, drugi se ne provjerava");
                }
                // || -> Ukoliko prvi uvjet prođe (true), drugi se ne provjerava


                // Logično NE
                if ((i == 4 || j == 1) && !(i>5 || j<8))
                {
                    Console.WriteLine("Komplicirani izraz");
                }
            // Riješava se matematičkim slijedom


            // Skraćeni način pisanja: inline if

            // Program ispisuje cijeli broj
            // Ako je broj veći od 10 ispisuje Osijek
            // Inače ispisuje Zagreb

            Console.Write("Unesi cijeli broj: ");
            int Broj = int.Parse(Console.ReadLine());

            if (Broj > 10)
            {
                Console.WriteLine("Osijek");
            }else
            {
                Console.WriteLine("Zagreb");
            }

            // U slučaju isto ponašanja s različitim vrijednostima u if i else dijelu
            // možemo pisati kraće

            // INLINE IF -> CW(uvjet ? TRUE dio : FALSE dio
            Console.WriteLine(i>10 ? "Osijek" : "Zagreb");



            // VIŠESTRUKO GRANANJE
            int Ocjena = 4;
            switch(Ocjena)
            {
                case 1:
                    Console.WriteLine("Nedovoljan");
                    break;
                case 2: case 3:
                    Console.WriteLine("Dovoljno ili dobro");
                    break;
                case 4: case 5:
                    Console.WriteLine("To je ocjena");
                    break;
                default:
                    Console.WriteLine("Nije ocjena");
                    break;
            }

            string ime = "Pero";
            switch (ime)
            {
                case "Marko":
                    Console.WriteLine("OK");
                    break;
                case "Pero":
                    Console.WriteLine("Super");
                    break;
            }

        }
    }
}
