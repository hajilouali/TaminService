using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990401112345678 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "jobid",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_jobid",
                table: "Employees",
                column: "jobid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Jobs_jobid",
                table: "Employees",
                column: "jobid",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Jobs_jobid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_jobid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "jobid",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "JobsId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobsId",
                table: "Employees",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Jobs_JobsId",
                table: "Employees",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
