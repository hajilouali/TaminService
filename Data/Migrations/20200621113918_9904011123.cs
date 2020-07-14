using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _9904011123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jobtableid",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jobtableid",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }
    }
}
