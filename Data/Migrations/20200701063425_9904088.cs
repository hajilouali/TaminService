using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _9904088 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KarMonths_Manufacturys_ManufacturysId",
                table: "KarMonths");

            migrationBuilder.DropIndex(
                name: "IX_KarMonths_ManufacturysId",
                table: "KarMonths");

            migrationBuilder.DropColumn(
                name: "ManufacturysId",
                table: "KarMonths");

            migrationBuilder.CreateIndex(
                name: "IX_KarMonths_ManufacturyID",
                table: "KarMonths",
                column: "ManufacturyID");

            migrationBuilder.AddForeignKey(
                name: "FK_KarMonths_Manufacturys_ManufacturyID",
                table: "KarMonths",
                column: "ManufacturyID",
                principalTable: "Manufacturys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KarMonths_Manufacturys_ManufacturyID",
                table: "KarMonths");

            migrationBuilder.DropIndex(
                name: "IX_KarMonths_ManufacturyID",
                table: "KarMonths");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturysId",
                table: "KarMonths",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KarMonths_ManufacturysId",
                table: "KarMonths",
                column: "ManufacturysId");

            migrationBuilder.AddForeignKey(
                name: "FK_KarMonths_Manufacturys_ManufacturysId",
                table: "KarMonths",
                column: "ManufacturysId",
                principalTable: "Manufacturys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
