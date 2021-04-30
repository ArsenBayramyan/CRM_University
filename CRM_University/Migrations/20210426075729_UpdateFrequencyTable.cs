using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_University.Migrations
{
    public partial class UpdateFrequencyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Absecnes",
                table: "Frequencies");

            migrationBuilder.AddColumn<byte>(
                name: "Absences",
                table: "Frequencies",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Absences",
                table: "Frequencies");

            migrationBuilder.AddColumn<byte>(
                name: "Absecnes",
                table: "Frequencies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
