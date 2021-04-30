using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_University.Migrations
{
    public partial class UpdateExamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExaminationDay",
                table: "Examinations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExaminationDay",
                table: "Examinations");
        }
    }
}
