using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V01")]
    public class V01 : ControllerBase
    {

        [HttpGet]
        [Route("vjezba1")]
        public int Vj1(int x, string i, int z)
        {
            return x + int.Parse(i) + z;   
        }
    }
}
