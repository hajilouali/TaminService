using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _99032778895 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSW_IDPLC",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DSW_NAT",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Places",
                newName: "DSW_IDPLC");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Placeid",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    DSW_NAT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryID",
                table: "Employees",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Placeid",
                table: "Employees",
                column: "Placeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryID",
                table: "Employees",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Places_Placeid",
                table: "Employees",
                column: "Placeid",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Places_Placeid",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CountryID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Placeid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Placeid",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DSW_IDPLC",
                table: "Places",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "DSW_IDPLC",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DSW_NAT",
                table: "Employees",
                nullable: true);
        }
    }
}
