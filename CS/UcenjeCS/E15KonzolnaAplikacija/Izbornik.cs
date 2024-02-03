namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class Izbornik
    {
        public ObradaSmjer ObradaSmjer { get; }
        public ObradaPredavac ObradaPredavac { get; set; }
        private ObradaGrupa ObradaGrupa { get; set; }
        public ObradaPolaznik ObradaPolaznik { get; set; }

        public Izbornik()
        {
            Pomocno.dev = true;
            ObradaSmjer = new ObradaSmjer();
            ObradaPredavac = new ObradaPredavac();
            ObradaGrupa = new ObradaGrupa(this);
            ObradaPolaznik = new ObradaPolaznik();

            PozdravnaPoruka();
            PrikaziIzbornik();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine(" ____________________________________ ");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|   EDUNOVA KONZOLNA APLIKACIJA v1   |");
            Console.WriteLine("|____________________________________|");
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("--------");
            Console.WriteLine("Izbornik");
            Console.WriteLine("--------");
            Console.WriteLine("1. Rad sa smjerovima");
            Console.WriteLine("2. Rad s predavačima");
            Console.WriteLine("3. Rad s polaznicima");
            Console.WriteLine("4. Rad s grupama");
            Console.WriteLine("5. Izlaz iz programa");
            Console.WriteLine("");

            switch (Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, 5))
            {
                case 1:
                    Console.WriteLine("Odabrali ste rad sa smjerovima");
                    ObradaSmjer.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.WriteLine("Odabrali ste rad s predavačima");
                    ObradaPredavac.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.WriteLine("Odabrali ste rad s polaznicima");
                    ObradaPolaznik.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.WriteLine("Odabrali ste rad s grupama");
                    ObradaGrupa.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Izlazite iz programa.");
                    break;
            }
        }

    }
}
