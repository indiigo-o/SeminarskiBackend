using Microsoft.EntityFrameworkCore.Migrations;

namespace haris_edin_rs1.Migrations
{
    public partial class arikal_bezslike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaArtikla",
                table: "Artikal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaArtikla",
                table: "Artikal",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
