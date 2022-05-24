using haris_edin_rs1.Data;
using haris_edin_rs1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PorukaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PorukaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class PorukaAddVM
        {
            public int Posiljaoc_id { get; set; }
           
            public string Sadrzaj { get; set; }
            public int Primaoc_id { get; set; }
            
        }

        [HttpPost]
        public IActionResult Add ([FromBody] PorukaAddVM x)
        {
            var novaPoruka = new Poruke()
            {
                Posiljaoc_id = x.Posiljaoc_id,
                Sadrzaj = x.Sadrzaj,
                Primaoc_id = x.Primaoc_id,
                Datum = DateTime.Now

            };
            _dbContext.Poruke.Add(novaPoruka);
            _dbContext.SaveChanges();

            return Ok(novaPoruka);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Poruke>> GetPrimaocId(int id)
        {
            return Ok(_dbContext.Poruke.Include(x=>x.korisnik).Where(x=>x.Primaoc_id == id).ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<List<Poruke>> GetPosiljaocId(int id)
        {
            return Ok(_dbContext.Poruke.Include(x => x.korisnik).Where(x => x.Posiljaoc_id == id).ToList());
        }


    }
}
