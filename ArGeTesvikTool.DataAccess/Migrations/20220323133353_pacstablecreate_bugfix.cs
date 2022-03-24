using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class pacstablecreate_bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonnelAttendances_EventTime",
                table: "PersonnelAttendances");

            migrationBuilder.DropIndex(
                name: "IX_PersonnelAttendances_PersonnelNumber",
                table: "PersonnelAttendances");

            migrationBuilder.DropIndex(
                name: "IX_PersonnelAttendances_UserId",
                table: "PersonnelAttendances");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonnelAttendances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonnelNumber",
                table: "PersonnelAttendances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonnelAttendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonnelNumber",
                table: "PersonnelAttendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
