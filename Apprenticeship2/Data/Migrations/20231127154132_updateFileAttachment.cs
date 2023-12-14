using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class updateFileAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_assignments_AssignmentId",
                table: "fileAttatchments");

            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_Reports_reportId",
                table: "fileAttatchments");

            migrationBuilder.AlterColumn<int>(
                name: "reportId",
                table: "fileAttatchments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "fileAttatchments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_fileAttatchments_assignments_AssignmentId",
                table: "fileAttatchments",
                column: "AssignmentId",
                principalTable: "assignments",
                principalColumn: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_fileAttatchments_Reports_reportId",
                table: "fileAttatchments",
                column: "reportId",
                principalTable: "Reports",
                principalColumn: "reportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_assignments_AssignmentId",
                table: "fileAttatchments");

            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_Reports_reportId",
                table: "fileAttatchments");

            migrationBuilder.AlterColumn<int>(
                name: "reportId",
                table: "fileAttatchments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "fileAttatchments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fileAttatchments_assignments_AssignmentId",
                table: "fileAttatchments",
                column: "AssignmentId",
                principalTable: "assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fileAttatchments_Reports_reportId",
                table: "fileAttatchments",
                column: "reportId",
                principalTable: "Reports",
                principalColumn: "reportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
