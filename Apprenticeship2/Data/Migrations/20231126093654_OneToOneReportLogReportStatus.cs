using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class OneToOneReportLogReportStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reportLogId",
                table: "ReportStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reportLogs_reportStatusId",
                table: "reportLogs",
                column: "reportStatusId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_reportLogs_ReportStatus_reportStatusId",
                table: "reportLogs",
                column: "reportStatusId",
                principalTable: "ReportStatus",
                principalColumn: "reportStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reportLogs_ReportStatus_reportStatusId",
                table: "reportLogs");

            migrationBuilder.DropIndex(
                name: "IX_reportLogs_reportStatusId",
                table: "reportLogs");

            migrationBuilder.DropColumn(
                name: "reportLogId",
                table: "ReportStatus");
        }
    }
}
