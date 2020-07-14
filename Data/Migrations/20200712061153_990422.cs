using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990422 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeRahgiri",
                table: "PayementHistories",
                newName: "Transactioncode");

            migrationBuilder.AddColumn<string>(
                name: "Gateway",
                table: "PayementHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trackingnumber",
                table: "PayementHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gateway",
                table: "PayementHistories");

            migrationBuilder.DropColumn(
                name: "Trackingnumber",
                table: "PayementHistories");

            migrationBuilder.RenameColumn(
                name: "Transactioncode",
                table: "PayementHistories",
                newName: "CodeRahgiri");
        }
    }
}
