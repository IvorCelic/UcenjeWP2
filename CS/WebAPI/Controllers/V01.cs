using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V01")]
    public class V01 : ControllerBase
    {

        // Ruta prima tri marametra: dva cijela broja i string.
        // String može biti "+, -, *, /". Ruta vraća rezultat
        [HttpGet]
        [Route("vjezba1")]
        public int Vj1(int x, string s, int z)
        {
            switch (s)
            {
                case "+":
                    return x + z;
                case "-":
                    return x - z;
                case "*":
                    return x * z;
                case "/":
                    if (x == 0)
                    {
                        return 0;
                    }
                    if (z == 0)
                    {
                        return 0;
                    }
                    return x / z;
            }

            return 0;
        }



        // Ruta prima niz decimalnih brojeva. Vraća zbroj cijelog dijela
        // prvog elementa niza i decimalnog dijela zadnjeg elementa niza
        [HttpPost]
        [Route("vjezba2")]
        public decimal Vj2(decimal[] Niz)
        {
            if (Niz.Length == 0)
            {
                return 0;
            }

            int PrviElement = (int)Niz[0];
            decimal ZadnjiElement = Niz[Niz.Length - 1] % 1;
            var Zbroj = PrviElement + ZadnjiElement;

            return Zbroj;
        }


    }
}
