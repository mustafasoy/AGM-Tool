using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.WebUI.Migrations
{
    public partial class decimal_field_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterCalManagerEntries");

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyTimeAway",
                table: "RdCenterPersonTimeAways",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,1)");

            migrationBuilder.CreateTable(
                name: "IncomeReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PersonnelFullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    WorkType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RdCenterTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    RemoteTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ProjectTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    UncentiveTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    NonRdCenterTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    NonRdCenterOtherTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    AnnualLeaveTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    BaseUsedDay = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialSecurityReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PersonnelFullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    WorkType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    PreMonthTransfer = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    IncentiveWorkingHour = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PreMonthAnnuelLeaveHour = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    AnnuelLeaveWorkingHour = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    WeekendWorkingHour = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PublicHolidayWorkingHour = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    SsiWorkingHour = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialSecurityReports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterPersonInfos_RegistrationNo",
                table: "RdCenterPersonInfos",
                column: "RegistrationNo",
                unique: true,
                filter: "[RegistrationNo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeReports");

            migrationBuilder.DropTable(
                name: "SocialSecurityReports");

            migrationBuilder.DropIndex(
                name: "IX_RdCenterPersonInfos_RegistrationNo",
                table: "RdCenterPersonInfos");

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyTimeAway",
                table: "RdCenterPersonTimeAways",
                type: "decimal(3,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.CreateTable(
                name: "RdCenterCalManagerEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateTime = table.Column<DateTime>(type: "date", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Time = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TimeAwayCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalManagerEntries", x => x.Id);
                });
        }
    }
}
