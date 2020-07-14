﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(127);

                    b.Property<string>("Keys")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Entities.SitePropertys.Pages.Pages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Keys");

                    b.Property<string>("PageContent");

                    b.Property<string>("PageTitle")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("ShortDiscription")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Entities.SitePropertys.Post.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("IsShow");

                    b.Property<int>("ParentID");

                    b.Property<int>("PostID");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("PostID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entities.SitePropertys.SMenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParentID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(1500);

                    b.HasKey("Id");

                    b.ToTable("SMenuItems");
                });

            modelBuilder.Entity("Entities.SitePropertys.SQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Question")
                        .HasMaxLength(500);

                    b.Property<string>("Respons")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("SQuestions");
                });

            modelBuilder.Entity("Entities.SitePropertys.SServiceSlider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SServiceSliders");
                });

            modelBuilder.Entity("Entities.SitePropertys.SUserQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsReade");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(1500);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("SUserQuestions");
                });

            modelBuilder.Entity("Entities.SSlider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discription")
                        .HasMaxLength(1000);

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .HasMaxLength(1500);

                    b.HasKey("Id");

                    b.ToTable("SSliders");
                });

            modelBuilder.Entity("Entities.Tamin.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("DSW_NAT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Entities.Tamin.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DSW_BDATE");

                    b.Property<string>("DSW_DNAME");

                    b.Property<string>("DSW_FNAME");

                    b.Property<string>("DSW_ID1");

                    b.Property<string>("DSW_IDATE");

                    b.Property<string>("DSW_IDNO");

                    b.Property<string>("DSW_IDPLC");

                    b.Property<string>("DSW_LNAME");

                    b.Property<string>("DSW_NAT");

                    b.Property<string>("DSW_SEX");

                    b.Property<bool>("IsKarfarma");

                    b.Property<int>("ListEmployeeID");

                    b.Property<string>("PER_NATCOD");

                    b.Property<int>("UserID");

                    b.Property<int>("jobid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.HasIndex("jobid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entities.Tamin.Jobs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DSW_JOB");

                    b.Property<string>("DSW_OCP");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Entities.Tamin.KarMonth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DSK_BIC");

                    b.Property<int>("DSK_BIMH");

                    b.Property<string>("DSK_DISC");

                    b.Property<int>("DSK_KIND");

                    b.Property<string>("DSK_LISTNO");

                    b.Property<int>("DSK_MM");

                    b.Property<int>("DSK_NUM");

                    b.Property<int>("DSK_PRATE");

                    b.Property<int>("DSK_TBIME");

                    b.Property<int>("DSK_TDD");

                    b.Property<int>("DSK_TKOSO");

                    b.Property<int>("DSK_TMAH");

                    b.Property<int>("DSK_TMASH");

                    b.Property<int>("DSK_TMAZ");

                    b.Property<int>("DSK_TROOZ");

                    b.Property<int>("DSK_TTOTL");

                    b.Property<int>("DSK_YY");

                    b.Property<DateTime>("DateCreate");

                    b.Property<int>("ManufacturyID");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturyID");

                    b.ToTable("KarMonths");
                });

            modelBuilder.Entity("Entities.Tamin.ListEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discription");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("ListEmployees");
                });

            modelBuilder.Entity("Entities.Tamin.Manufacturys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DSK_ADRS");

                    b.Property<string>("DSK_FARM");

                    b.Property<string>("DSK_ID");

                    b.Property<string>("DSK_NAME");

                    b.Property<int>("DSK_RATE");

                    b.Property<string>("MON_PYM");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Manufacturys");
                });

            modelBuilder.Entity("Entities.Tamin.OffersCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(10);

                    b.Property<int?>("CountExpire");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime?>("DateExpire");

                    b.Property<string>("Discription")
                        .HasMaxLength(150);

                    b.Property<int>("OfferRate");

                    b.HasKey("Id");

                    b.ToTable("OffersCodes");
                });

            modelBuilder.Entity("Entities.Tamin.PayementHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Discription");

                    b.Property<string>("Gateway");

                    b.Property<bool>("IsSucess");

                    b.Property<string>("OfferCode");

                    b.Property<decimal>("Price");

                    b.Property<long?>("Trackingnumber");

                    b.Property<string>("Transactioncode");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("PayementHistories");
                });

            modelBuilder.Entity("Entities.Tamin.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("DSW_IDPLC");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Entities.Tamin.UserPayement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bedehkari");

                    b.Property<decimal>("Bestankar");

                    b.Property<string>("Discription");

                    b.Property<short>("Status");

                    b.Property<int>("UserID");

                    b.Property<DateTime>("dateTime");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("UserPayements");
                });

            modelBuilder.Entity("Entities.Tamin.WorkMonth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DSW_BIME");

                    b.Property<int>("DSW_DD");

                    b.Property<string>("DSW_EDATE");

                    b.Property<string>("DSW_ID");

                    b.Property<string>("DSW_LISTNO");

                    b.Property<int>("DSW_MAH");

                    b.Property<int>("DSW_MASH");

                    b.Property<int>("DSW_MAZ");

                    b.Property<int>("DSW_MM");

                    b.Property<int>("DSW_PRATE");

                    b.Property<int>("DSW_ROOZ");

                    b.Property<string>("DSW_SDATE");

                    b.Property<int>("DSW_TOTL");

                    b.Property<int>("DSW_YY");

                    b.Property<int>("EmployeID");

                    b.Property<int>("KarMonthID");

                    b.HasKey("Id");

                    b.HasIndex("EmployeID");

                    b.HasIndex("KarMonthID");

                    b.ToTable("WorkMonths");
                });

            modelBuilder.Entity("Entities.Tikets.Tiket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCreate");

                    b.Property<DateTime>("DataModified");

                    b.Property<bool>("IsAdminSide");

                    b.Property<short>("Level");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Tikets");
                });

            modelBuilder.Entity("Entities.Tikets.TiketContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCreate");

                    b.Property<DateTime>("DataModified");

                    b.Property<string>("FileURL");

                    b.Property<bool>("IsAdminSide");

                    b.Property<string>("Text");

                    b.Property<int>("TiketId");

                    b.HasKey("Id");

                    b.HasIndex("TiketId");

                    b.ToTable("TiketContents");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(700);

                    b.Property<string>("CodePhone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("LastLoginDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePIC");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.HasOne("Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Entities.Post", b =>
                {
                    b.HasOne("Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.SitePropertys.Post.Comments", b =>
                {
                    b.HasOne("Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.Employees", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("Employees")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Tamin.Jobs", "Jobs")
                        .WithMany("Employees")
                        .HasForeignKey("jobid")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.KarMonth", b =>
                {
                    b.HasOne("Entities.Tamin.Manufacturys", "Manufacturys")
                        .WithMany("KarMonths")
                        .HasForeignKey("ManufacturyID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.ListEmployee", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("ListEmployees")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.Manufacturys", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("Manufacturys")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.PayementHistory", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("payementHistories")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.UserPayement", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("UserPayements")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tamin.WorkMonth", b =>
                {
                    b.HasOne("Entities.Tamin.Employees", "Employees")
                        .WithMany("WorkMonths")
                        .HasForeignKey("EmployeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Tamin.KarMonth", "KarMonth")
                        .WithMany("WorkMonths")
                        .HasForeignKey("KarMonthID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tikets.Tiket", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("Tikets")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Tikets.TiketContent", b =>
                {
                    b.HasOne("Entities.Tikets.Tiket", "Tiket")
                        .WithMany("tiketContents")
                        .HasForeignKey("TiketId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
