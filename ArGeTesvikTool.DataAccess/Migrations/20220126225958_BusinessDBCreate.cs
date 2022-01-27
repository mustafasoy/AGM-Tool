using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class BusinessDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActivityCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Partner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TradeNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    ChamberCommerce = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationNo = table.Column<int>(type: "int", nullable: false),
                    FoundingCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvaibleCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSME = table.Column<int>(type: "int", nullable: false),
                    CRSNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessIntros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessIntros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDoctoral = table.Column<int>(type: "int", nullable: false),
                    Doctoral = table.Column<int>(type: "int", nullable: false),
                    MasterDegree = table.Column<int>(type: "int", nullable: false),
                    BachelorDegree = table.Column<int>(type: "int", nullable: false),
                    AssociateDegree = table.Column<int>(type: "int", nullable: false),
                    HighSchool = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelDistributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shareholders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Share = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShareAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shareholders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessInfos_Year",
                table: "BusinessInfos",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessInfos");

            migrationBuilder.DropTable(
                name: "BusinessIntros");

            migrationBuilder.DropTable(
                name: "GroupInfos");

            migrationBuilder.DropTable(
                name: "PersonnelDistributions");

            migrationBuilder.DropTable(
                name: "Shareholders");
        }
    }
}
