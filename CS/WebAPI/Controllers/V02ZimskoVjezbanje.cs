using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection.Metadata;

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



        // Ruta ne prima niti jedan parametar i vraća niz sa svim parnim brojevima od 1 do 57
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
            int manji = broj1 < broj2 ? broj1 : broj2;
            int veci = broj1 > broj2 ? broj1 : broj2;

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
            int veci = broj1 > broj2 ? broj1 : broj2;
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



        // Ruta prima dva parametra koji su cijeli brojevi i vraća dvodimenzionalni niz (matricu) koji sadrži tablicu množenja za dva primljena broja
        [HttpGet]
        [Route("ZimskiZad10")]
        public string Zad10(int broj1, int broj2)
        {
            string[,] tablicaMnozenja = new string[broj1, broj2];

            for (int i = 0; i < broj1; i++)
            {
                for (int j = 0; j < broj2; j++)
                {
                    tablicaMnozenja[i, j] = ((i + 1) * (j + 1)).ToString();
                }
            }

            StringBuilder matricaNiz = new StringBuilder(); // StringBuilder -> pruža promjenjivi niz znakova

            for (int i = 0; i < broj1; i++)
            {
                for (int j = 0; j < broj2; j++)
                {
                    matricaNiz.Append(tablicaMnozenja[i, j] + "\t");
                }
                matricaNiz.AppendLine(); // Prelazi na sljedeći redak za novi red(broj1)
            }

            return matricaNiz.ToString();
        }



        // Ruta prima jedan parametar koji je cijeli broj i vraća niz cijelih brojeva koji su složeni od primljenog broja do broja 1
        [HttpGet]
        [Route("ZimskiZad11")]
        public string Zad11(int broj)
        {
            int niz = 0;

            if (broj < 1)
            {
                for (int i = broj; i <= 1; i++)
                {
                    niz++;
                }
            }
            else
            {
                for (int i = broj; i >= 1; i--)
                {
                    niz++;
                }

            }

            int[] nizBrojeva = new int[niz];
            int index = 0;

            if (broj < 1)
            {
                for (int i = broj; i <= 1; i++)
                {
                    nizBrojeva[index++] = i;
                }
            }
            else
            {
                for (int i = broj; i >= 1; i--)
                {
                    nizBrojeva[index++] = i;
                }
            }

            return string.Join(", ", nizBrojeva);
        }



        // Ruta prima cijeli broj i vraća logičku istinu ako je primljeni broj prosti (prim - prime) broj, odnosno logičku laž ako nije
        [HttpGet]
        [Route("Zimskizad12")]
        public bool Zad12(int broj)
        {
            if (broj < 2)
            {
                return false;
            }

            if (broj % 2 == 0)
            {
                return false;
            }

            return true;
        }



        // Ruta prima dva parametra koji su cijeli brojevi te vraća dvodimenzionalni niz (matricu) cijelih brojeva koji su složeni prema slici zadatka:
        // Ciklična matrica
        [HttpGet]
        [Route("ZimskiZad13")]
        public string Zad13(int broj1, int broj2)
        {
            StringBuilder ciklicnaMatrica = new StringBuilder();
            string[,] dvodimenzionalniNiz = new string[broj1, broj2];
            int pocetak = broj1 * broj2;

            for (int i = 0; i < broj1; i++)
            {
                for (int j = 0; j < broj2; j++)
                {
                    dvodimenzionalniNiz[i, j] = pocetak--.ToString();
                }
            }

            for (int i = 0; i < broj1; i++)
            {
                for (int j = 0; j < broj2; j++)
                {
                    ciklicnaMatrica.Append(dvodimenzionalniNiz[i, j] + "\t");
                }

                ciklicnaMatrica.AppendLine();
            }

            return ciklicnaMatrica.ToString();
        }




        [HttpGet]
        [Route("ZimskiZad14")]
        public string Zad14(int broj1, int broj2)
        {
            StringBuilder matricaNiz = new StringBuilder();
            string[,] dvodimenzionalniNiz = new string[broj1, broj2];
            int value = 1;
            int rowStart = 0;
            int rowEnd = broj1 - 1;
            int colStart = 0;
            int colEnd = broj2 - 1;
            while (rowStart <= rowEnd && colStart <= colEnd)
            {
                for (int i = colStart; i <= colEnd; i++)
                {
                    dvodimenzionalniNiz[rowStart, i] = value++.ToString();
                }
                rowStart++;
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    dvodimenzionalniNiz[i, colEnd] = value++.ToString();
                }
                colEnd--;

                if (rowStart <= rowEnd)
                {
                    for (int i = colEnd; i >= colStart; i--)
                    {
                        dvodimenzionalniNiz[rowEnd, i] = value++.ToString();
                    }
                    rowEnd--;
                }

                if (colStart <= colEnd)
                {
                    for (int i = rowEnd; i >= rowStart; i--)
                    {
                        dvodimenzionalniNiz[i, colStart] = value++.ToString();
                    }
                    colStart++;
                }
            }

            for (int i = 0; i < broj1; i++)
            {
                for (int j = 0; j < broj2; j++)
                {
                    matricaNiz.Append(dvodimenzionalniNiz[i, j] + "\t");
                }

                matricaNiz.AppendLine();
            }

            return matricaNiz.ToString();
        }




    }
}
