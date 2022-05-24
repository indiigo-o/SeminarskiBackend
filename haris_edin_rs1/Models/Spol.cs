using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    public class Spol
    {
        [Key]
        public int Id { get; set; }
       
        public string Ime { get; set; }
        public Boolean Aktivan { get; set; }

    }
}
