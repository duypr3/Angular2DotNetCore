using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations.Default
{
    public partial class AddPropertyLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Logins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Logins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Logins");
        }
    }
}
