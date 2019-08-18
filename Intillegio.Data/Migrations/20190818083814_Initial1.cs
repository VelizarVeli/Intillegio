using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_EventId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Solutions",
                newName: "Image825X445");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Reviews",
                newName: "Image75X75");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Projects",
                newName: "Image360X240");

            migrationBuilder.RenameColumn(
                name: "PictureLink",
                table: "Products",
                newName: "Image95X125");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Partners",
                newName: "Logo155X75");

            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "Events",
                newName: "Image320X405");

            migrationBuilder.AddColumn<string>(
                name: "Image255X155",
                table: "Solutions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image65X65",
                table: "Solutions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image1110X450",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image350X350",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image135X135",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image255X325",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image540X540",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EventImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventImage_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventImage_EventId",
                table: "EventImage",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventImage");

            migrationBuilder.DropColumn(
                name: "Image255X155",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "Image65X65",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "Image1110X450",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Image350X350",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Image135X135",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image255X325",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image540X540",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Image825X445",
                table: "Solutions",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image75X75",
                table: "Reviews",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "Image360X240",
                table: "Projects",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image95X125",
                table: "Products",
                newName: "PictureLink");

            migrationBuilder.RenameColumn(
                name: "Logo155X75",
                table: "Partners",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "Image320X405",
                table: "Events",
                newName: "MainImage");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventId",
                table: "Images",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
