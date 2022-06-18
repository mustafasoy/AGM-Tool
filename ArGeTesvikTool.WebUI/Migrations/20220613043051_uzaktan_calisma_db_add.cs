using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.WebUI.Migrations
{
    public partial class uzaktan_calisma_db_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RdCenterPerformanceDecisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityYearText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionMeetText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPerformanceDecisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeleworkingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PersonnelFullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ProjectTimeSpend = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    OutsideTimeSpend = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TeleworkingTimeSpend = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    EditedTeleworkingTimeSpend = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeleworkingReports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterPerformanceDecisions_Year",
                table: "RdCenterPerformanceDecisions",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterPerformanceDecisions");

            migrationBuilder.DropTable(
                name: "TeleworkingReports");
        }
    }
}
