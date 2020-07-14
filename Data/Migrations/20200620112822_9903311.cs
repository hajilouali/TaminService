using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _9903311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ListEmployees_ListEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ListEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeListID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ListEmployeeId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeListID",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ListEmployeeId",
                table: "Employees",
                column: "ListEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ListEmployees_ListEmployeeId",
                table: "Employees",
                column: "ListEmployeeId",
                principalTable: "ListEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
