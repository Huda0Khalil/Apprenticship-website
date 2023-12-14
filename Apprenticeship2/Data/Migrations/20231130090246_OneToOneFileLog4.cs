using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class OneToOneFileLog4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileAttatchmentId",
                table: "reportLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fileAttatchmentId",
                table: "reportLogs",
                type: "int",
                nullable: true);
        }
    }
}
