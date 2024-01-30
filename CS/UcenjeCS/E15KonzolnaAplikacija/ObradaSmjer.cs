using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class ObradaSmjer
    {
        public List<Smjer> Smjerovi { get; }

        public ObradaSmjer()
        {
            Smjerovi = new List<Smjer>();
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Izbornik rada sa smjerovima");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Prikaži sve smjerove");
            Console.WriteLine("2. Dodaj smjer");
            Console.WriteLine("3. Uredi smjer");
            Console.WriteLine("4. Obriši smjer");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("");

            switch (Pomocno.UcitajInt("Unesi izbor: "))
            {
                case 1:
                    PrikaziSveSmjerove();
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajNoviSmjer();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediSmjer();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiSmjer();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Povratak na glavni izbornik");
                    break;
            }
        }

        private void ObrisiSmjer()
        {
            if (Smjerovi.Count > 0)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Brisanje smjera");
                Console.WriteLine("---------------");

                PrikaziSveSmjerove();

                int index = Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, Smjerovi.Count());
                Smjerovi.RemoveAt(index - 1);
            }

            Console.WriteLine("Trenutno ne postoji ni jedan smjer.");
        }

        private void UrediSmjer()
        {
            if (Smjerovi.Count > 0)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Uređivanje smjera");
                Console.WriteLine("-----------------");

                PrikaziSveSmjerove();

                Console.WriteLine("");
                var s = Smjerovi[Pomocno.UcitajInt("Odaberi smjer za promjenu: ") - 1];

                s.Sifra = Pomocno.UcitajInt(s.Sifra + "Unesi promjenjenu šifru: ");
                s.Naziv = Pomocno.UcitajString(s.Naziv + "Unesi promjenjeni naziv: ");
            }

            Console.WriteLine("Trenutno ne postoji ni jedan smjer.");
        }

        private void PrikaziSveSmjerove()
        {
            Console.WriteLine("--------");
            Console.WriteLine("Smjerovi");
            Console.WriteLine("--------");

            var i = 0;;
            Smjerovi.ForEach(s =>
            {
                Console.WriteLine(++i + ". " + s);
            });
        }

        private void DodajNoviSmjer()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Dodavanje smjera");
            Console.WriteLine("----------------");

            Smjerovi.Add(new Smjer
            {
                Sifra = Pomocno.UcitajInt("Unesi šifru smjera: "),
                Naziv = Pomocno.UcitajString("Unesi naziv smjera: "),
                // Učitati ostale vrijednosti
            });

        }
    }
}
