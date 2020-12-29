using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class updateGuideline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Testing",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "GuideLine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Testing");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "GuideLine");
        }
    }
}
