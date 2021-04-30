using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_University.Migrations
{
    public partial class AddNotReceived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotReceiveds");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "NotReceiveds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "NotReceiveds");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "NotReceiveds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
