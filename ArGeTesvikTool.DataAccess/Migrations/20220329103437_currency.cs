using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RdCenterDiscounts_Year",
                table: "RdCenterDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_RdCenterAmounts_Year",
                table: "RdCenterAmounts");

            migrationBuilder.DropColumn(
                name: "CashSupport",
                table: "RdCenterDiscounts");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "RdCenterPersonInfos",
                newName: "CountryText");

            migrationBuilder.RenameColumn(
                name: "TaxFee",
                table: "RdCenterDiscounts",
                newName: "WithholdingIncentive");

            migrationBuilder.RenameColumn(
                name: "PersonelExpense",
                table: "RdCenterDiscounts",
                newName: "StampTaxException");

            migrationBuilder.RenameColumn(
                name: "MaterialExpense",
                table: "RdCenterDiscounts",
                newName: "RatioTurnover");

            migrationBuilder.RenameColumn(
                name: "GeneralExpense",
                table: "RdCenterDiscounts",
                newName: "PremiumSupport");

            migrationBuilder.RenameColumn(
                name: "ExternalBenefit",
                table: "RdCenterDiscounts",
                newName: "IncentiveAmount");

            migrationBuilder.RenameColumn(
                name: "DesignExpense",
                table: "RdCenterDiscounts",
                newName: "CustomTaxException");

            migrationBuilder.RenameColumn(
                name: "DepreciationAmount",
                table: "RdCenterDiscounts",
                newName: "AnnualTotal");

            migrationBuilder.RenameColumn(
                name: "WithholdingIncentive",
                table: "RdCenterAmounts",
                newName: "TaxFee");

            migrationBuilder.RenameColumn(
                name: "StampTaxException",
                table: "RdCenterAmounts",
                newName: "PersonelExpense");

            migrationBuilder.RenameColumn(
                name: "RatioTurnover",
                table: "RdCenterAmounts",
                newName: "MaterialExpense");

            migrationBuilder.RenameColumn(
                name: "PremiumSupport",
                table: "RdCenterAmounts",
                newName: "GeneralExpense");

            migrationBuilder.RenameColumn(
                name: "IncentiveAmount",
                table: "RdCenterAmounts",
                newName: "ExternalBenefit");

            migrationBuilder.RenameColumn(
                name: "CustomTaxException",
                table: "RdCenterAmounts",
                newName: "DesignExpense");

            migrationBuilder.RenameColumn(
                name: "AnnualTotal",
                table: "RdCenterAmounts",
                newName: "DepreciationAmount");

            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "BusinessShareholders",
                newName: "CountryText");

            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "BusinessGroupInfos",
                newName: "CountryText");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "RdCenterPersonInfos",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashSupport",
                table: "RdCenterAmounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "BusinessShareholders",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "BusinessGroupInfos",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "RdCenterPersonInfos");

            migrationBuilder.DropColumn(
                name: "CashSupport",
                table: "RdCenterAmounts");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "BusinessShareholders");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "BusinessGroupInfos");

            migrationBuilder.RenameColumn(
                name: "CountryText",
                table: "RdCenterPersonInfos",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "WithholdingIncentive",
                table: "RdCenterDiscounts",
                newName: "TaxFee");

            migrationBuilder.RenameColumn(
                name: "StampTaxException",
                table: "RdCenterDiscounts",
                newName: "PersonelExpense");

            migrationBuilder.RenameColumn(
                name: "RatioTurnover",
                table: "RdCenterDiscounts",
                newName: "MaterialExpense");

            migrationBuilder.RenameColumn(
                name: "PremiumSupport",
                table: "RdCenterDiscounts",
                newName: "GeneralExpense");

            migrationBuilder.RenameColumn(
                name: "IncentiveAmount",
                table: "RdCenterDiscounts",
                newName: "ExternalBenefit");

            migrationBuilder.RenameColumn(
                name: "CustomTaxException",
                table: "RdCenterDiscounts",
                newName: "DesignExpense");

            migrationBuilder.RenameColumn(
                name: "AnnualTotal",
                table: "RdCenterDiscounts",
                newName: "DepreciationAmount");

            migrationBuilder.RenameColumn(
                name: "TaxFee",
                table: "RdCenterAmounts",
                newName: "WithholdingIncentive");

            migrationBuilder.RenameColumn(
                name: "PersonelExpense",
                table: "RdCenterAmounts",
                newName: "StampTaxException");

            migrationBuilder.RenameColumn(
                name: "MaterialExpense",
                table: "RdCenterAmounts",
                newName: "RatioTurnover");

            migrationBuilder.RenameColumn(
                name: "GeneralExpense",
                table: "RdCenterAmounts",
                newName: "PremiumSupport");

            migrationBuilder.RenameColumn(
                name: "ExternalBenefit",
                table: "RdCenterAmounts",
                newName: "IncentiveAmount");

            migrationBuilder.RenameColumn(
                name: "DesignExpense",
                table: "RdCenterAmounts",
                newName: "CustomTaxException");

            migrationBuilder.RenameColumn(
                name: "DepreciationAmount",
                table: "RdCenterAmounts",
                newName: "AnnualTotal");

            migrationBuilder.RenameColumn(
                name: "CountryText",
                table: "BusinessShareholders",
                newName: "Origin");

            migrationBuilder.RenameColumn(
                name: "CountryText",
                table: "BusinessGroupInfos",
                newName: "Origin");

            migrationBuilder.AddColumn<decimal>(
                name: "CashSupport",
                table: "RdCenterDiscounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterDiscounts_Year",
                table: "RdCenterDiscounts",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterAmounts_Year",
                table: "RdCenterAmounts",
                column: "Year",
                unique: true);
        }
    }
}
