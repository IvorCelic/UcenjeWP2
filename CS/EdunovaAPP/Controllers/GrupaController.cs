using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class GrupaController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public GrupaController(EdunovaContext context)
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
                var grupa = _context.Grupe.Find(sifra);

                if (grupa == null)
                {
                    return new EmptyResult();
                }

                return new JsonResult(grupa);
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
                var grupe = _context.Grupe
                    .Include(g => g.Smjer)
                    .Include(g => g.Predavac)
                    .Include(g => g.Polaznici)
                    .ToList();

                if (grupe == null || grupe.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(grupe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Grupa grupa)
        {
            if (!ModelState.IsValid || grupa == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Grupe.Add(grupa);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, grupa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Grupa grupa)
        {
            if (sifra <= 0 || !ModelState.IsValid || grupa == null)
            {
                return BadRequest();
            }

            try
            {
                var grupaIzBaze = _context.Grupe.Find(sifra);

                if (grupaIzBaze == null)
                {
                    return BadRequest();
                }

                // inače ovo rade mapperi
                // za sada ručno
                grupaIzBaze.Naziv = grupa.Naziv;
                grupaIzBaze.Smjer = grupa.Smjer;
                grupaIzBaze.Predavac = grupa.Predavac;
                grupaIzBaze.DatumPocetka = grupa.DatumPocetka;
                grupaIzBaze.MaksimalnoPolaznika = grupa.MaksimalnoPolaznika;
                grupaIzBaze.Polaznici = grupa.Polaznici;

                _context.Grupe.Update(grupaIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, grupaIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra, Grupa grupa)
        {
            if (sifra <= 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var grupaIzBaze = _context.Grupe.Find(sifra);

                if (grupaIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Grupe.Remove(grupaIzBaze);
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
