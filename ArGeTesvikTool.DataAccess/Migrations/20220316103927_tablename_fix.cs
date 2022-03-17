using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class tablename_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RdCenterTechOngoingProjects",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RdCenterPersonOutsideTimes",
                table: "RdCenterPersonOutsideTimes");

            migrationBuilder.RenameTable(
                name: "RdCenterTechOngoingProjects",
                newName: "RdCenterTechProjects");

            migrationBuilder.RenameTable(
                name: "RdCenterPersonOutsideTimes",
                newName: "RdCenterPersonTimeAways");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RdCenterTechProjects",
                table: "RdCenterTechProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RdCenterPersonTimeAways",
                table: "RdCenterPersonTimeAways",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RdCenterTechProjects",
                table: "RdCenterTechProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RdCenterPersonTimeAways",
                table: "RdCenterPersonTimeAways");

            migrationBuilder.RenameTable(
                name: "RdCenterTechProjects",
                newName: "RdCenterTechOngoingProjects");

            migrationBuilder.RenameTable(
                name: "RdCenterPersonTimeAways",
                newName: "RdCenterPersonOutsideTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RdCenterTechOngoingProjects",
                table: "RdCenterTechOngoingProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RdCenterPersonOutsideTimes",
                table: "RdCenterPersonOutsideTimes",
                column: "Id");
        }
    }
}
