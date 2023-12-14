using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class OneToOneFileLog2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fileAttatchmentId",
                table: "reportLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "fileAttatchments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "reportLogId",
                table: "fileAttatchments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fileAttatchments_reportLogId",
                table: "fileAttatchments",
                column: "reportLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_fileAttatchments_reportLogs_reportLogId",
                table: "fileAttatchments",
                column: "reportLogId",
                principalTable: "reportLogs",
                principalColumn: "reportLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_reportLogs_reportLogId",
                table: "fileAttatchments");

            migrationBuilder.DropIndex(
                name: "IX_fileAttatchments_reportLogId",
                table: "fileAttatchments");

            migrationBuilder.DropColumn(
                name: "fileAttatchmentId",
                table: "reportLogs");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "fileAttatchments");

            migrationBuilder.DropColumn(
                name: "reportLogId",
                table: "fileAttatchments");
        }
    }
}
