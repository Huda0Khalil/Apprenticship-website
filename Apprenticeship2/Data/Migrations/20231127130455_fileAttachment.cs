using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class fileAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fileAttatchments",
                columns: table => new
                {
                    fileAttatchmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: true),
                    reportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileAttatchments", x => x.fileAttatchmentId);
                    table.ForeignKey(
                        name: "FK_fileAttatchments_assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fileAttatchments_Reports_reportId",
                        column: x => x.reportId,
                        principalTable: "Reports",
                        principalColumn: "reportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fileAttatchments_AssignmentId",
                table: "fileAttatchments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_fileAttatchments_reportId",
                table: "fileAttatchments",
                column: "reportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileAttatchments");
        }
    }
}
