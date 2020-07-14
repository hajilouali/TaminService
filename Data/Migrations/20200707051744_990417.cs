using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990417 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkMonths_Employees_EmployeesId",
                table: "WorkMonths");

            migrationBuilder.DropIndex(
                name: "IX_WorkMonths_EmployeesId",
                table: "WorkMonths");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "WorkMonths");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMonths_EmployeID",
                table: "WorkMonths",
                column: "EmployeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkMonths_Employees_EmployeID",
                table: "WorkMonths",
                column: "EmployeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkMonths_Employees_EmployeID",
                table: "WorkMonths");

            migrationBuilder.DropIndex(
                name: "IX_WorkMonths_EmployeID",
                table: "WorkMonths");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "WorkMonths",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkMonths_EmployeesId",
                table: "WorkMonths",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkMonths_Employees_EmployeesId",
                table: "WorkMonths",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
