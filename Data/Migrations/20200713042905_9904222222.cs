using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _9904222222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferCode",
                table: "PayementHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferCode",
                table: "PayementHistories");
        }
    }
}
