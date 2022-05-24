using haris_edin_rs1.Data;
using haris_edin_rs1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KategorijaProduktaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KategorijaProduktaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.KategorijaProdukta.FirstOrDefault(s => s.Id == id));
        }


        public class KategorijaProduktaAddVM
        {

            public string Ime { get; set; }
            public Boolean Aktivan { get; set; }
        }
        //add
        [HttpPost]
        public KategorijaProdukta Add([FromBody] KategorijaProduktaAddVM x)
        {

            var novaKategorija = new KategorijaProdukta()
            {
                Ime = x.Ime,
                Aktivan = x.Aktivan,

            };
            _dbContext.Add(novaKategorija);
            _dbContext.SaveChanges();
            return novaKategorija;
        }

        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] KategorijaProduktaAddVM x)
        {


            KategorijaProdukta katetgorija = _dbContext.KategorijaProdukta.FirstOrDefault(s => s.Id == id);

            if (katetgorija == null)
                return BadRequest("Pogresan ID");

            katetgorija.Ime = x.Ime;
            katetgorija.Aktivan = x.Aktivan;

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<KategorijaProdukta>> GetAll(string Naziv)
        {

            var data = _dbContext.KategorijaProdukta.Where(x => Naziv == null || (x.Ime)
            .StartsWith(Naziv))
                .OrderByDescending(s => s.Ime).ThenByDescending(s => s.Ime)
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            KategorijaProdukta kategorija = _dbContext.KategorijaProdukta.Find(id);

            if (kategorija == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(kategorija);
            _dbContext.SaveChanges();
            return Ok(kategorija);
        }
    }
}
