using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990327 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSW_JOB",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Jobs",
                newName: "DSW_JOB");

            migrationBuilder.AddColumn<int>(
                name: "JobsId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "jobid",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Jobs_JobsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "jobid",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DSW_JOB",
                table: "Jobs",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "DSW_JOB",
                table: "Employees",
                nullable: true);
        }
    }
}
