using System.Xml.Serialization;
using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class ObradaGrupa
    {
        public List<Grupa> Grupe { get; }

        private Izbornik Izbornik;
        public ObradaGrupa(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
        }
        public ObradaGrupa()
        {
            Grupe = new List<Grupa>();

        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Izbornik rada sa predavačima");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Prikaži sve grupe");
            Console.WriteLine("2. Dodaj grupu");
            Console.WriteLine("3. Uredi grupu");
            Console.WriteLine("4. Obriši grupu");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("");

            switch (Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, 5))
            {
                case 1:
                    PrikaziSveGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajNovuGrupu();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediGrupu();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiGrupu();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Povratak na glavni izbornik");
                    break;
            }
        }

        private void ObrisiGrupu()
        {
            if (Grupe.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------");
                Console.WriteLine("Brisanje grupe");
                Console.WriteLine("--------------");

                PrikaziSveGrupe();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Odaberi grupu za brisanje: ", "Odaberi iz ponuđenog!", 1, Grupe.Count);
                Grupe.RemoveAt(index - 1);

                Console.WriteLine("");
                Console.WriteLine("Grupa uspješno obrisana!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Trenutno ne postoji ni jedna grupa.");
            }
        }

        private void UrediGrupu()
        {
            if (Grupe.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("----------------");
                Console.WriteLine("Uređivanje grupe");
                Console.WriteLine("----------------");

                PrikaziSveGrupe();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Odaberi grupu za promjenu: ", "Odaberi iz ponuđenog!", 1, Grupe.Count);
                var grupa = Grupe[index - 1];

                grupa.Sifra = Pomocno.ValidirajSifru("Trenutna šifra: " + grupa.Sifra + " | Unesi novu šifru: ", Grupe, p => p.Sifra, grupa.Sifra, "Unos mora biti cijeli pozitivni broj!");
                grupa.Naziv = Pomocno.UcitajString("Trenutni naziv: " + grupa.Naziv + " | Unesi novi naziv: ", "Unos obavezan!");

                Console.WriteLine("Trenutni smjer: " + grupa.Smjer);
                grupa.Smjer = PostaviSmjer();

                Console.WriteLine("Trenutni predavač: " + grupa.Predavac);
                grupa.Predavac = PostaviPredavaca();

                Console.WriteLine("");
                Console.WriteLine("Grupa uspješno promjenjena!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Trenutno ne postoji ni jedna grupa.");
            }

        }

        private void DodajNovuGrupu()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("Dodavanje grupe");
            Console.WriteLine("---------------");

            var grupa = new Grupa();

            grupa.Sifra = Pomocno.ValidirajSifru("Unesi šifru grupe: ", Grupe, g => g.Sifra, grupa.Sifra, "Unos mora biti cijeli pozitivni broj!");
            grupa.Naziv = Pomocno.UcitajString("Unesi naziv grupe: ", "Unos obavezan!");

            if (Izbornik.ObradaSmjer.Smjerovi.Count <= 0)
            {
                Console.WriteLine("Trenutno ne postoji ni jedan smjer! Molimo dodajte novi: ");
                Izbornik.ObradaSmjer.DodajNoviSmjer();
            }
            grupa.Smjer = PostaviSmjer();

            if (Izbornik.ObradaPredavac.Predavaci.Count <= 0)
            {
                Console.WriteLine("Trenutno ne postoji ni jedan predavač! Molimo dodajte novog: ");
                Izbornik.ObradaPredavac.DodajNovogPredavaca();
            }
            grupa.Predavac = PostaviPredavaca();

            Console.WriteLine("");
            Console.WriteLine("Grupa uspješno dodana.");

            Grupe.Add(grupa);
        }

        private void PrikaziSveGrupe()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Grupe");
            Console.WriteLine("-----");

            var redniBroj = 0;
            Grupe.ForEach(grupa =>
            {
                Console.WriteLine(++redniBroj + ". " + grupa);
            });

            Console.WriteLine("");
        }

        private Predavac PostaviPredavaca()
        {
            Izbornik.ObradaPredavac.PrikaziSvePredavace();
            int index = Pomocno.UcitajBrojRaspon("Odaberi predavača za grupu: ", "Odaberi iz ponuđenog!", 1, Izbornik.ObradaPredavac.Predavaci.Count());
            return Izbornik.ObradaPredavac.Predavaci[index - 1];
        }

        private Smjer PostaviSmjer()
        {
            Izbornik.ObradaSmjer.PrikaziSveSmjerove();
            int index = Pomocno.UcitajBrojRaspon("Odaberi pripadajući smjer grupe: ", "Odaberi iz ponuđenog!", 1, Izbornik.ObradaSmjer.Smjerovi.Count());
            return Izbornik.ObradaSmjer.Smjerovi[index - 1];
        }

    }
}
