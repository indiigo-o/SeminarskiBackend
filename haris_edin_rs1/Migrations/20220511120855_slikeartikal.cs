using Microsoft.EntityFrameworkCore.Migrations;

namespace haris_edin_rs1.Migrations
{
    public partial class slikeartikal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtikalSlika_Artikal_ArtikalId",
                table: "ArtikalSlika");

            migrationBuilder.DropIndex(
                name: "IX_ArtikalSlika_ArtikalId",
                table: "ArtikalSlika");

            migrationBuilder.DropColumn(
                name: "ArtikalId",
                table: "ArtikalSlika");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "ArtikalSlika",
                newName: "Remark");

            migrationBuilder.AddColumn<int>(
                name: "Artikal_id",
                table: "ArtikalSlika",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ArtikalSlika",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtikalSlika_Artikal_id",
                table: "ArtikalSlika",
                column: "Artikal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtikalSlika_Artikal_Artikal_id",
                table: "ArtikalSlika",
                column: "Artikal_id",
                principalTable: "Artikal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtikalSlika_Artikal_Artikal_id",
                table: "ArtikalSlika");

            migrationBuilder.DropIndex(
                name: "IX_ArtikalSlika_Artikal_id",
                table: "ArtikalSlika");

            migrationBuilder.DropColumn(
                name: "Artikal_id",
                table: "ArtikalSlika");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ArtikalSlika");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "ArtikalSlika",
                newName: "ImageURL");

            migrationBuilder.AddColumn<int>(
                name: "ArtikalId",
                table: "ArtikalSlika",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtikalSlika_ArtikalId",
                table: "ArtikalSlika",
                column: "ArtikalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtikalSlika_Artikal_ArtikalId",
                table: "ArtikalSlika",
                column: "ArtikalId",
                principalTable: "Artikal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
