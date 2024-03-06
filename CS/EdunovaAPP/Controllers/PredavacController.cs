using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PredavacController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public PredavacController(EdunovaContext context)
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
                var predavac = _context.Predavaci.Find(sifra);

                if (predavac == null)
                {
                    return new EmptyResult();
                }

                return new JsonResult(predavac);
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
                var predavaci = _context.Predavaci.ToList();

                if (predavaci == null || predavaci.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(predavaci);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Smjer predavac)
        {
            if (!ModelState.IsValid || predavac == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Smjerovi.Add(predavac);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, predavac);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Predavac predavac)
        {
            if (sifra <= 0 || !ModelState.IsValid || predavac == null)
            {
                return BadRequest();
            }

            try
            {
                var predavacIzBaze = _context.Predavaci.Find(sifra);

                if (predavacIzBaze == null)
                {
                    return BadRequest();
                }

                // inače ovo rade mapperi
                // za sada ručno
                predavacIzBaze.Ime = predavac.Ime;
                predavacIzBaze.Prezime = predavac.Prezime;
                predavacIzBaze.Oib = predavac.Oib;
                predavacIzBaze.Email = predavac.Email;
                predavacIzBaze.Iban = predavac.Iban;

                _context.Predavaci.Update(predavacIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, predavacIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra, Predavac predavac)
        {
            if (sifra <= 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var predavacIzBaze = _context.Predavaci.Find(sifra);

                if (predavacIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Predavaci.Remove(predavacIzBaze);
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
