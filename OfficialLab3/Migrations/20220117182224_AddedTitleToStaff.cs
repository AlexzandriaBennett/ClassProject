using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficialLab3.Migrations
{
    public partial class AddedTitleToStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Staff");
        }
    }
}
