using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E02")]
    public class E02VarijableTipoviPodatakaOperatori : ControllerBase
    {

        [HttpGet]
        [Route("zad1")]
        public int Zad1()
        {
            // vratite najmanji broj
            return int.MinValue;
        }


        [HttpGet]
        [Route("zad2")]
        public float Zad2(int i, int j)
        {
            // Ruta vraća kvocijent dvaju primljenih brojeva
            return (float)i / j; // float koristimo da bi dijelili decimalni broj, ne moramo ga staviti ispred obje varijable
        }


        [HttpGet]
        [Route("zad3")]
        public float Zad3(int i, int j)
        {
            // Ruta vraća zbroj umnoška i kvocijenta primljenih brojeva

            var Umnozak = i * j;
            var Kvocijent = (float)i / j;
            return Umnozak + Kvocijent;
        }


        [HttpGet]
        [Route("zad4")]
        public string Zad4(string s, string s1)
        {
            // Ruta vraća spojene primljene znakove
            return s + s1;
        }


        [HttpGet]
        [Route("zad5")]
        public bool zad5(int a, int b)
        {
            Console.WriteLine("a={0}", a);
            // Ruta vraća True ako je a = b, inače vraća False
            return a == b;
        }
    }
}
