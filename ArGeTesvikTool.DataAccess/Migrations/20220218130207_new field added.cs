using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class newfieldadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquityAmount",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "InternationalProgName",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "ProgramName",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "SupportAmount",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.AddColumn<string>(
                name: "MentorFirmName",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MentorOutput",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MentorSupport",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendDate",
                table: "RdCenterTechAttendedEvents",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RdCenterPerformanceProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CommercialProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsImportProduct = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPerformanceProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechIntellectualProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProperyType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    InventionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    International = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    DevelopmentPlace = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Statu = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechIntellectualProperties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterPerformanceProjects");

            migrationBuilder.DropTable(
                name: "RdCenterTechIntellectualProperties");

            migrationBuilder.DropColumn(
                name: "MentorFirmName",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "MentorOutput",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.DropColumn(
                name: "MentorSupport",
                table: "RdCenterTechMentorInfos");

            migrationBuilder.AddColumn<decimal>(
                name: "EquityAmount",
                table: "RdCenterTechMentorInfos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InternationalProgName",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramName",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "RdCenterTechMentorInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SupportAmount",
                table: "RdCenterTechMentorInfos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "AttendDate",
                table: "RdCenterTechAttendedEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
