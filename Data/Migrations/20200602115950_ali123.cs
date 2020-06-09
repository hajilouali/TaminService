using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ali123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CodePhone = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(maxLength: 200, nullable: true),
                    ProfilePIC = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 700, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Tikets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Closed = table.Column<bool>(nullable: false),
                    Level = table.Column<short>(nullable: false),
                    Department = table.Column<short>(nullable: false),
                    IsAdminSide = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DataCreate = table.Column<DateTime>(nullable: false),
                    DataModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tikets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tikets_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
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
                name: "TiketContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TiketId = table.Column<int>(nullable: false),
                    IsAdminSide = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    FileURL = table.Column<string>(nullable: true),
                    DataCreate = table.Column<DateTime>(nullable: false),
                    DataModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiketContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiketContents_Tikets_TiketId",
                        column: x => x.TiketId,
                        principalTable: "Tikets",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

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
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TiketContents_TiketId",
                table: "TiketContents",
                column: "TiketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tikets_UserID",
                table: "Tikets",
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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "PayementHistories");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TiketContents");

            migrationBuilder.DropTable(
                name: "UserPayements");

            migrationBuilder.DropTable(
                name: "WorkMonths");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tikets");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "KarMonths");

            migrationBuilder.DropTable(
                name: "Manufacturys");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
