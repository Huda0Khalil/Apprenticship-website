using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class UpdateFileAttachment3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileAttatchmentId",
                table: "assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fileAttatchmentId",
                table: "assignments",
                type: "int",
                nullable: true);
        }
    }
}
