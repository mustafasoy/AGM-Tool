using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class InitialDb : Migration
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
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 11, nullable: false),
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
                name: "BusinessGroupInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Partner = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "date", nullable: false),
                    TradeNumber = table.Column<int>(type: "int", maxLength: 26, nullable: false),
                    ChamberCommerce = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RegistrationNo = table.Column<int>(type: "int", nullable: false),
                    FoundingCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvaibleCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSME = table.Column<int>(type: "int", nullable: false),
                    CRSNumber = table.Column<int>(type: "int", nullable: false),
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
                    CompanyUnit = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                name: "BusinessShareholders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Share = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShareAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "RdCenterContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 11, nullable: false),
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
                name: "RdCenterInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RegistrationNo = table.Column<int>(type: "int", maxLength: 26, nullable: false),
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
                name: "RdCenterPersonInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationStatu = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    GraduateUniversity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UniversityDepartmant = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PersonPosition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RegistrationNo = table.Column<int>(type: "int", maxLength: 26, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterPersonInfos", x => x.Id);
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
                    Text = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AttendedEvent = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AttendDate = table.Column<DateTime>(type: "date", nullable: false),
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
                    Collaboration = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Partner = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "RdCenterTechCompletedProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EquityAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupportAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InternationalProgName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TotalProjectBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechCompletedProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdCenterTechOngoingProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EquityAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupportAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InternationalProgName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TotalProjectBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdCenterTechOngoingProjects", x => x.Id);
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
                name: "IX_BusinessPersonnelDistributions_Year",
                table: "BusinessPersonnelDistributions",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessShareholders_Year",
                table: "BusinessShareholders",
                column: "Year",
                unique: true);

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
                name: "IX_RdCenterPersonInfos_Year",
                table: "RdCenterPersonInfos",
                column: "Year",
                unique: true);

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
                name: "IX_RdCenterTechAttendedEvents_Year",
                table: "RdCenterTechAttendedEvents",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechCollaborations_Year",
                table: "RdCenterTechCollaborations",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechCompletedProjects_Year",
                table: "RdCenterTechCompletedProjects",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechOngoingProjects_Year",
                table: "RdCenterTechOngoingProjects",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RdCenterTechSoftwares_Year",
                table: "RdCenterTechSoftwares",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessContacts");

            migrationBuilder.DropTable(
                name: "BusinessGroupInfos");

            migrationBuilder.DropTable(
                name: "BusinessInfos");

            migrationBuilder.DropTable(
                name: "BusinessIntros");

            migrationBuilder.DropTable(
                name: "BusinessPersonnelDistributions");

            migrationBuilder.DropTable(
                name: "BusinessShareholders");

            migrationBuilder.DropTable(
                name: "RdCenterContacts");

            migrationBuilder.DropTable(
                name: "RdCenterInfos");

            migrationBuilder.DropTable(
                name: "RdCenterPersonInfos");

            migrationBuilder.DropTable(
                name: "RdCenterPersonRewars");

            migrationBuilder.DropTable(
                name: "RdCenterTechAcademicLibraries");

            migrationBuilder.DropTable(
                name: "RdCenterTechAttendedEvents");

            migrationBuilder.DropTable(
                name: "RdCenterTechCollaborations");

            migrationBuilder.DropTable(
                name: "RdCenterTechCompletedProjects");

            migrationBuilder.DropTable(
                name: "RdCenterTechOngoingProjects");

            migrationBuilder.DropTable(
                name: "RdCenterTechSoftwares");
        }
    }
}
