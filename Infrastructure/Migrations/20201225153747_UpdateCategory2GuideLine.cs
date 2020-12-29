using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateCategory2GuideLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Testing");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Testing",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "GuideLine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Testing_categoryId",
                table: "Testing",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GuideLine_categoryId",
                table: "GuideLine",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuideLine_Categories_categoryId",
                table: "GuideLine",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_Categories_categoryId",
                table: "Testing",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuideLine_Categories_categoryId",
                table: "GuideLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Testing_Categories_categoryId",
                table: "Testing");

            migrationBuilder.DropIndex(
                name: "IX_Testing_categoryId",
                table: "Testing");

            migrationBuilder.DropIndex(
                name: "IX_GuideLine_categoryId",
                table: "GuideLine");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Testing");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "GuideLine");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Testing",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
