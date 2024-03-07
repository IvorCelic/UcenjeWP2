using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PolaznikController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public PolaznikController(EdunovaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{sifra.int}")]
        public IActionResult GetBySifra(int sifra)
        {
            // Kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var polaznik = _context.Polaznici.Find(sifra);

                if (polaznik == null)
                {
                    return new EmptyResult();
                }

                return new JsonResult(polaznik);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Kontrola ukoliko upit nije valjan
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var polaznici = _context.Polaznici.ToList();

                if (polaznici == null || polaznici.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(polaznici);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Polaznik polaznik)
        {
            if (!ModelState.IsValid || polaznik == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Polaznici.Add(polaznik);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, polaznik);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Polaznik polaznik)
        {
            if (sifra <= 0 || !ModelState.IsValid || polaznik == null)
            {
                return BadRequest();
            }

            try
            {
                var polaznikIzBaze = _context.Polaznici.Find(sifra);

                if (polaznikIzBaze == null)
                {
                    return BadRequest();
                }

                // inače ovo rade mapperi
                // za sada ručno
                polaznikIzBaze.Ime = polaznik.Ime;
                polaznikIzBaze.Prezime = polaznik.Prezime;
                polaznikIzBaze.Oib = polaznik.Oib;
                polaznikIzBaze.Email = polaznik.Email;
                polaznikIzBaze.BrojUgovora = polaznik.BrojUgovora;

                _context.Polaznici.Update(polaznikIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, polaznikIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra, Polaznik polaznik)
        {
            if (sifra <= 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var polaznikIzBaze = _context.Polaznici.Find(sifra);

                if (polaznikIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Polaznici.Remove(polaznikIzBaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" }); // Ovo nije baš najbolja praksa ali evo i to se može
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.ErrorCode);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

    }
}
