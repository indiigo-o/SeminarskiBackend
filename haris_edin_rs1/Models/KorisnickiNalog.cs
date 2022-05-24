using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    [Table("KorisnickiNalog")]
    public abstract class KorisnickiNalog
    {
       
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public string KorisnickoIme { get; set; }
       
        public string Lozinka { get; set; }

        [JsonIgnore]
        public Korisnik korisnik => this as Korisnik;
        
        

        public bool isKorisnik => korisnik != null;
        public bool isAdmin { get; set; }

    }
}
