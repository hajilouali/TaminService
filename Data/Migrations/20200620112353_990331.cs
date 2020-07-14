using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990331 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeListID",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListEmployees", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ListEmployees_ListEmployeeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ListEmployees");

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
    }
}
