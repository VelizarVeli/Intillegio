using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image320X405",
                table: "Events",
                newName: "Image540X360");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Events",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image225X285",
                table: "Events",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Image225X285",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Image540X360",
                table: "Events",
                newName: "Image320X405");
        }
    }
}
