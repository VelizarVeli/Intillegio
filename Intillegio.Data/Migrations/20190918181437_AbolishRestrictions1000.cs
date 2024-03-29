﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Intillegio.Data.Migrations
{
    public partial class AbolishRestrictions1000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "TeamMembers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Solutions",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "TeamMembers",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Solutions",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Events",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
