using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.WebUI.Migrations
{
    public partial class update_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterFinancialInfos");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "Users",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyTimeAway",
                table: "RdCenterPersonTimeAways",
                type: "decimal(3,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                table: "RdCenterPersonInfos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "RdCenterPerformanceProjects",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Share",
                table: "BusinessShareholders",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "RdCenterPersonInfos");

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyTimeAway",
                table: "RdCenterPersonTimeAways",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,1)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RdCenterPerformanceProjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Share",
                table: "BusinessShareholders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.CreateTable(
                name: "RdCenterFinancialInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcquisitionTurnover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DomesticSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExportSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LongTermLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    NetSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RDExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SortTermLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAsset = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterFinancialInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterFinancialInfos_Year",
                table: "RdCenterFinancialInfos",
                column: "Year",
                unique: true);
        }
    }
}
