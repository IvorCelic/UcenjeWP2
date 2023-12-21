namespace UcenjeCS
{
    internal class E05ForPetlja
    {
        public static void Izvedi()
        {
            // for (od kuda; do kuda; uvećanje/umanjenje) -> FORMULA


            // Ispisati 10 puta Edunova

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Edunova");
                }

                // Varijabla je izvan petlje
                int t;
                for (t = 0; t < 10;t++)
                {
                    Console.WriteLine("Edunova T");
                }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Varijabla u petlji mijenja vrijednost
                for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i+1);
                    }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Umanjenje
                for (int i = 10; i > 10; i--)
                    {
                        Console.WriteLine(i);
                    }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Korak uvećanja/umanjenja može biti veći od 1
                for (int i = 0; i < 20; i += 2)
                    {
                        Console.WriteLine(i);
                    }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Ispisati sve parne brojeve između __ i __

                int ukpb = 24; // Unjeo Korisnik Prvi Broj
                int ukdb = 78;

                int lower = ukpb < ukdb ? ukpb : ukdb;
                int bigger = ukpb>ukdb ? ukpb: ukdb;
            

                // Ispisuje da nema parnih brojeva
                if (lower == bigger && lower %2!= 0)
                {
                    Console.WriteLine("Unjeli ste iste brojeve.");
                }

                for (int i = lower; i <= bigger; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Tablica množenja
                // DZ -> popraviti formatiranje
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write((i + 1) * (j + 1) + " ");
                    }
                    Console.WriteLine();
                }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Petlja se može preskočiti
            for (int i = 0; i < 10; i++)
                {
                    if (i % 3 == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(i);
                }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");



            // DZ -> iz unutarnje petlje prekini vanjsku
            // Petlja se može nasilno prekinuti
                for (int i = 0; i < 10; i++)
                {
                    if (i == 3)
                    {
                        break;
                    }

                    Console.WriteLine(i);
                }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // Beskonačna petlja
                for (; ; )
                {
                    Console.WriteLine(new Random().Next(10, 100));
                    Thread.Sleep(100);
                    break;
            }


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // za uneseni broj između 1 i 10
            // ispiši taj broj na kvadrat
            //int broj;
            //for (; ; )
            //{
            //    Console.Write("unesi broj između 1 i 10: ");
            //    broj = int.Parse(Console.ReadLine());
            //    if (broj >= 1 && broj <= 10)
            //    {
            //        break;
            //    }

            //    Console.WriteLine("krivi unos!");
            //}

            //Console.WriteLine(broj * broj);


            Console.WriteLine("");
            Console.WriteLine(" **********");
            Console.WriteLine("");


            // 9 različitih načina zbrajanja prvih 100 brojeva
                int i, s = 0; for (i = 1; i <= 100; i++) s += i;

                //int i, s; for (i = 1, s = 0; i <= 100; s += i, i++) ;

                //int i = 1, s = 0; for (; i <= 100; i++) { s += i; }

                //int i, s = 0; for (i = 1; ; i++) { if (i <= 100) s += i; else break; }

                //int i, s = 0; for (i = 1; i <= 100;) { s += i; i++; }

                //int i, s = 0; for (i = 1; ;) { if (i <= 100) { s += i; i++; } else break; }

                //int i = 1, s = 0; for (; i <= 100;) { s += i; i++; }

                //int i = 1, s = 0; for (; ; i++) { if (i <= 100) s += i; else break; }

                //int i = 1, s = 0; for (; ; ) { if (i <= 100) { s += i; i++; } else break; }


            Console.WriteLine("");
            Console.WriteLine(" **********"); 
            Console.WriteLine("");


        }
    }
}
