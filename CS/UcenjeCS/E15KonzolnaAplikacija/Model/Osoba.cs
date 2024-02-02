namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal abstract class Osoba : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }

    }
}
