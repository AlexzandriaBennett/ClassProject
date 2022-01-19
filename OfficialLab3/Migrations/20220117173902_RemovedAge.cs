using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficialLab3.Migrations
{
    public partial class RemovedAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
