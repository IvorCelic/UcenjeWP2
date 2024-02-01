using UcenjeCS.E15KonzolnaAplikacija;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class Izbornik
    {
        public ObradaSmjer ObradaSmjer { get; }
        public Izbornik()
        {
            Pomocno.dev = true;
            ObradaSmjer = new ObradaSmjer();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("* EDUNOVA KONZOLNA APLIKACIJA v1 *");
            Console.WriteLine("**********************************");
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
                    break;
                case 3:
                    Console.WriteLine("Odabrali ste rad s polaznicima");
                    break;
                case 4:
                    Console.WriteLine("Odabrali ste rad s grupama");
                    break;
                case 5:
                    Console.WriteLine("Izlazite iz programa.");
                    break;
            }
        }

    }
}
