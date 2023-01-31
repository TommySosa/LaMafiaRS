using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMafiaRS.Migrations
{
    public partial class PruebaModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_User_UserId",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "Imagen1",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "Imagen2",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "Imagen3",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "Imagen4",
                table: "Tweet");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Tweet");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TweetId",
                table: "Tweet",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tweet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_User_UserId",
                table: "Tweet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_User_UserId",
                table: "Tweet");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tweet",
                newName: "TweetId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tweet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Imagen1",
                table: "Tweet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen2",
                table: "Tweet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen3",
                table: "Tweet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen4",
                table: "Tweet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Tweet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_User_UserId",
                table: "Tweet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
