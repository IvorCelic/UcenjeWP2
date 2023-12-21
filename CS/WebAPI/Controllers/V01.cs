using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V01")]
    public class V01 : ControllerBase
    {

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
                    return x / z;
            }

            return 0;
        }
    }
}
