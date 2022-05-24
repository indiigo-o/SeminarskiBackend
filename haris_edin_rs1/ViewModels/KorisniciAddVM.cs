using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.ViewModels
{
    public class KorisniciAddVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public DateTime dtumRodjenja { get; set; }
        public string adresa { get; set; }
        public string korisnickoime { get; set; }
        public string lozinka { get; set; }
        public int grad_id { get; set; }
        public int spol_id { get; set; }
        public string KontaktTelefon { get; set; }
        public IFormFile SlikaArtikla { get; set; }
    }
}
