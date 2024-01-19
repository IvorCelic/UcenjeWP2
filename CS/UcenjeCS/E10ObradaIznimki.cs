namespace UcenjeCS
{
    internal class E10ObradaIznimki
    {

        public static void Izvedi()
        {

            // Program prvo unosi prvi broj, pa drugi broj i ispisuje brojeve između prvog i drugog broja a koristi metode, try catch i beskonačnu petlju
            int pb = UcitajBroj("Unesi prvi broj: ");
            int db = UcitajBroj("Unesi drugi broj: ");
            IspisiBrojeve(pb, db);


        }

        private static void IspisiBrojeve(int pb, int db)
        {
            var Manji = pb <= db ? pb : db;
            var Veci = pb >= db ? pb : db;

            for (int i = Manji; i <= Veci; i++)
            {
                Console.WriteLine(i);
            }

        }

        private static int UcitajBroj(string v)
        {
            for (; ; )
            {
                Console.Write(v);

                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Nisi unio broj.");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Nešto gadno ne valja.");
                }
                // Može još uhvatiti i ArgumentNullException
                catch (Exception) // Pomoću Exception hvata bilo koju iznimku koja nije prethodno definirana
                {
                    Console.WriteLine("Ooops! :(");
                }
                finally
                {
                    Console.WriteLine("Mjesto na koje se dolazi pukao ti ili ne.");
                }

            }


        }
    }
}
