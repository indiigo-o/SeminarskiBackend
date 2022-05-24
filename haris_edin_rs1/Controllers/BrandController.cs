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
    public class BrandController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public BrandController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Brend.FirstOrDefault(s => s.Id == id));
        }


        public class BrendAddVM
        {

            public string Ime { get; set; }
            public Boolean Aktivan { get; set; }
        }
        //add
        [HttpPost]
        public Brend Add([FromBody] BrendAddVM x)
        {
            
            var noviBrend = new Brend()
            {
                Ime = x.Ime,
                Aktivan = x.Aktivan,

            };
            _dbContext.Add(noviBrend);
            _dbContext.SaveChanges();
            return noviBrend;
        }

        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] BrendAddVM x)
        {


            Brend brend = _dbContext.Brend.FirstOrDefault(s => s.Id == id);

            if (brend == null)
                return BadRequest("Pogresan ID");

            brend.Ime = x.Ime;
            brend.Aktivan = x.Aktivan;

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<Brend>> GetAll(string Naziv)
        {

            var data = _dbContext.Brend.Where(x => Naziv == null || (x.Ime)
            .StartsWith(Naziv))
                .OrderByDescending(s => s.Ime).ThenByDescending(s => s.Ime)
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Brend brend = _dbContext.Brend.Find(id);

            if (brend == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(brend);
            _dbContext.SaveChanges();
            return Ok(brend);
        }
    }
}
