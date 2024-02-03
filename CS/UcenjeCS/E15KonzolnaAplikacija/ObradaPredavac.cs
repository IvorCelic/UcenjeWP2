using UcenjeCS.E15KonzolnaAplikacija.Model;

namespace UcenjeCS.E15KonzolnaAplikacija
{
    internal class ObradaPredavac
    {
        public List<Predavac> Predavaci { get; }

        public ObradaPredavac()
        {
            Predavaci = new List<Predavac>();

            if (Pomocno.dev)
            {
                UcitajPodatke();
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Izbornik rada sa predavačima");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Prikaži sve predavače");
            Console.WriteLine("2. Dodaj predavača");
            Console.WriteLine("3. Uredi predavača");
            Console.WriteLine("4. Obriši predavača");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Console.WriteLine("");

            switch (Pomocno.UcitajBrojRaspon("Unesi izbor: ", "Odaberi iz ponuđenog!", 1, 5))
            {
                case 1:
                    PrikaziSvePredavace();
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajNovogPredavaca();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediPredavaca();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPredavaca();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Povratak na glavni izbornik");
                    break;
            }
        }

        private void ObrisiPredavaca()
        {
            if (Predavaci.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------");
                Console.WriteLine("Brisanje predavača");
                Console.WriteLine("-------------------");

                PrikaziSvePredavace();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Odaberi predavača za brisanje: ", "Odaberi iz ponuđenog!", 1, Predavaci.Count);
                Predavaci.RemoveAt(index - 1);

                Console.WriteLine("");
                Console.WriteLine("Predavač uspješno obrisan!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Trenutno ne postoji ni jedan predavač.");
            }
        }

        private void UrediPredavaca()
        {
            if (Predavaci.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("Uređivanje predavača");
                Console.WriteLine("--------------------");

                PrikaziSvePredavace();

                Console.WriteLine("");
                int index = Pomocno.UcitajBrojRaspon("Odaberi predavača za promjenu: ", "Odaberi iz ponuđenog!", 1, Predavaci.Count);
                var predavac = Predavaci[index - 1];

                predavac.Sifra = Pomocno.ValidirajSifru("Trenutna šifra: " + predavac.Sifra + " | Unesi novu šifru: ", Predavaci, p => p.Sifra, predavac.Sifra, "Unos mora biti cijeli pozitivni broj!");
                predavac.Ime = Pomocno.UcitajString("Trenutno ime: " + predavac.Ime + " | Unesi novo ime: ", "Unos obavezan!");
                predavac.Prezime = Pomocno.UcitajString("Trenutno prezime: " + predavac.Prezime + " | Unesi novo prezime: ", "Unos obavezan!");
                predavac.Oib = Pomocno.UcitajString("Trenutni oib: " + predavac.Oib + " | Unesi novi oib: ", "Unos obavezan!");
                predavac.Email = Pomocno.UcitajString("Trenutni email: " + predavac.Email + " | Unesi novi email: ", "Unos obavezan!");
                predavac.Iban = Pomocno.UcitajString("Trenutni iban: " + predavac.Iban + " | Unesi novi iban: ", "Unos obavezan!");

                Console.WriteLine("");
                Console.WriteLine("Predavač uspješno promjenjen!");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Trenutno ne postoji ni jedan predavač!");
            }
        }

        public void DodajNovogPredavaca()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("Dodavanje predavača");
            Console.WriteLine("-------------------");

            var predavac = new Predavac();

            predavac.Sifra = Pomocno.ValidirajSifru("Unesi šifru predavača: ", Predavaci, p => p.Sifra, predavac.Sifra, "Unos mora biti cijeli pozitivni broj!");
            predavac.Ime = Pomocno.UcitajString("Unesi ime predavača: ", "Unos obavezan!");
            predavac.Prezime = Pomocno.UcitajString("Unesi prezime predavača: ", "Unos obavezan!");
            predavac.Oib = Pomocno.UcitajString("Unesi oib predavača: ", "Unos obavezan!");
            predavac.Email = Pomocno.UcitajString("Unesi email predavača: ", "Unos obavezan!");
            predavac.Iban = Pomocno.UcitajString("Unesi iban predavača: ", "Unos obavezan!");

            Console.WriteLine("");
            Console.WriteLine("Predavač uspješno dodan!");

            Predavaci.Add(predavac);
        }

        public void PrikaziSvePredavace()
        {
            Console.WriteLine("---------");
            Console.WriteLine("Predavači");
            Console.WriteLine("---------");

            var redniBroj = 0;
            Predavaci.ForEach(predavac =>
            {
                Console.WriteLine(++redniBroj + ". " + predavac);
            });

            Console.WriteLine("");
        }

        private void UcitajPodatke()
        {
            Predavaci.Add(new Predavac
            {
                Sifra = 1,
                Ime = "Tomislav",
                Prezime = "Jakopec",
                Oib = "11111111111",
                Email = "tjakopec@gmail.com",
                Iban = "HR123456789101112131415"
            });

            Predavaci.Add(new Predavac
            {
                Sifra = 2,
                Ime = "Imenaš",
                Prezime = "Prezimaš",
                Oib = "22222222222",
                Email = "iprezimas@gmail.com",
                Iban = "HR514131211101987654321"
            });
        }


    }
}
