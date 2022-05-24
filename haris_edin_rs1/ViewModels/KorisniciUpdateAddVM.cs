using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.ViewModels
{
    public class KorisniciUpdateAddVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
     
        public string Adresa { get; set; }
        public int Grad_id { get; set; }
    
      
    
        public string KontaktTelefon { get; set; }
        public IFormFile SlikaArtikla { get; set; }
    }
}
