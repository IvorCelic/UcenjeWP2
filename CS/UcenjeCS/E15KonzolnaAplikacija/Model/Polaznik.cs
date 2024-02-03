namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Polaznik : Osoba
    {
        public string BrojUgovora { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
