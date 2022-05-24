using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using haris_edin_rs1.Data;
using haris_edin_rs1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace haris_edin_rs1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KomentarController : ControllerBase
    {


        private readonly ApplicationDbContext _dbContext;

        public KomentarController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Komentar.Include(k=>k.korisnik).Where(x => x.Artikal_id == id));


        }
    

            public class PitanjeAddVM
            {

                public string Pitanja { get; set; }
                public int artikalID { get; set; }
                public int korisnikID { get; set; }
                public DateTime DatumVrijeme { get; set; }



        }
        //add
        [HttpPost]
            public Komentar Add([FromBody] PitanjeAddVM x)
            {
            var novopitanje = new Komentar()
            {
                SadrzajKomentara = x.Pitanja,
                Artikal_id = x.artikalID,
                korisnik_id = x.korisnikID,
                DatumVrijeme = DateTime.Now

            };
                _dbContext.Komentar.Add(novopitanje);
                _dbContext.SaveChanges();
                return novopitanje;
            }

            //update

            [HttpPost("{id}")]
            public IActionResult Update(int id, [FromBody] PitanjeAddVM x)
            {


                Komentar pitanje = _dbContext.Komentar.FirstOrDefault(s => s.Id == id);

                if (pitanje == null)
                    return BadRequest("Pogresan ID");

                pitanje.SadrzajKomentara = x.Pitanja;
               

                _dbContext.SaveChanges();
                return Get(id);
            }
            [HttpGet]
            public ActionResult<List<Komentar>> GetAll(string Naziv)
            {

                var data = _dbContext.Komentar.Where(x => Naziv == null || (x.SadrzajKomentara)
                .StartsWith(Naziv))
                    .OrderByDescending(s => s.SadrzajKomentara).ThenByDescending(s => s.SadrzajKomentara)
                    .AsQueryable();
                return data.Take(100).ToList();

            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {

            Komentar pitanje = _dbContext.Komentar.Find(id);

                if (pitanje == null)
                    return BadRequest("Pogresan ID");

                _dbContext.Remove(pitanje);
                _dbContext.SaveChanges();
                return Ok(pitanje);
            }
        
    }
}
