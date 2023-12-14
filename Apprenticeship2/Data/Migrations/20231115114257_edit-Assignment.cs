﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apprenticeship2.Data.Migrations
{
    public partial class editAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endDate",
                table: "assignments");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "assignments");
        }
    }
}
