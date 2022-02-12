using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class FileUploadDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RdCenterTechCollaborations_Year",
                table: "RdCenterTechCollaborations");

            migrationBuilder.DropIndex(
                name: "IX_RdCenterTechAttendedEvents_Year",
                table: "RdCenterTechAttendedEvents");

            migrationBuilder.DropIndex(
                name: "IX_RdCenterPersonInfos_Year",
                table: "RdCenterPersonInfos");

            migrationBuilder.DropIndex(
                name: "IX_BusinessShareholders_Year",
                table: "BusinessShareholders");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPersonnelDistributions_Year",
                table: "BusinessPersonnelDistributions");

            migrationBuilder.DropColumn(
                name: "City",
                table: "BusinessInfos");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "RdCenterTechCollaborations",
                newName: "CountryText");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "RdCenterTechCollaborations",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Text",
                table: "RdCenterTechAttendedEvents",
                type: "int",
                maxLength: 256,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "RdCenterTechAttendedEvents",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttendDate",
                table: "RdCenterTechAttendedEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "RdCenterInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameSurname",
                table: "RdCenterContacts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "RdCenterContacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNo",
                table: "BusinessInfos",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "BusinessInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRSNumber",
                table: "BusinessInfos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityCode",
                table: "BusinessInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "BusinessInfos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityText",
                table: "BusinessInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "BusinessGroupInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameSurname",
                table: "BusinessContacts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "BusinessContacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchemaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSchemas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessSchemas");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "RdCenterTechCollaborations");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "BusinessInfos");

            migrationBuilder.DropColumn(
                name: "CityText",
                table: "BusinessInfos");

            migrationBuilder.RenameColumn(
                name: "CountryText",
                table: "RdCenterTechCollaborations",
                newName: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "RdCenterTechAttendedEvents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "RdCenterTechAttendedEvents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendDate",
                table: "RdCenterTechAttendedEvents",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "RdCenterInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "NameSurname",
                table: "RdCenterContacts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "RdCenterContacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNo",
                table: "BusinessInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(26)",
                oldMaxLength: 26,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "BusinessInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "CRSNumber",
                table: "BusinessInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityCode",
                table: "BusinessInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BusinessInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "BusinessGroupInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "NameSurname",
                table: "BusinessContacts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "BusinessContacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechCollaborations_Year",
                table: "RdCenterTechCollaborations",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechAttendedEvents_Year",
                table: "RdCenterTechAttendedEvents",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterPersonInfos_Year",
                table: "RdCenterPersonInfos",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessShareholders_Year",
                table: "BusinessShareholders",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPersonnelDistributions_Year",
                table: "BusinessPersonnelDistributions",
                column: "Year",
                unique: true);
        }
    }
}
