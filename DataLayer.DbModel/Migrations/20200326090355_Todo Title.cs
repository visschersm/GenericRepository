using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.DbModel.Migrations
{
    public partial class TodoTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TodoItems",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TodoItems");
        }
    }
}
