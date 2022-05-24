using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace haris_edin_rs1.Migrations
{
    public partial class komenarslika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaArtikla",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumVrijeme",
                table: "Komentar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaArtikla",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "DatumVrijeme",
                table: "Komentar");
        }
    }
}
