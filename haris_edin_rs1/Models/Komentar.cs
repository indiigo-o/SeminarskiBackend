using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public string SadrzajKomentara { get; set; }


        [ForeignKey(nameof(artikal))]
        public int Artikal_id { get; set; }
        public Artikal artikal { get; set; }

        [ForeignKey(nameof(korisnik))]
        public int? korisnik_id { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime DatumVrijeme { get; set; }

    }
}
