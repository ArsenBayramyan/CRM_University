using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_University.Migrations
{
    public partial class addDi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountStudents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountStudents",
                columns: table => new
                {
                    DiscountStudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountStudents", x => x.DiscountStudentId);
                });
        }
    }
}
