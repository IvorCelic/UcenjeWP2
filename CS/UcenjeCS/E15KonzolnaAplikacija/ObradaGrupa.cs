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

                if (Pomocno.UcitajBool("Želite li promjeniti šifru grupe? (unesite \"da\" za promjenu i bilo što za ne): "))
                {
                    grupa.Sifra = Pomocno.ValidirajSifru("Trenutna šifra: " + grupa.Sifra + " | Unesi novu šifru: ", Grupe, p => p.Sifra, grupa.Sifra, "Unos mora biti cijeli pozitivni broj!");
                }

                if (Pomocno.UcitajBool("Želite li promjeniti naziv grupe? (unesite \"da\" za promjenu i bilo što za ne): "))
                {
                    grupa.Naziv = Pomocno.UcitajString("Trenutni naziv: " + grupa.Naziv + " | Unesi novi naziv: ", "Unos obavezan!");
                }

                if (Pomocno.UcitajBool("Želite li promjeniti smjer grupe? (unesite \"da\" za promjenu i bilo što za ne): "))
                {
                    Console.WriteLine("Trenutni smjer: " + grupa.Smjer);
                    grupa.Smjer = PostaviSmjer();
                }

                if (Pomocno.UcitajBool("Želite li promjeniti maksimalno polaznika u grupi? (unesite \"da\" za promjenu i bilo što za ne): "))
                {
                    grupa.MaksimalnoPolaznika = Pomocno.UcitajInt("Trenutni maksimalni broj polaznika: " + grupa.MaksimalnoPolaznika + " | Unesi novi maksimalni broj polaznika: ", "Unos mora biti cijeli pozitivni broj!");
                }

                if (Pomocno.UcitajBool("Želite li promjeniti predavača grupe? (unesite \"da\" za promjenu i bilo što za ne): "))
                {
                    Console.WriteLine("Trenutni predavač: " + grupa.Predavac);
                    grupa.Predavac = PostaviPredavaca();
                }


                if (grupa.Polaznici.Count() <= 0)
                {
                    Console.WriteLine("Trenutno nema polaznika u ovoj grupi.");
                    grupa.Polaznici.AddRange(DodajPolaznike(Grupe));
                }
                else
                {
                    grupa.Polaznici.AddRange(DodajPolaznike(Grupe));
                    grupa.Polaznici = ObrisiPolaznike(grupa);
                }

                Console.WriteLine("");

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

            grupa.MaksimalnoPolaznika = Pomocno.UcitajInt("Unesi maksimalni broj polaznika grupe: ", "Unos mora biti cijeli pozitivni broj!");

            if (Izbornik.ObradaPredavac.Predavaci.Count <= 0)
            {
                Console.WriteLine("Trenutno ne postoji ni jedan predavač! Molimo dodajte novog: ");
                Izbornik.ObradaPredavac.DodajNovogPredavaca();
            }
            grupa.Predavac = PostaviPredavaca();

            if (Izbornik.ObradaPolaznik.Polaznici.Count <= 0)
            {
                Console.WriteLine("Trenutno ne postoji ni jedan polaznik! Molimo dodajte novog: ");
                Izbornik.ObradaPolaznik.DodajNovogPolaznika();
            }
            grupa.Polaznici = DodajPolaznike(Grupe);

            grupa.DatumPocetka = Pomocno.UcitajDatum("Unesite datum početka grupe: (format dd.MM.yyyy.", "Molim ispravan format datuma!");

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

        private List<Polaznik> ObrisiPolaznike(Grupa trenutnaGrupa)
        {
            List<Polaznik> polaznici = new List<Polaznik>(trenutnaGrupa.Polaznici);

            while (Pomocno.UcitajBool("Želite li obrisati trenutne polaznike grupe? (unesite \"da\" za brisanje i bilo što za ne): "))
            {
                PrikaziPolaznike(polaznici);

                int odabraniPolaznikIndex = Pomocno.UcitajBrojRaspon("Odaberi polaznika kojeg želiš obrisati s grupe: ", "Odaberi iz ponuđenog!", 1, polaznici.Count()) - 1;

                if (odabraniPolaznikIndex >= 0 && odabraniPolaznikIndex < polaznici.Count)
                {
                    polaznici.RemoveAt(odabraniPolaznikIndex);

                    if (polaznici.Count == 0)
                    {
                        break;
                    }
                }
            }

            return polaznici;
        }

        //private int ObrisiPolaznika(Grupa trenutnaGrupa)
        //{
        //    PrikaziPolaznike(trenutnaGrupa.Polaznici);

        //    return Pomocno.UcitajBrojRaspon("Odaberi polaznika kojeg želiš obrisati s grupe: ", "Odaberi iz ponuđenog!", 1, trenutnaGrupa.Polaznici.Count());
        //}

        private List<Polaznik> DodajPolaznike(List<Grupa> grupe)
        {
            List<Polaznik> polaznici = new List<Polaznik>();
            while (Pomocno.UcitajBool("Želite li dodati polaznike na trenutnu grupu? (unesite \"da\" za brisanje i bilo što za ne): "))
            {
                polaznici.Add(DodajPolaznika(grupe));
            }

            return polaznici;
        }

        private Polaznik DodajPolaznika(List<Grupa> grupe)
        {
            int index;
            while (true)
            {
                Izbornik.ObradaPolaznik.PrikaziSvePolaznike();
                index = Pomocno.UcitajBrojRaspon("Odaberi polaznika kojeg želiš dodijeliti grupi: ", "Odaberi iz ponuđenog!", 1, Izbornik.ObradaPolaznik.Polaznici.Count());

                var odabraniPolaznik = Izbornik.ObradaPolaznik.Polaznici[index - 1];

                if (!ValidacijaPolaznikaUGrupi(odabraniPolaznik, grupe))
                {
                    return odabraniPolaznik;
                }
                else
                {
                    Console.WriteLine("Polaznik se već nalazi u grupi. Dodajte novog.");
                }
            }
        }

        private bool ValidacijaPolaznikaUGrupi(Polaznik polaznik, List<Grupa> grupe)
        {
            foreach (var grupa in grupe)
            {
                if (grupa.Polaznici.Any(p => p.Sifra == polaznik.Sifra))
                {
                    return true;
                }
            }

            return false;
        }

        private void PrikaziPolaznike(List<Polaznik> polaznici)
        {
            if (polaznici.Count > 0)
            {
                Console.WriteLine("---------");
                Console.WriteLine("Polaznici");
                Console.WriteLine("---------");
                int redniBroj = 0;
                polaznici.ForEach(polaznik =>
                {
                    Console.WriteLine(++redniBroj + ". " + polaznik);
                });
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Trenutno nema polaznika u ovoj grupi.");
            }

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
