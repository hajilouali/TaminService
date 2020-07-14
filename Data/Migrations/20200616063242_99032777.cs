using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _99032777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSW_OCP",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "DSW_OCP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DSW_OCP",
                table: "Jobs",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "DSW_OCP",
                table: "Employees",
                nullable: true);
        }
    }
}
