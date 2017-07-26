using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menuinator.Data.Migrations
{
    public partial class newMenuFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeatherTypeID",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mealCount",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_WeatherTypeID",
                table: "Menus",
                column: "WeatherTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_WeatherTypes_WeatherTypeID",
                table: "Menus",
                column: "WeatherTypeID",
                principalTable: "WeatherTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_WeatherTypes_WeatherTypeID",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_WeatherTypeID",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "WeatherTypeID",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "mealCount",
                table: "Menus");
        }
    }
}
