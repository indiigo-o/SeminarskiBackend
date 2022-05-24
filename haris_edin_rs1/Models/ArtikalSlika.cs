using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    public class ArtikalSlika
    {
        public int Id { get; set; }
        public string ImageName{ get; set; }
        public string Remark { get; set; }
       
        [ForeignKey(nameof(Artikal))]
        public int Artikal_id { get; set; }
        public Artikal Artikal { get; set; }

    }
}
