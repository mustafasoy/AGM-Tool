using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class pacstablecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewDatas",
                table: "NewDatas");

            migrationBuilder.RenameTable(
                name: "NewDatas",
                newName: "IndexNewDatas");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "RdCenterInfos",
                newName: "CityText");

            migrationBuilder.RenameIndex(
                name: "IX_NewDatas_Year",
                table: "IndexNewDatas",
                newName: "IX_IndexNewDatas_Year");

            migrationBuilder.AlterColumn<string>(
                name: "FileExtension",
                table: "RdCenterTechProjectManagements",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Collaboration",
                table: "RdCenterTechCollaborations",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationStatu",
                table: "RdCenterPersonInfos",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RdCenterInfos",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "RdCenterInfos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyUnit",
                table: "BusinessPersonnelDistributions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndexNewDatas",
                table: "IndexNewDatas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PersonnelAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonnelNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalId = table.Column<int>(type: "int", nullable: false),
                    TerminalName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelAttendances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelAttendances_EventTime",
                table: "PersonnelAttendances",
                column: "EventTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelAttendances_PersonnelNumber",
                table: "PersonnelAttendances",
                column: "PersonnelNumber",
                unique: true,
                filter: "[PersonnelNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelAttendances_UserId",
                table: "PersonnelAttendances",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndexNewDatas",
                table: "IndexNewDatas");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "RdCenterInfos");

            migrationBuilder.RenameTable(
                name: "IndexNewDatas",
                newName: "NewDatas");

            migrationBuilder.RenameColumn(
                name: "CityText",
                table: "RdCenterInfos",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_IndexNewDatas_Year",
                table: "NewDatas",
                newName: "IX_NewDatas_Year");

            migrationBuilder.AlterColumn<string>(
                name: "FileExtension",
                table: "RdCenterTechProjectManagements",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Collaboration",
                table: "RdCenterTechCollaborations",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "EducationStatu",
                table: "RdCenterPersonInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RdCenterInfos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyUnit",
                table: "BusinessPersonnelDistributions",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewDatas",
                table: "NewDatas",
                column: "Id");
        }
    }
}
