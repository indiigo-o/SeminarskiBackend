using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace haris_edin_rs1.Migrations
{
    public partial class sve_haris_radio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijaProdukta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaProdukta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdministratorIme = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvideniranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_korisnickiNalogId",
                        column: x => x.korisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad_id = table.Column<int>(type: "int", nullable: false),
                    Spol_id = table.Column<int>(type: "int", nullable: false),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_Grad_id",
                        column: x => x.Grad_id,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_Spol_Spol_id",
                        column: x => x.Spol_id,
                        principalTable: "Spol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategorija_Produkta_id = table.Column<int>(type: "int", nullable: false),
                    Brend_id = table.Column<int>(type: "int", nullable: false),
                    korisnik_id = table.Column<int>(type: "int", nullable: false),
                    NazivArtikla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stanje_id = table.Column<int>(type: "int", nullable: false),
                    SlikaArtikla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godiste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kilometraza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registrovan = table.Column<bool>(type: "bit", nullable: false),
                    Plin = table.Column<bool>(type: "bit", nullable: false),
                    Klima = table.Column<bool>(type: "bit", nullable: false),
                    ABS = table.Column<bool>(type: "bit", nullable: false),
                    Gorivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetaljanOpis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artikal_Brend_Brend_id",
                        column: x => x.Brend_id,
                        principalTable: "Brend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikal_KategorijaProdukta_Kategorija_Produkta_id",
                        column: x => x.Kategorija_Produkta_id,
                        principalTable: "KategorijaProdukta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikal_Korisnik_korisnik_id",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikal_Stanje_Stanje_id",
                        column: x => x.Stanje_id,
                        principalTable: "Stanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posiljaoc_id = table.Column<int>(type: "int", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Primaoc_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poruke_Korisnik_Posiljaoc_id",
                        column: x => x.Posiljaoc_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SadrzajKomentara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artikal_id = table.Column<int>(type: "int", nullable: false),
                    korisnik_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentar_Artikal_Artikal_id",
                        column: x => x.Artikal_id,
                        principalTable: "Artikal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentar_Korisnik_korisnik_id",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_Brend_id",
                table: "Artikal",
                column: "Brend_id");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_Kategorija_Produkta_id",
                table: "Artikal",
                column: "Kategorija_Produkta_id");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_korisnik_id",
                table: "Artikal",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_Stanje_id",
                table: "Artikal",
                column: "Stanje_id");

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_korisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "korisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_Artikal_id",
                table: "Komentar",
                column: "Artikal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_korisnik_id",
                table: "Komentar",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Grad_id",
                table: "Korisnik",
                column: "Grad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Spol_id",
                table: "Korisnik",
                column: "Spol_id");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_Posiljaoc_id",
                table: "Poruke",
                column: "Posiljaoc_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Brend");

            migrationBuilder.DropTable(
                name: "KategorijaProdukta");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Stanje");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Spol");
        }
    }
}
