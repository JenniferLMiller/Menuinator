using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menuinator.Data.Migrations
{
    public partial class addAltCookMethodID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AltCookingMethodID",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AltCookingMethodID",
                table: "DefaultMeals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_AltCookingMethodID",
                table: "Meals",
                column: "AltCookingMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMeals_AltCookingMethodID",
                table: "DefaultMeals",
                column: "AltCookingMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultMeals_CookingMethods_AltCookingMethodID",
                table: "DefaultMeals",
                column: "AltCookingMethodID",
                principalTable: "CookingMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_CookingMethods_AltCookingMethodID",
                table: "Meals",
                column: "AltCookingMethodID",
                principalTable: "CookingMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultMeals_CookingMethods_AltCookingMethodID",
                table: "DefaultMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_CookingMethods_AltCookingMethodID",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_AltCookingMethodID",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_DefaultMeals_AltCookingMethodID",
                table: "DefaultMeals");

            migrationBuilder.DropColumn(
                name: "AltCookingMethodID",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "AltCookingMethodID",
                table: "DefaultMeals");
        }
    }
}
