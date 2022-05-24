using haris_edin_rs1.Data;
using haris_edin_rs1.Models;
using haris_edin_rs1.ViewModels;
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
    public class AdministratorController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public AdministratorController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Administrator Add([FromBody] AdministratorAddVM x)
        {

            var noviadministrator = new Administrator()
            {
                AdministratorIme = x.administratorime,
                KorisnickoIme = x.korisnickoime,
                Lozinka = x.lozinka


            };
            _dbContext.Add(noviadministrator);
            _dbContext.SaveChanges();
            return noviadministrator;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Administratori.Where(x => x.Id == id));
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] AdminUpdateAddVM x)
        {
            Administrator admin = _dbContext.Administratori.FirstOrDefault(s => s.Id == id);

            if (admin == null)
                return BadRequest("pogresan ID");

            admin.AdministratorIme = x.administratorime;
            admin.KorisnickoIme = x.korisnickoime;
            admin.Lozinka = x.lozinka;

            _dbContext.SaveChanges();
            return Get(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Administrator admin = _dbContext.Administratori.Find(id);

            if (admin == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(admin);
            _dbContext.SaveChanges();
            return Ok(admin);

        }



        //[HttpGet]
        //public List<Administrator>GetAll(string adminime)
        //{
        //    var data = _dbContext.Administratori
        //        .Where(x => adminime == null || (x.AdministratorIme).StartsWith(adminime)).AsQueryable();
        //    return data.Take(100).ToList();
        //}

    }
}
