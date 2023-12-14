using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class ReportFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileAttatchmentId",
                table: "Reports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fileAttatchmentId",
                table: "Reports",
                type: "int",
                nullable: true);
        }
    }
}
