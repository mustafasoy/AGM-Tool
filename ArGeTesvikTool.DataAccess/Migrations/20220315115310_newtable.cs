using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterTechCompletedProjects");

            migrationBuilder.DropColumn(
                name: "InternationalProgName",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProgramName",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.RenameColumn(
                name: "TotalProjectBudget",
                table: "RdCenterTechOngoingProjects",
                newName: "TotalProjectIncome");

            migrationBuilder.AddColumn<byte[]>(
                name: "DocumentContent",
                table: "RdCenterTechOngoingProjects",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentContentType",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentFileName",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IncomeContent",
                table: "RdCenterTechOngoingProjects",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeContentType",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeFileName",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IntServiceProcurementAmount",
                table: "RdCenterTechOngoingProjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "IntSupportProgram",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NatServiceProcurementAmount",
                table: "RdCenterTechOngoingProjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NatSupportProgram",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderBase",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonNumber",
                table: "RdCenterTechOngoingProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProjectActivity",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProjectContent",
                table: "RdCenterTechOngoingProjects",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectContentType",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectDuration",
                table: "RdCenterTechOngoingProjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectEndDate",
                table: "RdCenterTechOngoingProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectFileName",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectInnovative",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectOutput",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectRequirement",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectStartDate",
                table: "RdCenterTechOngoingProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectSubject",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectSummary",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceProcurement",
                table: "RdCenterTechOngoingProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceProcurementAmount",
                table: "RdCenterTechOngoingProjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ServiceProcurementSubject",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RdCenterContacts",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BusinessInfos",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BusinessContacts",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "NewDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternationalProjectNumber = table.Column<int>(type: "int", nullable: false),
                    NationalProjectNumber = table.Column<int>(type: "int", nullable: false),
                    PeriodicExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublicPeriodicExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectPeriodicExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DomesticSalesRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverseasSalesRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iso14001 = table.Column<bool>(type: "bit", nullable: false),
                    Iso9001 = table.Column<bool>(type: "bit", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterPersonOutsideTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ActivityType = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    MonthlyTimeAway = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPersonOutsideTimes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewDatas_Year",
                table: "NewDatas",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewDatas");

            migrationBuilder.DropTable(
                name: "RdCenterPersonOutsideTimes");

            migrationBuilder.DropColumn(
                name: "DocumentContent",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "DocumentContentType",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "DocumentFileName",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "IncomeContent",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "IncomeContentType",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "IncomeFileName",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "IntServiceProcurementAmount",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "IntSupportProgram",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "NatServiceProcurementAmount",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "NatSupportProgram",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "OrderBase",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "PersonNumber",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectActivity",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectContent",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectContentType",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectDuration",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectEndDate",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectFileName",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectInnovative",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectOutput",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectRequirement",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectStartDate",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectSubject",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ProjectSummary",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ServiceProcurement",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ServiceProcurementAmount",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "ServiceProcurementSubject",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.RenameColumn(
                name: "TotalProjectIncome",
                table: "RdCenterTechOngoingProjects",
                newName: "TotalProjectBudget");

            migrationBuilder.AddColumn<string>(
                name: "InternationalProgName",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramName",
                table: "RdCenterTechOngoingProjects",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RdCenterContacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BusinessInfos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "BusinessContacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
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
                name: "RdCenterTechCompletedProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquityAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternationalProgName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SupportAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalProjectBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechCompletedProjects", x => x.Id);
                });
        }
    }
}
