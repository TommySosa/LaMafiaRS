using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMafiaRS.Migrations
{
    public partial class UsernameTweet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Tweet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Tweet");
        }
    }
}
