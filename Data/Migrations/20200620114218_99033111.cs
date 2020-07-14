using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _99033111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ListEmployees",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "ListEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListEmployeeID",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListEmployees_UserID",
                table: "ListEmployees",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListEmployees_AspNetUsers_UserID",
                table: "ListEmployees",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListEmployees_AspNetUsers_UserID",
                table: "ListEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ListEmployees_UserID",
                table: "ListEmployees");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ListEmployees");

            migrationBuilder.DropColumn(
                name: "ListEmployeeID",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ListEmployees",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
