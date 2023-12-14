using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class editReport1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignmentFiles_reportLogs_reportLogId",
                table: "assignmentFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_assignmentFiles_Reports_reportId",
                table: "assignmentFiles");

            migrationBuilder.DropIndex(
                name: "IX_assignmentFiles_reportId",
                table: "assignmentFiles");

            migrationBuilder.DropIndex(
                name: "IX_assignmentFiles_reportLogId",
                table: "assignmentFiles");

            migrationBuilder.DropColumn(
                name: "reportId",
                table: "assignmentFiles");

            migrationBuilder.DropColumn(
                name: "reportLogId",
                table: "assignmentFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reportId",
                table: "assignmentFiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "reportLogId",
                table: "assignmentFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignmentFiles_reportId",
                table: "assignmentFiles",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_assignmentFiles_reportLogId",
                table: "assignmentFiles",
                column: "reportLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentFiles_reportLogs_reportLogId",
                table: "assignmentFiles",
                column: "reportLogId",
                principalTable: "reportLogs",
                principalColumn: "reportLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentFiles_Reports_reportId",
                table: "assignmentFiles",
                column: "reportId",
                principalTable: "Reports",
                principalColumn: "reportId");
        }
    }
}
