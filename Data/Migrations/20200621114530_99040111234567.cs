using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _99040111234567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jobid",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jobid",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }
    }
}
