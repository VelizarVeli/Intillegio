using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class DeleteCascadeFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFeaturesJunction_Projects_ProjectId",
                table: "ProjectFeaturesJunction");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFeaturesJunction_Projects_ProjectId",
                table: "ProjectFeaturesJunction",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFeaturesJunction_Projects_ProjectId",
                table: "ProjectFeaturesJunction");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFeaturesJunction_Projects_ProjectId",
                table: "ProjectFeaturesJunction",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
