using Microsoft.EntityFrameworkCore.Migrations;

namespace haris_edin_rs1.Migrations
{
    public partial class slikanaziv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SlikaArtikla",
                table: "Korisnik",
                newName: "SlikaProfila");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SlikaProfila",
                table: "Korisnik",
                newName: "SlikaArtikla");
        }
    }
}
