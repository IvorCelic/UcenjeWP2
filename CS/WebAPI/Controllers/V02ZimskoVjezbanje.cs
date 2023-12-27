using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V02")]
    public class V02ZimskoVjezbanje : ControllerBase
    {

        // Ruta ne prima niti jedan parametar i vraća zbroj prvih 100 brojeva
        [HttpGet]
        [Route("ZimskiZad01")]
        public int Zad01()
        {
            int suma = 0;

            for (int i = 0; i <= 100; i++)
            {
                suma += i;
            }

            return suma;

        }



        // Ruta ne prima niti jedan parametar i vraća niz s svim parnim brojevima od 1 do 57
        [HttpGet]
        [Route("ZimskiZad02")]
        public int[] Zad02()
        {
            int[] parniBrojevi = new int[57 / 2];
            int broj = 0;

            for (int i = 2; i < 57; i += 2)
            {
                    parniBrojevi[broj++] = i;
            }

            return parniBrojevi;

        }



        // Ruta ne prima niti jedan parametar i vraća zbroj svih parnih brojeva od 2 do 18
        [HttpGet]
        [Route("ZimskiZad03")]
        public int Zad03()
        {
            int suma = 0;

            for (int i = 2; i <= 18; i += 2)
            {
                suma += i;
            }

            return suma;

        }



        // Ruta prima jedan parametar koji je cijeli broj i vraća zbroj svih brojeva od 1 do primljenog broja
        [HttpGet]
        [Route("ZimskiZad04")]
        public int Zad04(int broj)
        {
            int suma = 0;

            for (int i = 1; i <= broj; i++)
            {
                suma += i;
            }

            return suma;

        }



        // Ruta prima dva parametra koji su cijeli brojevi i vraća niz sa svim parnim brojevima između primljenih brojeva
        [HttpGet]
        [Route("ZimskiZad05")]
        public string Zad05(int broj1, int broj2)
        {
            if (broj1 % 2 == 0)
            {
                broj1++;
            }

            if (broj1 >= broj2)
            {
                return "Broj1 mora biti manji od Broj2.";
            }

            int brojanje = 0;

            for (int i = broj1; i < broj2; i++)
            {
                if (i % 2 == 0)
                {
                    brojanje++;
                }
            }

            int[] parniBrojevi = new int[brojanje];
            int index = 0;

            for (int i = broj1; i < broj2; i++)
            {
                if (i % 2 == 0)
                {
                    parniBrojevi[index++] = i;
                }
            }

            return string.Join(", ", parniBrojevi);
        }



        // Ruta prima dva parametra koji su cijeli brojevi i vraća niz sa svim neparnim brojevima između primljenih brojeva
        [HttpGet]
        [Route("ZimskiZad06")]

        public string Zad06(int broj1, int broj2)
        {
            if (broj1 % 2 != 0)
            {
                broj1++;
            }

            if (broj1 >= broj2)
            {
                return "Broj1 mora biti manji od Broj2!";
            }

            int brojanje = 0;

            for (int i = broj1; i < broj2; i++)
            {
                if (i % 2 != 0)
                {
                    brojanje++;
                }
            }

            int[] neparniBrojevi = new int[brojanje];
            int index = 0;

            for (int i = broj1; i < broj2; i++)
            {
                if (i % 2 != 0)
                {
                    neparniBrojevi[index++] = i;
                }
            }

            return string.Join(", ", neparniBrojevi);
        }



        // Ruta prima dva parametra koji su cijeli brojevi i vraća zbroj svih brojeva između primljenih brojeva
        [HttpGet]
        [Route("ZimskiZad07")]
        public int Zad07(int broj1, int broj2)
        {
            int manji = broj1 < broj2 ? broj1 : broj2;
            int veci = broj1 > broj2 ? broj1: broj2;
            int suma = 0;

            for (int i = manji; i <= veci; i++)
            {
                suma += i;
            }

            return suma; 
        }



        // Ruta prima dva parametra koji su cijeli brojevi i vraća zbroj svih brojeva između primljenih brojeva koji su cjelobrojno djeljivi s 3
        [HttpGet]
        [Route("ZimskiZad08")]
        public int Zad08(int broj1, int broj2)
        {
            int manji = broj1 < broj2 ? broj1 : broj2;
            int veci = broj1 > broj2 ? broj1 : broj2;
            int suma = 0;

            for (int i = manji; i <= veci; i++)
            {
                if (i % 3 == 0)
                {
                    suma += i;
                }
            }

            return suma;
        }



        // Ruta prima dva parametra koji su cijeli brojevi i vraća zbroj svih brojeva između primljenih brojeva koji su cjelobrojno djeljivi s 3 i 5
        [HttpGet]
        [Route("ZimskiZad09")]
        public int Zad09(int broj1, int broj2)
        {
            int manji = broj1 < broj2 ? broj1 : broj2;
            int veci = broj1 > broj2 ? broj1 : broj2;
            int suma = 0;

            for (int i = manji; i <= veci; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    suma += i;
                }
            }

            return suma;
        }



        // Ruta prima dva parametra koji su cijeli brojevi i vraća dvodimenzionalni niz (matricu) koja sadrži tablicu množenja za dva primljena broja
        [HttpGet]
        [Route("ZimskiZad10")]
        public int Zad10(int broj1, int broj2)
        {
            for (int i = 1; i < broj1; i++)
            {
                for (int j = 1; j < broj2; j++)
                {
                }
            }

            return 0;
        }



    }
}
