using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Models
{
    public class Artikal
    {
        public int Id { get; set; }
        [ForeignKey(nameof(kategorijaprodukta))]
        public int Kategorija_Produkta_id { get; set; }
        public KategorijaProdukta kategorijaprodukta { get; set; }
        
        [ForeignKey(nameof(brend))]
        public int Brend_id { get; set; }
        public Brend brend { get; set; }

     
        [ForeignKey(nameof(korisnik))]
        public int korisnik_id { get; set; }
        public Korisnik korisnik { get; set; }


        public string NazivArtikla { get; set; }
        public double Cijena { get; set; }
        
        public bool Aktivan { get; set; }
        //public int Popust { get; set; }
        public DateTime DatumObjave { get; set; }

        //Datum kada je objavljen 
        //Detaljan opis  kao properti 
        //Slike

        [ForeignKey(nameof(stanje))]
        public int Stanje_id { get; set; }
        public Stanje stanje { get; set; }

        public string SlikaArtikla { get; set; }

        public string Godiste { get; set; }
        public string  Kilometraza { get; set; }
        public bool Registrovan { get; set; }
        public bool Plin { get; set; }
        public bool Klima { get; set; }
        public bool ABS { get; set; }
        public string Gorivo { get; set; }
        public string Model { get; set; }
        public string DetaljanOpis { get; set; }
        





    }
}
