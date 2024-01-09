using System.Security.Cryptography.X509Certificates;

namespace UcenjeCS
{
    internal class E07DoWhilePetlja
    {
        public static void Izvedi()
        {
            // Je li se u FOR i WHILE mora ući ?
            // Ako uvjet na početku nije zadovoljen ne ulazi se

            // DO WHILE osigurava minimalno jedno izvođenje
            // uvjet je na kraju petlje

            // Beskonačna petlja
            do
            {
                Console.WriteLine("Edunova");
            } while (false);

            // CONTINUE, BREAK i UGNJEŽĐIVANJE kao kod i WHILE petlje

            // Prekidanje vanjske petlje
            for (; ; )
            {
                while (true)
                {
                    do
                    {
                        // break; // 1
                        goto nakonfor;
                    } while (true);
                    // ovdje se nastavlja 1
                    // break; // 2
                }
                // ovdje se nastavlja 2
            }
            nakonfor: // Ovo je labela
            Console.WriteLine("odradio");
        }
    }
}
