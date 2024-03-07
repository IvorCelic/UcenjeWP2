using EdunovaAPP.Data;
using EdunovaAPP.Extensions;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Namjenjeno za CRUD operacije nad entitetom smjer u bazi
    /// </summary>
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmjerController : ControllerBase
    {
        /// <summary>
        /// Kontext za rad s bazom koji će biti postavljen s pomoću Dependecy Injection-om
        /// </summary>
        private readonly EdunovaContext _context;

        /// <summary>
        /// Konstruktor klase koja prima Edunova kontext pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public SmjerController(EdunovaContext context)
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
                var smjer = _context.Smjerovi.Find(sifra);

                if (smjer == null)
                {
                    return new EmptyResult();
                }

                return new JsonResult(smjer.MapSmjerReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Dohvaća sve smjerove iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita
        ///     GET api/v1/Smjer
        /// </remarks>
        /// <returns>Smjerovi u bazi</returns>
        /// <response code="200">Sve OK, ako nema podataka content-length: 0</response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju spajam nije dostupna</response>
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

                var smjerovi = _context.Smjerovi.ToList();

                if (smjerovi == null || smjerovi.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(smjerovi.MapSmjerReadList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }


        /// <summary>
        /// Dodaje novi smjer u bazu
        /// </summary>
        /// <remarks>
        ///     POST api/v1/Smjer
        ///     {naziv: "Primjer naziva"}
        /// </remarks>
        /// <param name="smjer">Smjer za unijeti u JSON formatu</param>
        /// <response code="201">Kreirano</response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza nedostupna iz razno raznih razloga</response>
        /// <returns>Smjer s šifrom koju je dala baza</returns>
        [HttpPost]
        public IActionResult Post(SmjerDTOInsertUpdate smjerDTO)
        {
            if (!ModelState.IsValid || smjerDTO == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var smjer = smjerDTO.MapSmjerInsertUpdateFromDTO();
                _context.Smjerovi.Add(smjer);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, smjer.MapSmjerReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Mijenja podatke postojećeg smjera u bazi
        /// </summary>
        /// <param name="sifra"></param>
        /// <param name="smjer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, SmjerDTOInsertUpdate smjerDTO)
        {
            if (sifra <= 0 || !ModelState.IsValid || smjerDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var smjerIzBaze = smjerDTO.MapSmjerInsertUpdateFromDTO();

                if (smjerIzBaze == null)
                {
                    return BadRequest();
                }

                var smjer = smjerDTO.MapSmjerInsertUpdateFromDTO();
                smjer.Sifra = sifra;

                _context.Smjerovi.Update(smjer);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, smjer.MapSmjerReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra, Smjer smjer)
        {
            if (sifra <= 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var smjerIzBaze = _context.Smjerovi.Find(sifra);

                if (smjerIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Smjerovi.Remove(smjerIzBaze);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\": \"Obrisano\"}"); // Ovo nije baš najbolja praksa ali evo i to se može
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
