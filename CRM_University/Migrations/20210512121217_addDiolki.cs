using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_University.Migrations
{
    public partial class addDiolki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountStudents",
                columns: table => new
                {
                    DiscountStudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    DiscountDate = table.Column<DateTime>(nullable: false),
                    DiscountName = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountStudents", x => x.DiscountStudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountStudents");
        }
    }
}
