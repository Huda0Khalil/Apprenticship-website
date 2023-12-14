using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class seperateReportAssignmentFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileAttatchments");

            migrationBuilder.CreateTable(
                name: "assignmentFiles",
                columns: table => new
                {
                    assignmentFilesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignmentFiles", x => x.assignmentFilesId);
                    table.ForeignKey(
                        name: "FK_assignmentFiles_assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    
                });

            migrationBuilder.CreateTable(
                name: "reportFiles",
                columns: table => new
                {
                    reportFilesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    reportId = table.Column<int>(type: "int", nullable: false),
                    reportLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportFiles", x => x.reportFilesId);
                    table.ForeignKey(
                        name: "FK_reportFiles_reportLogs_reportLogId",
                        column: x => x.reportLogId,
                        principalTable: "reportLogs",
                        principalColumn: "reportLogId");
                    table.ForeignKey(
                        name: "FK_reportFiles_Reports_reportId",
                        column: x => x.reportId,
                        principalTable: "Reports",
                        principalColumn: "reportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignmentFiles_AssignmentId",
                table: "assignmentFiles",
                column: "AssignmentId");

            

            migrationBuilder.CreateIndex(
                name: "IX_reportFiles_reportId",
                table: "reportFiles",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_reportFiles_reportLogId",
                table: "reportFiles",
                column: "reportLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignmentFiles");

            migrationBuilder.DropTable(
                name: "reportFiles");

            migrationBuilder.CreateTable(
                name: "fileAttatchments",
                columns: table => new
                {
                    fileAttatchmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    reportId = table.Column<int>(type: "int", nullable: true),
                    reportLogId = table.Column<int>(type: "int", nullable: true),
                    contentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    isAssignment = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileAttatchments", x => x.fileAttatchmentId);
                    table.ForeignKey(
                        name: "FK_fileAttatchments_assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fileAttatchments_reportLogs_reportLogId",
                        column: x => x.reportLogId,
                        principalTable: "reportLogs",
                        principalColumn: "reportLogId");
                    table.ForeignKey(
                        name: "FK_fileAttatchments_Reports_reportId",
                        column: x => x.reportId,
                        principalTable: "Reports",
                        principalColumn: "reportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fileAttatchments_AssignmentId",
                table: "fileAttatchments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_fileAttatchments_reportId",
                table: "fileAttatchments",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_fileAttatchments_reportLogId",
                table: "fileAttatchments",
                column: "reportLogId");
        }
    }
}
