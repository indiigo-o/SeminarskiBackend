using haris_edin_rs1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.ViewModels
{
    public class ArtikalImagesAddVM
    {
        public List<IFormFile> Images { get; set; }
        public Artikal Artikal { get; set; }
    }
}
