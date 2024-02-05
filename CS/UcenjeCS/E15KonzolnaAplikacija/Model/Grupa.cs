namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Grupa : Entitet
    {
        public string Naziv { get; set; }
        public Predavac Predavac { get; set; }
        public Smjer Smjer { get; set; }
        public int MaksimalnoPolaznika { get; set; }
        public DateTime DatumPocetka { get; set; }
        public List<Polaznik> Polaznici { get; set; }
        
        public Grupa()
        {
            Polaznici = new List<Polaznik>();
        }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
