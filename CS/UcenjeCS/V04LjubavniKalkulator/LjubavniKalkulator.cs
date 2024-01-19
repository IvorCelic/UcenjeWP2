namespace UcenjeCS.V04LjubavniKalkulator
{

    // Upiši dva imena, potom ispod svakog slova ispiši koliko se puta ono ponavlja.
    // Zbroji prvi broj ispod prvog imena i zadnji broj ispod drugog imena, tako ponovi sa svakim sljedećim brojem.
    // Kada završiš s prvim retkom, prijeđi u drugi , pa u treći, itd.. Na kraju dobiti ćeš 100 ili manji postotak zaljubljenosti.

    internal class LjubavniKalkulator
    {
        public string PrvoIme { get; set; }
        public string DrugoIme { get; set; }

        public LjubavniKalkulator()
        { 
            
        }

        public LjubavniKalkulator(string prvoIme, string drugoIme)
        {
            PrvoIme = prvoIme;
            DrugoIme = drugoIme;
        }

    }
}
