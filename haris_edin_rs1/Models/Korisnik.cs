using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    [Table("Korisnik")]
    public class Korisnik : KorisnickiNalog
    {
        
       
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        [ForeignKey(nameof(grad))]
        public int Grad_id { get; set; }
        public Grad grad { get; set; }

        [ForeignKey(nameof(spol))]
        public int Spol_id { get; set; }
        public Spol spol { get; set; }

        public string KontaktTelefon { get; set; }
        public string SlikaProfila { get; set; }

        public bool Twoway { get; set; }

    }
}
