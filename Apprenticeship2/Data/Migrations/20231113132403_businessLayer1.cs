using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class businessLayer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompletedHours",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "GPA",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UniversitySupervisor_universityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "companyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "universityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "companys",
                columns: table => new
                {
                    companyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companys", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "objectives",
                columns: table => new
                {
                    objectiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectives", x => x.objectiveId);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatus",
                columns: table => new
                {
                    reportStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatus", x => x.reportStatusId);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    supervisorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    teamLeaderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_trainings_AspNetUsers_studentId",
                        column: x => x.studentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trainings_AspNetUsers_supervisorId",
                        column: x => x.supervisorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trainings_AspNetUsers_teamLeaderId",
                        column: x => x.teamLeaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "universities",
                columns: table => new
                {
                    universityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    universityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    universityLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universities", x => x.universityId);
                });

            migrationBuilder.CreateTable(
                name: "objectivesSkills",
                columns: table => new
                {
                    objectiveId = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectivesSkills", x => new { x.skillId, x.objectiveId });
                    table.ForeignKey(
                        name: "FK_objectivesSkills_objectives_objectiveId",
                        column: x => x.objectiveId,
                        principalTable: "objectives",
                        principalColumn: "objectiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objectivesSkills_skills_skillId",
                        column: x => x.skillId,
                        principalTable: "skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignmentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assignmentNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_assignments_trainings_trainingId",
                        column: x => x.trainingId,
                        principalTable: "trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingObjectives",
                columns: table => new
                {
                    trainingId = table.Column<int>(type: "int", nullable: false),
                    objectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingObjectives", x => new { x.objectiveId, x.trainingId });
                    table.ForeignKey(
                        name: "FK_trainingObjectives_objectives_objectiveId",
                        column: x => x.objectiveId,
                        principalTable: "objectives",
                        principalColumn: "objectiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainingObjectives_trainings_trainingId",
                        column: x => x.trainingId,
                        principalTable: "trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assignmentObjectives",
                columns: table => new
                {
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    objectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignmentObjectives", x => new { x.objectiveId, x.assignmentId });
                    table.ForeignKey(
                        name: "FK_assignmentObjectives_assignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignmentObjectives_objectives_objectiveId",
                        column: x => x.objectiveId,
                        principalTable: "objectives",
                        principalColumn: "objectiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reportNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    reportStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_Reports_assignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_ReportStatus_reportStatusId",
                        column: x => x.reportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "reportStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_companyId",
                table: "AspNetUsers",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_universityId",
                table: "AspNetUsers",
                column: "universityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniversitySupervisor_universityId",
                table: "AspNetUsers",
                column: "UniversitySupervisor_universityId");

            migrationBuilder.CreateIndex(
                name: "IX_assignmentObjectives_assignmentId",
                table: "assignmentObjectives",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_trainingId",
                table: "assignments",
                column: "trainingId");

            migrationBuilder.CreateIndex(
                name: "IX_objectivesSkills_objectiveId",
                table: "objectivesSkills",
                column: "objectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_assignmentId",
                table: "Reports",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_reportStatusId",
                table: "Reports",
                column: "reportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingObjectives_trainingId",
                table: "trainingObjectives",
                column: "trainingId");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_studentId",
                table: "trainings",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_supervisorId",
                table: "trainings",
                column: "supervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_teamLeaderId",
                table: "trainings",
                column: "teamLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_companys_companyId",
                table: "AspNetUsers",
                column: "companyId",
                principalTable: "companys",
                principalColumn: "companyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_universities_universityId",
                table: "AspNetUsers",
                column: "universityId",
                principalTable: "universities",
                principalColumn: "universityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_universities_UniversitySupervisor_universityId",
                table: "AspNetUsers",
                column: "UniversitySupervisor_universityId",
                principalTable: "universities",
                principalColumn: "universityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_companys_companyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_universities_universityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_universities_UniversitySupervisor_universityId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "assignmentObjectives");

            migrationBuilder.DropTable(
                name: "companys");

            migrationBuilder.DropTable(
                name: "objectivesSkills");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "trainingObjectives");

            migrationBuilder.DropTable(
                name: "universities");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "assignments");

            migrationBuilder.DropTable(
                name: "ReportStatus");

            migrationBuilder.DropTable(
                name: "objectives");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_companyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_universityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UniversitySupervisor_universityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompletedHours",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ThirdName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniversitySupervisor_universityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "companyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "universityId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
