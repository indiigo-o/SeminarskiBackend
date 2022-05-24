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
using haris_edin_rs1.ViewModels;
using System.Net.Http.Headers;
using Microsoft.Extensions.FileProviders;
using System.Web;


namespace haris_edin_rs1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArtikalController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
       // private object webHostEnvironment;
        private readonly IWebHostEnvironment webHostEnvironment;

        
        private IHttpContextAccessor httpContextAccessor;

        public ArtikalController(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment, IHttpContextAccessor _httpContextAccessor)
        {
            this._dbContext = dbContext;
            webHostEnvironment = hostEnvironment;
            httpContextAccessor = _httpContextAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Artikal.Include(kp => kp.kategorijaprodukta)
                .Include(b => b.brend).Include(st => st.stanje).Include(k=>k.korisnik).Include(g=>g.korisnik.grad).FirstOrDefault(s => s.Id == id));
        }

        public class ArtikalAddVM
        {

            public int Kategorija_Produkta_id { get; set; }
            public int Brend_id { get; set; }
           
            public int Korisnik_id { get; set; }
            public string NazivArtikla { get; set; }
            public double Cijena { get; set; }

            public bool Aktivan { get; set; }
            public DateTime DatumObjave { get; set; }
            public int Stanje { get; set; }
             public IFormFile SlikaArtikla { get; set; }

            public string Godiste { get; set; }
            public string Kilometraza { get; set; }
            public bool Registrovan { get; set; }
            public bool Plin { get; set; }
            public bool Klima { get; set; }
            public bool ABS { get; set; }
            public string Gorivo { get; set; }
            public string Model { get; set; }
            public string DetaljanOpis { get; set; }


        }
        //view model za slike artikla
      
        //add
        [HttpPost]
        public Artikal Add([FromBody] ArtikalAddVM x)
        {
            
            var noviArtikal = new Artikal()
            {
                Kategorija_Produkta_id = x.Kategorija_Produkta_id,
                Brend_id = x.Brend_id,
                korisnik_id = x.Korisnik_id,
                NazivArtikla = x.NazivArtikla,
                Cijena = x.Cijena,
                Aktivan = x.Aktivan,
                Stanje_id = x.Stanje,
                DatumObjave = x.DatumObjave,
                SlikaArtikla = "prazno.jpg",
                Godiste = x.Godiste,
                Kilometraza = x.Kilometraza,
                Registrovan = x.Registrovan,
                Plin = x.Plin,
                Klima = x.Klima,
                ABS=x.ABS,
                Gorivo = x.Gorivo,
                Model =x.Model,
                DetaljanOpis = x.DetaljanOpis
            };

            var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" +
                  httpContextAccessor.HttpContext.Request.Host +
                  httpContextAccessor.HttpContext.Request.PathBase;
            if (x.SlikaArtikla != null)
            {
                string ekstenzija = Path.GetExtension(x.SlikaArtikla.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.SlikaArtikla.CopyTo(new FileStream("wwwroot/" + "uploads/" + filename, FileMode.Create));
                noviArtikal.SlikaArtikla = "https://localhost:44308/" + "uploads/" + filename;
            }


            _dbContext.Artikal.Add(noviArtikal);
            _dbContext.SaveChanges();
            return noviArtikal;
        }


        public class artikalslikaADDVM
        {
            public IFormFile SlikaArtikla { get; set; }
            public int Artikal_id { get; set; }
        }

        [HttpPost("{id}")]
        public IActionResult DodajSliku(int id, IFormFile file)
        {
            Artikal artikal = _dbContext.Artikal.FirstOrDefault(s => s.Id == id);
            if (file != null)
            {

                if (file.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    var filepath =
                     new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();

                        artikal.SlikaArtikla = "https://localhost:44308/" + "uploads/" + newFileName;


                    }

                }
            }
                _dbContext.SaveChanges();
                return Ok("u redu");
        }



        [HttpPost("{id}")]
        public IActionResult DodajSlike(List<IFormFile> files,int id)
        {

            // var artikalslike = new ArtikalSlika();
            var novalista = new List<ArtikalSlika>();

            var idartikla = _dbContext.Artikal.OrderByDescending(x=>x.Id).FirstOrDefault().Id;

            if (files != null)
            {
                foreach (var file in files)
                {
                    var noviartikallika = new ArtikalSlika();

                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
                         new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")).Root + $@"\{newFileName}";
                        
                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                            noviartikallika.Artikal_id = id;
                            noviartikallika.ImageName =  "https://localhost:44308/" + "uploads/" + newFileName;

                        }

                    }
                    novalista.Add(noviartikallika);
                    _dbContext.ArtikalSlika.Add(noviartikallika);
                    _dbContext.SaveChanges();
                  //  _dbContext.UpdateRange();

                }
            }


            return Ok(novalista);
        }





        //update

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromForm] ArtikalAddVM x)
        {
            Artikal artikal = _dbContext.Artikal.FirstOrDefault(s => s.Id == id);
            if (artikal == null)
                return BadRequest("Pogresan ID");

            artikal.Kategorija_Produkta_id = x.Kategorija_Produkta_id;
            artikal.Brend_id = x.Brend_id;
            artikal.korisnik_id = x.Korisnik_id;
            artikal.NazivArtikla = x.NazivArtikla;
            artikal.Cijena = x.Cijena;
            artikal.Aktivan = x.Aktivan;
            artikal.DatumObjave = x.DatumObjave;
            artikal.Stanje_id = x.Stanje;
            artikal.Godiste = x.Godiste;
            artikal.Kilometraza = x.Kilometraza;
            artikal.Registrovan = x.Registrovan;
            artikal.Plin = x.Plin;
            artikal.Klima = x.Klima;
            artikal.ABS = x.ABS;
            artikal.Gorivo = x.Gorivo;
            artikal.Model = x.Model;
            artikal.DetaljanOpis = x.DetaljanOpis;
            var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" +
                 httpContextAccessor.HttpContext.Request.Host +
                 httpContextAccessor.HttpContext.Request.PathBase;
            if (x.SlikaArtikla != null)
            {
                string ekstenzija = Path.GetExtension(x.SlikaArtikla.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.SlikaArtikla.CopyTo(new FileStream("wwwroot/" + "uploads/" + filename, FileMode.Create));
                artikal.SlikaArtikla = "https://localhost:44308/" + "uploads/" + filename;
            }



            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<Artikal>> GetAll()
        {

            var data = _dbContext.Artikal.Include(kp => kp.kategorijaprodukta)
                .Include(b => b.brend).Include(st => st.stanje)
                .Include(k=>k.korisnik).ToList();
            return data;

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Artikal artikal = _dbContext.Artikal.Find(id);

            if (artikal == null)
                return BadRequest("Pogresan ID");

            _dbContext.Remove(artikal);
            _dbContext.SaveChanges();
            return Ok(artikal);
        }
        [HttpGet("{id}")]
        public IActionResult GetPoKategoriji(int id)
        {
            return Ok(_dbContext.Artikal.Include(kp => kp.kategorijaprodukta)
                .Include(b => b.brend).Include(st => st.stanje).Where(kp => kp.Kategorija_Produkta_id == id));
        }
        [HttpGet("{id}")]
        public IActionResult GetPoBrendu(int id)
        {
            return Ok(_dbContext.Artikal.Include(kp => kp.kategorijaprodukta)
                .Include(b => b.brend).Include(st => st.stanje).Where(kp => kp.Brend_id == id));
        }
        [HttpGet("{id}")]
        public IActionResult GetPoStanju(int id)
        {
            return Ok(_dbContext.Artikal.Include(kp => kp.kategorijaprodukta)
               .Include(st => st.stanje).Where(kp => kp.Stanje_id == id));
        }
       
 
        [HttpGet("{id}")]
    public IActionResult GetPoKorisniku(int id)
    {
        return Ok(_dbContext.Artikal.Include(kp => kp.kategorijaprodukta)
            .Include(b => b.brend).Include(st => st.stanje).Include(k=>k.korisnik).Include(kg => kg.korisnik.grad).Where(kp => kp.korisnik_id == id));
    }

        [HttpGet("{id}")]
        public IActionResult GetSlikepoID(int id)
        {
            try
            {
                return Ok(_dbContext.ArtikalSlika.Where(kp => kp.Artikal_id == id));
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
           
        }





    }
}
