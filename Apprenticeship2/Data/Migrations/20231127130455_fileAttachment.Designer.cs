﻿// <auto-generated />
using System;
using Apprenticeship2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231127130455_fileAttachment")]
    partial class fileAttachment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<string>("AssignmentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("assignmentNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("assignmentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("trainingId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("trainingId");

                    b.ToTable("assignments");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.AssignmentObjectives", b =>
                {
                    b.Property<int>("objectiveId")
                        .HasColumnType("int");

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.HasKey("objectiveId", "assignmentId");

                    b.HasIndex("assignmentId");

                    b.ToTable("assignmentObjectives");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("companyId"), 1L, 1);

                    b.Property<string>("companyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("companys");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.fileAttatchment", b =>
                {
                    b.Property<int>("fileAttatchmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fileAttatchmentId"), 1L, 1);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<string>("contentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("file")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportId")
                        .HasColumnType("int");

                    b.HasKey("fileAttatchmentId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("reportId");

                    b.ToTable("fileAttatchments");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Objective", b =>
                {
                    b.Property<int>("objectiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("objectiveId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("objectiveId");

                    b.ToTable("objectives");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.ObjectivesSkills", b =>
                {
                    b.Property<int>("skillId")
                        .HasColumnType("int");

                    b.Property<int>("objectiveId")
                        .HasColumnType("int");

                    b.HasKey("skillId", "objectiveId");

                    b.HasIndex("objectiveId");

                    b.ToTable("objectivesSkills");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Report", b =>
                {
                    b.Property<int>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportId"), 1L, 1);

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<string>("reportDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportStatusId")
                        .HasColumnType("int");

                    b.HasKey("reportId");

                    b.HasIndex("assignmentId");

                    b.HasIndex("reportStatusId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.ReportLog", b =>
                {
                    b.Property<int>("reportLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportLogId"), 1L, 1);

                    b.Property<DateTime>("logDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("reportDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportId")
                        .HasColumnType("int");

                    b.Property<string>("reportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reportNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reportStatusId")
                        .HasColumnType("int");

                    b.HasKey("reportLogId");

                    b.HasIndex("reportId");

                    b.HasIndex("reportStatusId")
                        .IsUnique();

                    b.ToTable("reportLogs");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.ReportStatus", b =>
                {
                    b.Property<int>("reportStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reportStatusId"), 1L, 1);

                    b.Property<string>("statusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reportStatusId");

                    b.ToTable("ReportStatus");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingId"), 1L, 1);

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("studentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("supervisorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("teamLeaderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TrainingId");

                    b.HasIndex("studentId");

                    b.HasIndex("supervisorId");

                    b.HasIndex("teamLeaderId");

                    b.ToTable("trainings");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.TrainingObjectives", b =>
                {
                    b.Property<int>("objectiveId")
                        .HasColumnType("int");

                    b.Property<int>("trainingId")
                        .HasColumnType("int");

                    b.HasKey("objectiveId", "trainingId");

                    b.HasIndex("trainingId");

                    b.ToTable("trainingObjectives");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.University", b =>
                {
                    b.Property<int>("universityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("universityId"), 1L, 1);

                    b.Property<string>("universityLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("universityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("universityId");

                    b.ToTable("universities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Student", b =>
                {
                    b.HasBaseType("Apprenticeship2.Data.Entities.Person");

                    b.Property<int>("CompletedHours")
                        .HasColumnType("int");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("universityId")
                        .HasColumnType("int");

                    b.HasIndex("universityId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.TeamLeader", b =>
                {
                    b.HasBaseType("Apprenticeship2.Data.Entities.Person");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.HasIndex("companyId");

                    b.HasDiscriminator().HasValue("TeamLeader");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.UniversitySupervisor", b =>
                {
                    b.HasBaseType("Apprenticeship2.Data.Entities.Person");

                    b.Property<int>("universityId")
                        .HasColumnType("int")
                        .HasColumnName("UniversitySupervisor_universityId");

                    b.HasIndex("universityId");

                    b.HasDiscriminator().HasValue("UniversitySupervisor");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Assignment", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Training", "training")
                        .WithMany("assignments")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("training");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.AssignmentObjectives", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Assignment", "assignment")
                        .WithMany("assignmentObjectives")
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.Objective", "objective")
                        .WithMany("assignmentObjectives")
                        .HasForeignKey("objectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignment");

                    b.Navigation("objective");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.fileAttatchment", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Assignment", "assignment")
                        .WithMany("fileAttatchments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.Report", "report")
                        .WithMany("fileAttatchments")
                        .HasForeignKey("reportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignment");

                    b.Navigation("report");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.ObjectivesSkills", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Objective", "obj")
                        .WithMany("objectivesskills")
                        .HasForeignKey("objectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.Skill", "skill")
                        .WithMany("objectivesskills")
                        .HasForeignKey("skillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("obj");

                    b.Navigation("skill");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Report", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Assignment", "assignment")
                        .WithMany("reports")
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.ReportStatus", "reportStatus")
                        .WithMany("reports")
                        .HasForeignKey("reportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignment");

                    b.Navigation("reportStatus");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.ReportLog", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Report", "report")
                        .WithMany()
                        .HasForeignKey("reportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.ReportStatus", "reportStatus")
                        .WithOne("reportLog")
                        .HasForeignKey("Apprenticeship2.Data.Entities.ReportLog", "reportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("report");

                    b.Navigation("reportStatus");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Training", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.UniversitySupervisor", "supervisor")
                        .WithMany("trainings")
                        .HasForeignKey("supervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.TeamLeader", "teamLeader")
                        .WithMany("training")
                        .HasForeignKey("teamLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("supervisor");

                    b.Navigation("teamLeader");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.TrainingObjectives", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Objective", "objective")
                        .WithMany("trainingObjectsives")
                        .HasForeignKey("objectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.Training", "training")
                        .WithMany("trainingObjectives")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("objective");

                    b.Navigation("training");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apprenticeship2.Data.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Student", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.University", "University")
                        .WithMany("students")
                        .HasForeignKey("universityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.TeamLeader", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.Company", "Company")
                        .WithMany("teamLeaders")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.UniversitySupervisor", b =>
                {
                    b.HasOne("Apprenticeship2.Data.Entities.University", "university")
                        .WithMany("universitySupervisors")
                        .HasForeignKey("universityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("university");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Assignment", b =>
                {
                    b.Navigation("assignmentObjectives");

                    b.Navigation("fileAttatchments");

                    b.Navigation("reports");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Company", b =>
                {
                    b.Navigation("teamLeaders");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Objective", b =>
                {
                    b.Navigation("assignmentObjectives");

                    b.Navigation("objectivesskills");

                    b.Navigation("trainingObjectsives");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Report", b =>
                {
                    b.Navigation("fileAttatchments");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.ReportStatus", b =>
                {
                    b.Navigation("reportLog")
                        .IsRequired();

                    b.Navigation("reports");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Skill", b =>
                {
                    b.Navigation("objectivesskills");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.Training", b =>
                {
                    b.Navigation("assignments");

                    b.Navigation("trainingObjectives");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.University", b =>
                {
                    b.Navigation("students");

                    b.Navigation("universitySupervisors");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.TeamLeader", b =>
                {
                    b.Navigation("training");
                });

            modelBuilder.Entity("Apprenticeship2.Data.Entities.UniversitySupervisor", b =>
                {
                    b.Navigation("trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
