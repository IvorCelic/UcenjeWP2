namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Predavac : Osoba
    {
        public string Iban { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

    }


}
