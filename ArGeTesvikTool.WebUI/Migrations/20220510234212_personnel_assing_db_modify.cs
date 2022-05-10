using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.WebUI.Migrations
{
    public partial class personnel_assing_db_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterCalPersonnelInfos");

            migrationBuilder.DropTable(
                name: "RdCenterCalProjectInfos");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "RdCenterCalPersAssings",
                newName: "ProjectName");

            migrationBuilder.AlterColumn<string>(
                name: "AttendDate",
                table: "RdCenterTechAttendedEvents",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RdCenterCalPublicHolidays",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "RdCenterCalPublicHolidays",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "RdCenterCalPersAssings",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "RdCenterCalPersAssings",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "RdCenterCalPersAssings",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "RdCenterCalPersAssings");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "RdCenterCalPersAssings");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "RdCenterCalPersAssings");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "RdCenterCalPersAssings",
                newName: "Mail");

            migrationBuilder.AlterColumn<string>(
                name: "AttendDate",
                table: "RdCenterTechAttendedEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RdCenterCalPublicHolidays",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "RdCenterCalPublicHolidays",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "RdCenterCalPersonnelInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalPersonnelInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterCalProjectInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalProjectInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterCalPersonnelInfos_Email",
                table: "RdCenterCalPersonnelInfos",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterCalProjectInfos_ProjectCode",
                table: "RdCenterCalProjectInfos",
                column: "ProjectCode",
                unique: true,
                filter: "[ProjectCode] IS NOT NULL");
        }
    }
}
