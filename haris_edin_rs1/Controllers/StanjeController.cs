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
    public class StanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StanjeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Stanje.FirstOrDefault(s => s.Id == id));
        }


        public class StanjeAddVM
        {

            public string Naziv { get; set; }
           
        }
        //add
        [HttpPost]
        public Stanje Add([FromBody] StanjeAddVM x)
        {

            var noviStanje = new Stanje()
            {
                Naziv = x.Naziv
                
            };
            _dbContext.Add(noviStanje);
            _dbContext.SaveChanges();
            return noviStanje;
        }

        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] StanjeAddVM x)
        {


            Stanje stanje = _dbContext.Stanje.FirstOrDefault(s => s.Id == id);

            if (stanje == null)
                return BadRequest("Pogresan ID");

            stanje.Naziv = x.Naziv;
           

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<Stanje>> GetAll()
        {

            var data = _dbContext.Stanje
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Stanje stanje = _dbContext.Stanje.Find(id);

            if (stanje == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(stanje);
            _dbContext.SaveChanges();
            return Ok(stanje);
        }
    }
}
