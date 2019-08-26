using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class DeleteCascadeFeatureJunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFeaturesJunction_Features_FeatureId",
                table: "ProjectFeaturesJunction");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFeaturesJunction_Features_FeatureId",
                table: "ProjectFeaturesJunction",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFeaturesJunction_Features_FeatureId",
                table: "ProjectFeaturesJunction");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFeaturesJunction_Features_FeatureId",
                table: "ProjectFeaturesJunction",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
