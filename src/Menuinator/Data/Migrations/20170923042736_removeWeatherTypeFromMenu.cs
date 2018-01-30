using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menuinator.Data.Migrations
{
    public partial class removeWeatherTypeFromMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_WeatherTypes_WeatherTypeID",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_WeatherTypeID",
                table: "Menus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
