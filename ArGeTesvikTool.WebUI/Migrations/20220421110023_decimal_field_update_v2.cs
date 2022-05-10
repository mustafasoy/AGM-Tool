using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.WebUI.Migrations
{
    public partial class decimal_field_update_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyTimeAway",
                table: "RdCenterPersonTimeAways",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Share",
                table: "BusinessShareholders",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyTimeAway",
                table: "RdCenterPersonTimeAways",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Share",
                table: "BusinessShareholders",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");
        }
    }
}
