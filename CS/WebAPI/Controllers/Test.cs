using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class Test : Controller
    {
        [HttpGet]
        [Route("Hello")]
        public string Hello(string PrviBroj, string DrugiBroj)
        {
            return Console.ReadLine PrviBroj + DrugiBroj;
        }
    }
}