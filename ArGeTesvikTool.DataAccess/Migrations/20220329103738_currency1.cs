using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class currency1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BusinessFinancialInfos_Year",
                table: "BusinessFinancialInfos");

            migrationBuilder.AlterColumn<string>(
                name: "NetSales",
                table: "BusinessFinancialInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetSales",
                table: "BusinessFinancialInfos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFinancialInfos_Year",
                table: "BusinessFinancialInfos",
                column: "Year",
                unique: true);
        }
    }
}
