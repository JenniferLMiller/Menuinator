using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menuinator.Data.Migrations
{
    public partial class changeUserIDTypeInMealTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_UserIDId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_UserIDId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "UserIDId",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Meals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "UserIDId",
                table: "Meals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserIDId",
                table: "Meals",
                column: "UserIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_UserIDId",
                table: "Meals",
                column: "UserIDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
