using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _990310111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    DSW_ID1 = table.Column<string>(nullable: true),
                    DSW_FNAME = table.Column<string>(nullable: true),
                    DSW_LNAME = table.Column<string>(nullable: true),
                    DSW_DNAME = table.Column<string>(nullable: true),
                    DSW_IDNO = table.Column<string>(nullable: true),
                    DSW_IDPLC = table.Column<string>(nullable: true),
                    DSW_IDATE = table.Column<string>(nullable: true),
                    DSW_BDATE = table.Column<string>(nullable: true),
                    DSW_SEX = table.Column<string>(nullable: true),
                    DSW_NAT = table.Column<string>(nullable: true),
                    DSW_OCP = table.Column<string>(nullable: true),
                    DSW_JOB = table.Column<string>(nullable: true),
                    PER_NATCOD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    DSK_ID = table.Column<string>(nullable: true),
                    DSK_NAME = table.Column<string>(nullable: true),
                    DSK_FARM = table.Column<string>(nullable: true),
                    DSK_ADRS = table.Column<string>(nullable: true),
                    MON_PYM = table.Column<string>(nullable: true),
                    DSK_RATE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturys_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayementHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsSucess = table.Column<bool>(nullable: false),
                    CodeRahgiri = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayementHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayementHistories_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPayements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Bedehkari = table.Column<decimal>(nullable: false),
                    Bestankar = table.Column<decimal>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    Status = table.Column<short>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPayements_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KarMonths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    ManufacturyID = table.Column<int>(nullable: false),
                    DSK_KIND = table.Column<int>(nullable: false),
                    DSK_YY = table.Column<int>(nullable: false),
                    DSK_MM = table.Column<int>(nullable: false),
                    DSK_LISTNO = table.Column<string>(nullable: true),
                    DSK_DISC = table.Column<string>(nullable: true),
                    DSK_NUM = table.Column<int>(nullable: false),
                    DSK_TDD = table.Column<int>(nullable: false),
                    DSK_TROOZ = table.Column<int>(nullable: false),
                    DSK_TMAH = table.Column<int>(nullable: false),
                    DSK_TMAZ = table.Column<int>(nullable: false),
                    DSK_TMASH = table.Column<int>(nullable: false),
                    DSK_TTOTL = table.Column<int>(nullable: false),
                    DSK_TBIME = table.Column<int>(nullable: false),
                    DSK_TKOSO = table.Column<int>(nullable: false),
                    DSK_BIC = table.Column<int>(nullable: false),
                    DSK_PRATE = table.Column<int>(nullable: false),
                    DSK_BIMH = table.Column<int>(nullable: false),
                    ManufacturysId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KarMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KarMonths_Manufacturys_ManufacturysId",
                        column: x => x.ManufacturysId,
                        principalTable: "Manufacturys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkMonths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KarMonthID = table.Column<int>(nullable: false),
                    EmployeID = table.Column<int>(nullable: false),
                    DSW_ID = table.Column<string>(nullable: true),
                    DSW_YY = table.Column<int>(nullable: false),
                    DSW_MM = table.Column<int>(nullable: false),
                    DSW_LISTNO = table.Column<string>(nullable: true),
                    DSW_SDATE = table.Column<string>(nullable: true),
                    DSW_EDATE = table.Column<string>(nullable: true),
                    DSW_DD = table.Column<int>(nullable: false),
                    DSW_ROOZ = table.Column<int>(nullable: false),
                    DSW_MAH = table.Column<int>(nullable: false),
                    DSW_MAZ = table.Column<int>(nullable: false),
                    DSW_MASH = table.Column<int>(nullable: false),
                    DSW_TOTL = table.Column<int>(nullable: false),
                    DSW_BIME = table.Column<int>(nullable: false),
                    DSW_PRATE = table.Column<int>(nullable: false),
                    EmployeesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkMonths_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkMonths_KarMonths_KarMonthID",
                        column: x => x.KarMonthID,
                        principalTable: "KarMonths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_KarMonths_ManufacturysId",
                table: "KarMonths",
                column: "ManufacturysId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturys_UserID",
                table: "Manufacturys",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PayementHistories_UserID",
                table: "PayementHistories",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayements_UserID",
                table: "UserPayements",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMonths_EmployeesId",
                table: "WorkMonths",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMonths_KarMonthID",
                table: "WorkMonths",
                column: "KarMonthID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "PayementHistories");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "UserPayements");

            migrationBuilder.DropTable(
                name: "WorkMonths");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "KarMonths");

            migrationBuilder.DropTable(
                name: "Manufacturys");
        }
    }
}
