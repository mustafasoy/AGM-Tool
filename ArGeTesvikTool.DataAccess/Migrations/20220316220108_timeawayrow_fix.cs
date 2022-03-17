using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArGeTesvikTool.DataAccess.Migrations
{
    public partial class timeawayrow_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "RdCenterPersonTimeAways");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "RdCenterPersonTimeAways");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "RdCenterPersonTimeAways");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "RdCenterPersonTimeAways",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "RdCenterPersonTimeAways",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "RdCenterPersonTimeAways",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
