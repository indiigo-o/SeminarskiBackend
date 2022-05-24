using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using haris_edin_rs1.Models;
using haris_edin_rs1.ModelsAutentififkacija;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.Data
{
    public class ApplicationDbContext : DbContext
    {


       public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Grad> Grad { get; set; }

        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }

        public DbSet<Spol> Spol { get; set; }
        public DbSet<KategorijaProdukta> KategorijaProdukta { get; set; }
        public DbSet<Brend> Brend { get; set; }
        public DbSet<Artikal> Artikal { get; set; }
       
        public DbSet<Stanje>Stanje { get; set; }
        public DbSet<Poruke> Poruke { get; set; }

        public DbSet<Komentar> Komentar { get; set; }

        public DbSet<ArtikalSlika>ArtikalSlika { get; set; }



        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ovdje pise fluent api konfiguraciju

            //modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            //modelBuilder.Entity<Administrator>().ToTable("Administrator");


        }
    }
}
