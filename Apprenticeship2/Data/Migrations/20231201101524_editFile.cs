using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class editFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_assignments_AssignmentId",
                table: "fileAttatchments");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileAttatchments_assignments_AssignmentId",
                table: "fileAttatchments");

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
        }
    }
}
