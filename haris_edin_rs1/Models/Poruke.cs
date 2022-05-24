using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    public class Poruke
    {
        public int Id { get; set; }

        [ForeignKey(nameof(korisnik))]
        public int Posiljaoc_id { get; set; }
        public Korisnik korisnik { get; set; }

        public string Sadrzaj { get; set; }
        public int Primaoc_id { get; set; }
        public DateTime Datum { get; set; }

        // datum kad je poslana poruka


    }
}
