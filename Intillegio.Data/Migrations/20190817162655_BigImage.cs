using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class BigImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Articles",
                newName: "SmallImage");

            migrationBuilder.AddColumn<string>(
                name: "BigImage",
                table: "Articles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImage",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "SmallImage",
                table: "Articles",
                newName: "ImageLink");
        }
    }
}
