using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class ObradaPolaznik
    {
        public List<Polaznik> Polaznici { get; }
        public ObradaPolaznik()
        {
            Polaznici = new List<Polaznik>();
            if (Pomocno.dev)
            {
                UcitajPodatke();
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Izbornik rada sa polaznicima");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Prikaži sve polaznike");
            Console.WriteLine("2. Dodaj polaznika");
            Console.WriteLine("3. Uredi polaznika");
            Console.WriteLine("4. Obriši polaznika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("");

            switch (Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, 5))
            {
                case 1:
                    PrikaziSvePolaznike();
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajNovogPolaznika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediPolaznika();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Povratak na glavni izbornik");
                    break;
            }
        }

        private void ObrisiPolaznika()
        {
            if (Polaznici.Count > 0)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Brisanje polaznika");
                Console.WriteLine("------------------");

                PrikaziSvePolaznike();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Udaberi polaznika za brisanje: ", "Odaberi iz ponuđenog!", 1, Polaznici.Count());
                Polaznici.RemoveAt(index - 1);

                Console.WriteLine("");
                Console.WriteLine("Polaznik uspješno obrisan!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Trenutno ne postoji ni jedan polaznik.");
            }

        }

        private void UrediPolaznika()
        {
            if (Polaznici.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("Uređivanje polaznika");
                Console.WriteLine("--------------------");

                PrikaziSvePolaznike();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Odaberi polaznika za promjenu: ", "Odaberi iz ponuđenog!", 1, Polaznici.Count);
                var polaznik = Polaznici[index - 1];

                polaznik.Sifra = Pomocno.ValidirajSifru("Trenutna šifra: " + polaznik.Sifra + " | Unesi novu šifru: ", Polaznici, p => p.Sifra, polaznik.Sifra, "Unos mora biti cijeli pozitivni broj!");
                polaznik.Ime = Pomocno.UcitajString("Trenutno ime: " + polaznik.Ime + " | Unesi novo ime: ", "Unos obavezan!");
                polaznik.Prezime = Pomocno.UcitajString("Trenutno prezime: " + polaznik.Prezime + " | Unesi novo prezime: ", "Unos obavezan!");
                polaznik.Oib = Pomocno.UcitajString("Trenutni oib: " + polaznik.Oib + " | Unesi novi oib: ", "Unos obavezan!");
                polaznik.Email = Pomocno.UcitajString("Trenutni email: " + polaznik.Email + " | Unesi novi email: ", "Unos obavezan!");
                polaznik.BrojUgovora = Pomocno.UcitajString("Trenutni broj ugovora: " + polaznik.BrojUgovora + " | Unesi novi broj ugovora: ", "Unos obavezan!");

                Console.WriteLine("");
                Console.WriteLine("Polaznik uspješno promjenjen!");
            }

            Console.WriteLine("");
            Console.WriteLine("Trenutno ne postoji ni jedan polaznik.");
        }

        public void PrikaziSvePolaznike()
        {
            Console.WriteLine("");
            Console.WriteLine("---------");
            Console.WriteLine("Polaznici");
            Console.WriteLine("---------");

            var redniBroj = 0; ;
            Polaznici.ForEach(polaznik =>
            {
                Console.WriteLine(++redniBroj + ". " + polaznik);
            });

            Console.WriteLine("");
        }

        public void DodajNovogPolaznika()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("Dodavanje polaznika");
            Console.WriteLine("-------------------");

            var polaznik = new Polaznik();

            polaznik.Sifra = Pomocno.ValidirajSifru("Unesi šifru polaznika: ", Polaznici, p => p.Sifra, polaznik.Sifra, "Unos mora biti cijeli pozitivni broj!");
            polaznik.Ime = Pomocno.UcitajString("Unesi ime polaznika: ", "Unos obavezan!");
            polaznik.Prezime = Pomocno.UcitajString("Unesi prezime polaznika: ", "Unos obavezan!");
            polaznik.Oib = Pomocno.UcitajString("Unesi oib polaznika: ", "Unos obavezan!");
            polaznik.Email = Pomocno.UcitajString("Unesi email polaznika: ", "Unos obavezan!");
            polaznik.BrojUgovora = Pomocno.UcitajString("Unesi broj ugovora polaznika: ", "Unos obavezan!");

            Console.WriteLine("");
            Console.WriteLine("Polaznik uspješno dodan!");

            Polaznici.Add(polaznik);
        }

        private void UcitajPodatke()
        {
            Polaznici.Add(new Polaznik()
            {
                Sifra = 1,
                Ime = "Ivor",
                Prezime = "Ćelić",
                Email = "ivorcelic@gmail.com",
                Oib = "11111111111"
            });

            Polaznici.Add(new Polaznik()
            {
                Sifra = 2,
                Ime = "Antonio",
                Prezime = "Antunović",
                Email = "antisa@gmail.com",
                Oib = "22222222222"
            });

            Polaznici.Add(new Polaznik()
            {
                Sifra = 3,
                Ime = "Ivan",
                Prezime = "Ivanić",
                Email = "ivanecgmail.com",
                Oib = "33333333333"
            });

            Polaznici.Add(new Polaznik()
            {
                Sifra = 4,
                Ime = "Ana",
                Prezime = "Anić",
                Email = "anica@gmail.com",
                Oib = "44444444444"
            });
        }
    }
}
