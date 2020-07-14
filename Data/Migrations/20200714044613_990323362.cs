using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990323362 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Tikets");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Tikets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Tikets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "Department",
                table: "Tikets",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
