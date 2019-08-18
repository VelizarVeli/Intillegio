using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class ArticleImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SmallImage",
                table: "Articles",
                newName: "Image825X530");

            migrationBuilder.RenameColumn(
                name: "BigImage",
                table: "Articles",
                newName: "Image65X65");

            migrationBuilder.AddColumn<string>(
                name: "Image350X350",
                table: "Articles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image390X245",
                table: "Articles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoImage400X250",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image350X350",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Image390X245",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "VideoImage400X250",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Image825X530",
                table: "Articles",
                newName: "SmallImage");

            migrationBuilder.RenameColumn(
                name: "Image65X65",
                table: "Articles",
                newName: "BigImage");
        }
    }
}
