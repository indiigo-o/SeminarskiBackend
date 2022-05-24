using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    [Table("Administrator")]
    public class Administrator : KorisnickiNalog
    {
       
        public string AdministratorIme { get; set; }

    }
}
