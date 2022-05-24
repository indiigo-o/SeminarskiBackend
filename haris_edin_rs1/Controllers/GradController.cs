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
    public class GradController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GradController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Grad.FirstOrDefault(s => s.Id == id));
        }


        public class GradAddVM
        {
           
            public string Naziv { get; set; }
            public string PostanskiBroj { get; set; }
        }
        //add
        [HttpPost]
        public Grad Add([FromBody] GradAddVM x)
        {

            var noviGrad = new Grad()
            {
                Naziv = x.Naziv,
                PostanskiBroj = x.PostanskiBroj
                
            };
            _dbContext.Add(noviGrad);
            _dbContext.SaveChanges();
            return noviGrad;
        }

        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] GradAddVM x)
        {
           

            Grad grad = _dbContext.Grad.FirstOrDefault(s => s.Id == id);

            if (grad == null)
                return BadRequest("Pogresan ID");

            grad.Naziv = x.Naziv;
            grad.PostanskiBroj = x.PostanskiBroj;
        
            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<Grad>> GetAll(string Naziv)
        {

            var data = _dbContext.Grad.Where(x => Naziv == null || (x.Naziv)
            .StartsWith(Naziv))
                .OrderByDescending(s => s.Naziv).ThenByDescending(s => s.Naziv)
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           
            Grad grad = _dbContext.Grad.Find(id);

            if (grad == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(grad);
            _dbContext.SaveChanges();
            return Ok(grad);
        }
    }
}
