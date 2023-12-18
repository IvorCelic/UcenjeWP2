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
            return (float)i / j; // float koristimo da bi dijelili decimalni broj
        }
    }
}
