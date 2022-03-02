using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class NewFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RdCenterTechCompletedProjects");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "RdCenterTechCompletedProjects");

            migrationBuilder.DropColumn(
                name: "ModifedUserName",
                table: "RdCenterTechCompletedProjects");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RdCenterTechCompletedProjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RdCenterTechProjectManagements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ModifedUserName",
                table: "RdCenterTechProjectManagements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectStatu",
                table: "RdCenterTechOngoingProjects",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RdCenterSchemas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ModifedUserName",
                table: "RdCenterSchemas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonPosition",
                table: "RdCenterPersonInfos",
                type: "int",
                maxLength: 256,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DocReceiptDate",
                table: "RdCenterInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "BusinessSchemas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ModifedUserName",
                table: "BusinessSchemas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RdCenterAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxExemption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WithholdingIncentive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumSupport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StampTaxException = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomTaxException = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncentiveAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RatioTurnover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterAmounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepreciationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonelExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExternalBenefit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DesignExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashSupport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxExemption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterPhysicalAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPhysicalAreas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterAmounts_Year",
                table: "RdCenterAmounts",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterDiscounts_Year",
                table: "RdCenterDiscounts",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RdCenterAmounts");

            migrationBuilder.DropTable(
                name: "RdCenterDiscounts");

            migrationBuilder.DropTable(
                name: "RdCenterPhysicalAreas");

            migrationBuilder.DropColumn(
                name: "ProjectStatu",
                table: "RdCenterTechOngoingProjects");

            migrationBuilder.DropColumn(
                name: "DocReceiptDate",
                table: "RdCenterInfos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RdCenterTechProjectManagements",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifedUserName",
                table: "RdCenterTechProjectManagements",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RdCenterTechCompletedProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "RdCenterTechCompletedProjects",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifedUserName",
                table: "RdCenterTechCompletedProjects",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RdCenterTechCompletedProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RdCenterSchemas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifedUserName",
                table: "RdCenterSchemas",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonPosition",
                table: "RdCenterPersonInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "BusinessSchemas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifedUserName",
                table: "BusinessSchemas",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
