using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.WebUI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessFinancialInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetSales = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TotalAsset = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortTermLoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LongTermLoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DomesticSales = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ExportSales = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GrossSales = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RDExpenditure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AcquisitionTurnover = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessFinancialInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessGroupInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CountryText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FoundingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessGroupInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ActivityCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CityText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Partner = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "date", nullable: false),
                    TradeNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    ChamberCommerce = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    FoundingCapital = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AvaibleCapital = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsSME = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CRSNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessIntros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessIntros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPersonnelDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PostDoctoral = table.Column<int>(type: "int", nullable: false),
                    Doctoral = table.Column<int>(type: "int", nullable: false),
                    MasterDegree = table.Column<int>(type: "int", nullable: false),
                    BachelorDegree = table.Column<int>(type: "int", nullable: false),
                    AssociateDegree = table.Column<int>(type: "int", nullable: false),
                    HighSchool = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPersonnelDistributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessShareholders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CountryText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Share = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ShareAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessShareholders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessStrategies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PersonnelFullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    WorkType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RdCenterTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    RemoteTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ProjectTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    UncentiveTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    NonRdCenterTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    NonRdCenterOtherTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    AnnualLeaveTimeSpend = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    BaseUsedDay = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndexNewDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternationalProjectNumber = table.Column<int>(type: "int", nullable: false),
                    NationalProjectNumber = table.Column<int>(type: "int", nullable: false),
                    PeriodicExpenditure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PublicPeriodicExpenditure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectPeriodicExpenditure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DomesticSalesRevenue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OverseasSalesRevenue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_IndexNewDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialExpense = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepreciationAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonelExpense = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GeneralExpense = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ExternalBenefit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaxFee = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DesignExpense = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CashSupport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TotalExpenditure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaxExemption = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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
                name: "RdCenterAreaInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterAreaInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterCalPersAssings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalPersAssings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterCalPersAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PersonnelNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    TerminalId = table.Column<int>(type: "int", nullable: false),
                    TerminalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalPersAttendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterCalPublicHolidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsHalfDay = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalPublicHolidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterCalTimeAways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeAwayCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TimeAwayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalTimeAways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxExemption = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WithholdingIncentive = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PremiumSupport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StampTaxException = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CustomTaxException = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IncentiveAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TotalExpenditure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AnnualTotal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RatioTurnover = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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
                name: "RdCenterInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocReceiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CityText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    OfficeArea = table.Column<int>(type: "int", nullable: false),
                    OtherArea = table.Column<int>(type: "int", nullable: false),
                    TotalArea = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterPerformanceProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CommercialProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsImportProduct = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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
                name: "RdCenterPersonRewars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPersonRewars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterPersonTimeAways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ActivityType = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    MonthlyTimeAway = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPersonTimeAways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterPhysicalAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "RdCenterSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechAcademicLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechAcademicLibraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechAttendedEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AttendedEvent = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AttendDate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PersonNumber = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechAttendedEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechCollaborations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Collaboration = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CountryText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CollaborationType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechCollaborations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechIntellectualProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProperyType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InventionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    International = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DevelopmentPlace = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Statu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RdCenterTechMentorInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorFirmName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MentorSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentorOutput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechMentorInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechProjectManagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechProjectManagements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectStatu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    PersonNumber = table.Column<int>(type: "int", nullable: false),
                    ProjectDuration = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ProjectFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProjectContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatSupportProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntSupportProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalProjectIncome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EquityAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SupportAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProcurementSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProcurement = table.Column<int>(type: "int", nullable: false),
                    ServiceProcurementAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NatServiceProcurementAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IntServiceProcurementAmount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IncomeFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IncomeContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectInnovative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectOutput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DocumentContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechSoftwares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CopyNumber = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechSoftwares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialSecurityReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PersonnelFullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    WorkType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    PreMonthTransfer = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IncentiveWorkingHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PreMonthAnnuelLeaveHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    AnnuelLeaveWorkingHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    WeekendWorkingHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PublicHolidayWorkingHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    SsiWorkingHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialSecurityReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterCalPersonnelEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PersonnelFullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    WorkType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TimeAwayCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TimeAwayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterCalPersonnelEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RdCenterCalPersonnelEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterPersonInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CountryText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationStatu = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GraduateUniversity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UniversityDepartmant = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MasterUniversity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MasterDepartmant = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DoctoralUniversity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DoctoralDepartmant = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PersonPosition = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WorkType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegistrationNo = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPersonInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RdCenterPersonInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_Year",
                table: "BusinessContacts",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessGroupInfos_Year",
                table: "BusinessGroupInfos",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessInfos_Year",
                table: "BusinessInfos",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessIntros_Year",
                table: "BusinessIntros",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessStrategies_Year",
                table: "BusinessStrategies",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_Year",
                table: "FiscalYears",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndexNewDatas_Year",
                table: "IndexNewDatas",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterCalPersonnelEntries_UserId",
                table: "RdCenterCalPersonnelEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterCalTimeAways_TimeAwayCode",
                table: "RdCenterCalTimeAways",
                column: "TimeAwayCode",
                unique: true,
                filter: "[TimeAwayCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterContacts_Year",
                table: "RdCenterContacts",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterInfos_Year",
                table: "RdCenterInfos",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterPersonInfos_RegistrationNo",
                table: "RdCenterPersonInfos",
                column: "RegistrationNo",
                unique: true,
                filter: "[RegistrationNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterPersonInfos_UserId",
                table: "RdCenterPersonInfos",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterPersonRewars_Year",
                table: "RdCenterPersonRewars",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechAcademicLibraries_Year",
                table: "RdCenterTechAcademicLibraries",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechSoftwares_Year",
                table: "RdCenterTechSoftwares",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessContacts");

            migrationBuilder.DropTable(
                name: "BusinessFinancialInfos");

            migrationBuilder.DropTable(
                name: "BusinessGroupInfos");

            migrationBuilder.DropTable(
                name: "BusinessInfos");

            migrationBuilder.DropTable(
                name: "BusinessIntros");

            migrationBuilder.DropTable(
                name: "BusinessPersonnelDistributions");

            migrationBuilder.DropTable(
                name: "BusinessSchemas");

            migrationBuilder.DropTable(
                name: "BusinessShareholders");

            migrationBuilder.DropTable(
                name: "BusinessStrategies");

            migrationBuilder.DropTable(
                name: "FiscalYears");

            migrationBuilder.DropTable(
                name: "IncomeReports");

            migrationBuilder.DropTable(
                name: "IndexNewDatas");

            migrationBuilder.DropTable(
                name: "RdCenterAmounts");

            migrationBuilder.DropTable(
                name: "RdCenterAreaInfos");

            migrationBuilder.DropTable(
                name: "RdCenterCalPersAssings");

            migrationBuilder.DropTable(
                name: "RdCenterCalPersAttendances");

            migrationBuilder.DropTable(
                name: "RdCenterCalPersonnelEntries");

            migrationBuilder.DropTable(
                name: "RdCenterCalPublicHolidays");

            migrationBuilder.DropTable(
                name: "RdCenterCalTimeAways");

            migrationBuilder.DropTable(
                name: "RdCenterContacts");

            migrationBuilder.DropTable(
                name: "RdCenterDiscounts");

            migrationBuilder.DropTable(
                name: "RdCenterInfos");

            migrationBuilder.DropTable(
                name: "RdCenterPerformanceProjects");

            migrationBuilder.DropTable(
                name: "RdCenterPersonInfos");

            migrationBuilder.DropTable(
                name: "RdCenterPersonRewars");

            migrationBuilder.DropTable(
                name: "RdCenterPersonTimeAways");

            migrationBuilder.DropTable(
                name: "RdCenterPhysicalAreas");

            migrationBuilder.DropTable(
                name: "RdCenterSchemas");

            migrationBuilder.DropTable(
                name: "RdCenterTechAcademicLibraries");

            migrationBuilder.DropTable(
                name: "RdCenterTechAttendedEvents");

            migrationBuilder.DropTable(
                name: "RdCenterTechCollaborations");

            migrationBuilder.DropTable(
                name: "RdCenterTechIntellectualProperties");

            migrationBuilder.DropTable(
                name: "RdCenterTechMentorInfos");

            migrationBuilder.DropTable(
                name: "RdCenterTechProjectManagements");

            migrationBuilder.DropTable(
                name: "RdCenterTechProjects");

            migrationBuilder.DropTable(
                name: "RdCenterTechSoftwares");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SocialSecurityReports");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
