using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class _350X220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image350X350",
                table: "Articles",
                newName: "Image350X220");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image350X220",
                table: "Articles",
                newName: "Image350X350");
        }
    }
}
