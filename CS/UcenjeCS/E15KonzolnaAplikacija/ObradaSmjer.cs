using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class ObradaSmjer
    {
        public List<Smjer> Smjerovi { get; }

        public ObradaSmjer()
        {
            Smjerovi = new List<Smjer>();

            if (Pomocno.dev)
            {
                UcitajPodatke();
            }
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

            switch (Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, 5))
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

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, Smjerovi.Count());
                Smjerovi.RemoveAt(index - 1);

                Console.WriteLine("");
                Console.WriteLine("Smjer uspješno obrisan!");
            }

            Console.WriteLine("");
            Console.WriteLine("Trenutno ne postoji ni jedan smjer.");
        }

        private void UrediSmjer()
        {
            if (Smjerovi.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("-----------------");
                Console.WriteLine("Uređivanje smjera");
                Console.WriteLine("-----------------");

                PrikaziSveSmjerove();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Odaberi smjer za promjenu: ", "Odaberi iz ponuđenog!", 1, Smjerovi.Count);
                var smjer = Smjerovi[index - 1];

                smjer.Sifra = Pomocno.ValidirajSifru("Trenutna šifra: " + smjer.Sifra + " | Unesi novu šifru: ", Smjerovi, s => s.Sifra, smjer.Sifra, "Unos mora biti cijeli pozitivni broj!");
                smjer.Naziv = Pomocno.UcitajString("Trenutni naziv: " + smjer.Naziv + " | Unesi novi naziv: ", "Unos obavezan!");
                smjer.Trajanje = Pomocno.UcitajInt("Trenutno trajanje smjera: " + smjer.Trajanje + " | Unesi novi broj sati: ", "Unos mora biti cijeli pozitivni broj!");
                smjer.Cijena = Pomocno.UcitajDecimalniBroj("Trenutna cijena: " + smjer.Cijena + " | Unesite novu cijenu smjera: ", "Unos mora biti pozitivan broj!");
                smjer.Upisnina = Pomocno.UcitajDecimalniBroj("Trenutna upisnina: " + smjer.Upisnina + " | Unesite novu upisninu smjera: ", "Unos mora biti pozitivan broj!");

                Console.WriteLine("");
                Console.WriteLine("Smjer uspješno promjenjen!");
            }

            Console.WriteLine("");
            Console.WriteLine("Trenutno ne postoji ni jedan smjer.");
        }

        private void PrikaziSveSmjerove()
        {
            Console.WriteLine("");
            Console.WriteLine("--------");
            Console.WriteLine("Smjerovi");
            Console.WriteLine("--------");

            var redniBroj = 0;;
            Smjerovi.ForEach(smjer =>
            {
                Console.WriteLine(++redniBroj + ". " + smjer);
            });

            Console.WriteLine("");
        }

        private void DodajNoviSmjer()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------");
            Console.WriteLine("Dodavanje smjera");
            Console.WriteLine("----------------");

            var smjer = new Smjer();

            smjer.Sifra = Pomocno.ValidirajSifru("Unesi šifru smjera: ", Smjerovi, s => s.Sifra, smjer.Sifra, "Unos mora biti cijeli pozitivni broj!");
            smjer.Naziv = Pomocno.UcitajString("Unesi naziv smjera: ", "Unos obavezan!");
            smjer.Trajanje = Pomocno.UcitajInt("Unesite broj sati smjera: ", "Unos mora biti cijeli pozitivni broj!");
            smjer.Cijena = Pomocno.UcitajDecimalniBroj("Unesite cijenu smjera: ", "Unos mora biti pozitivan broj!");
            smjer.Upisnina = Pomocno.UcitajDecimalniBroj("Unesite upisninu smjera: ", "Unos mora biti pozitivan broj!");
            smjer.Verificiran = Pomocno.UcitajBool("Ako je smjer verificiran unesite \"da\", ako nije, unesite bilo šta: ");

            Console.WriteLine("");
            Console.WriteLine("Smjer uspješno dodan!");

            Smjerovi.Add(smjer);
        }

        private void UcitajPodatke()
        {
            Smjerovi.Add(new Smjer
            {
                Sifra = 1,
                Naziv = "Java programiranje",
                Trajanje = 130,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });

            Smjerovi.Add(new Smjer
            {
                Sifra = 2,
                Naziv = "Web programiranje",
                Trajanje = 250,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });
        }


    }
}
