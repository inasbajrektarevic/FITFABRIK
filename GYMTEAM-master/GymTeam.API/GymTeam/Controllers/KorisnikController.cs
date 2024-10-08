﻿
using GymTeam.Data;
using GymTeam.Helper;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace GymTeam.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class KorisnikController : Controller
    {
        public readonly ApplicationDbContext _dbcontext;
        public KorisnikController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public Korisnik Add([FromBody] KorisnikAddVM x)
        {

            var korisnik = new Korisnik
            {
                ime = x.ime,
                prezime = x.prezime,
                email = x.email,
                lozinka = x.lozinka,
                datumRodjenja = x.datumRodjenja,
                brojTelefona = x.brojTelefona,
                roleId = x.roleID,

            };
            if (x.slika != null)
            {
                byte[] imageByte = x.slika.GetImage();
                korisnik.slika = imageByte;
            }

            if (korisnik.roleId != 2)
            {
                korisnik.lokacijaId = null;
            }

            _dbcontext.Add(korisnik);
            _dbcontext.SaveChanges();
            return korisnik;
        }

        [HttpGet]
        public ActionResult<object> GetAll(string? ime_prezime, int page = 1, int pageSize = 5)
        {
            // Filtriranje podataka na osnovu imena i prezimena
            var data = _dbcontext.Korisnik.Where(korisnik =>
                 string.IsNullOrEmpty(ime_prezime) ||
                 (korisnik.ime + " " + korisnik.prezime).ToLower().StartsWith(ime_prezime.ToLower()) ||
                 (korisnik.prezime + " " + korisnik.ime).ToLower().StartsWith(ime_prezime.ToLower())
             )
             .OrderByDescending(k => k.id)
             .AsQueryable();

            int totalCount = data.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Osiguranje da je page najmanje 1
            if (page < 1)
                page = 1;

            // Osiguranje da page nije veći od totalPages (ako totalPages nije nula)
            if (totalPages > 0 && page > totalPages)
                page = totalPages;

            data = data.Skip((page - 1) * pageSize).Take(pageSize);

            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Data = data.ToList()
            };

            return result;
        }
        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            var korisnik = _dbcontext.Korisnik.Find(id);
            if (korisnik == null)
            {
                throw new Exception("Korisnik with the specified ID does not exist");
            }

            return Ok(korisnik);
        }
        [HttpGet("GetSlikaById")]
        public ActionResult GetSlikaById(int id)
        {
            byte[]? slika = _dbcontext.Korisnik.Find(id)?.slika;

            if (slika == null)
                return BadRequest();

            return File(slika, "image/*");
        }
        [HttpPut("ChangePhoto")]
        public ActionResult<Korisnik> editPhoto([FromForm] IFormFile file, int id)
        {
            var korisnik = _dbcontext.Korisnik.Find(id);
            if (korisnik == null)
            {
                throw new Exception("Korisnik with the specified ID does not exist");
            }

            if (file == null)
            {
                throw new Exception("Invalid file");
            }

            korisnik.slika = file.GetImage();
            _dbcontext.Korisnik.Update(korisnik);
            _dbcontext.SaveChanges();

            return Ok(korisnik);
        }

        [HttpPut]
        public Korisnik Edit(int id, KorisnikUVM korisnik)
        {
            var thisKorisnik = _dbcontext.Korisnik.Find(id);
            if (thisKorisnik == null)
            {
                throw new Exception("Korisnik with the specified ID does not exist");
            }

            thisKorisnik.ime = korisnik.ime;
            thisKorisnik.prezime = korisnik.prezime;
            thisKorisnik.email = korisnik.email;
            thisKorisnik.lozinka = korisnik.lozinka;
            thisKorisnik.datumRodjenja = korisnik.datumRodjenja;
            thisKorisnik.brojTelefona = korisnik.brojTelefona;

            _dbcontext.Korisnik.Update(thisKorisnik);
            _dbcontext.SaveChanges();

            return thisKorisnik;
        }

        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            var korisnik = _dbcontext.Korisnik.Find(id);
            if (korisnik == null)
            {
                throw new Exception("Korisnik with the specified ID does not exist");
            }

            _dbcontext.Korisnik.Remove(korisnik);
            _dbcontext.SaveChanges();

            return Ok(true);
        }


    }
}