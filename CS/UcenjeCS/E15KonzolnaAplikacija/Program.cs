using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class Program
    {
        private List<Smjer> Smjerovi;

        public Program()
        {
            Smjerovi = new List<Smjer>();
            PozdravnaPoruka();
            Izbornik();
        }

        private void Izbornik()
        {
            Console.WriteLine("Izbornik");
            Console.WriteLine("1. Rad sa smjerovima");
            Console.WriteLine("2. Rad s predavačima");
            Console.WriteLine("3. Rad s polaznicima");
            Console.WriteLine("4. Rad s grupama");
            Console.WriteLine("5. Izlaz iz programa");

            OdabirStavkeIzbornika();

        }

        private void OdabirStavkeIzbornika()
        {
            // var Izbor = Pomocno.UcitajInt("Unesi izbor: ");

            switch (Pomocno.UcitajInt("Unesi izbor: "))
            {
                case 1:
                    Console.WriteLine("Odabrali ste rad sa smjerovima");
                    IzbornikRadSaSmjerovima();
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
                default:
                    Console.WriteLine("Krivi odabir");
                    Izbornik();
                    break;
            }
        }

        private void IzbornikRadSaSmjerovima()
        {
            Console.WriteLine("1. Prikaži sve smjerove");
            Console.WriteLine("2. Dodaj smjer");
            Console.WriteLine("3. Uredi smjer");
            Console.WriteLine("4. Obriši smjer");
            Console.WriteLine("5. Povratak na glavni izbornik");

            OdabirStavkeIzbornikaSmjera();
        }

        private void OdabirStavkeIzbornikaSmjera()
        {
            switch (Pomocno.UcitajInt("Unesi izbor: "))
            {
                case 1:
                    Console.WriteLine("Prikažite sve smjerove: ");
                    PrikaziSveSmjerove();
                    IzbornikRadSaSmjerovima();
                    break;
                case 2:
                    Console.WriteLine("Dodajte novi smjer: ");
                    DodajNoviSmjer();
                    break;
                case 3:
                    Console.WriteLine("Uredite smjer: ");
                    UrediSmjer();
                    break;
                case 4:
                    Console.WriteLine("Obrišite smjer: ");
                    IzbrisiSmjer();
                    break;
                case 5:
                    Console.WriteLine("Povratak na glavni izbornik");
                    Izbornik();
                    break;
                default:
                    Console.WriteLine("Krivi odabir");
                    IzbornikRadSaSmjerovima();
                    break;
            }
        }

        private void IzbrisiSmjer()
        {
            PrikaziSveSmjerove();
            Smjerovi.RemoveAt(Pomocno.UcitajInt("Odaberi smjer za brisanje: ") - 1);
            IzbornikRadSaSmjerovima();
        }

        private void UrediSmjer()
        {
            PrikaziSveSmjerove();
            var s = Smjerovi[Pomocno.UcitajInt("Odaberi smjer za promjenu: ") - 1];

            s.Sifra = Pomocno.UcitajInt(s.Sifra + "Unesi promjenjenu šifru: ");
            s.Naziv = Pomocno.UcitajString(s.Naziv + "Unesi promjenjeni naziv: ");
            IzbornikRadSaSmjerovima();
        }

        private void PrikaziSveSmjerove()
        {
            var i = 0;

            Smjerovi.ForEach(s =>
            {
                Console.WriteLine(++i + ". " + s);
            });
        }

        private void DodajNoviSmjer()
        {
            Smjerovi.Add(new Smjer
            {
                Sifra = Pomocno.UcitajInt("Unesi šifru smjera: "),
                Naziv = Pomocno.UcitajString("Unesi naziv smjera: "),
                // Učitati ostale vrijednosti
            });
            IzbornikRadSaSmjerovima();

        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("* EDUNOVA KONZOLNA APLIKACIJA v1 *");
            Console.WriteLine("**********************************");
        }
    }
}
