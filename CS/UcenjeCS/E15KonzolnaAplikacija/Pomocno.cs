namespace UcenjeCS.E15KonzolnaAplikacija
{
    // Utility = pomocno na eng

    internal class Pomocno
    {
        public static bool dev;

        public static int UcitajBrojRaspon(string poruka, string greska, int poc, int kraj)
        {
            int unos;

            while (true)
            {
                Console.Write(poruka);

                try
                {
                    unos = int.Parse(Console.ReadLine());

                    if (unos >= poc && unos <= kraj)
                    {
                        return unos;
                    }
                    Console.WriteLine(greska);

                }
                catch (Exception)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static int UcitajInt(string poruka, string greska)
        {
            int unos;

            while (true)
            {
                Console.Write(poruka);

                try
                {
                    unos = int.Parse(Console.ReadLine());

                    if (unos > 0)
                    {
                        return unos;
                    }
                    Console.WriteLine(greska);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static decimal UcitajDecimalniBroj(string poruka, string greska)
        {
            decimal unos;

            while (true)
            {
                Console.Write(poruka);

                try
                {
                    unos = decimal.Parse(Console.ReadLine());
                    if (unos > 0)
                    {
                        return unos;
                    }
                    Console.WriteLine(greska);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static string UcitajString(string poruka, string greska)
        {
            string unos;

            while (true)
            {
                Console.Write(poruka);
                unos = Console.ReadLine();

                if (unos.Trim().Length > 0)
                {
                    return unos;
                }
                Console.WriteLine(greska);

            }
        }

        public static bool UcitajBool(string poruka)
        {
            Console.Write(poruka);

            if (Console.ReadLine().Trim().ToLower().Equals("da"))
            {
                return true;
            }

            return false;
        }

        public static DateTime UcitajDatum(string poruka, string greska)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(poruka);
                    return DateTime.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static int ValidirajSifru<T>(string poruka, List<T> entiteti, Func<T, int> dohvatiSifru, int trenutnaSifra, string greska)
        {
            int unos;

            while (true)
            {
                unos = UcitajInt(poruka, greska);

                if ((trenutnaSifra == unos) || (!entiteti.Any(entitet => dohvatiSifru(entitet) == unos)))
                {
                    return unos;
                }

                Console.WriteLine("Šifra već postoji. Molimo unesite drugu.");

            }
        }


    }
}
