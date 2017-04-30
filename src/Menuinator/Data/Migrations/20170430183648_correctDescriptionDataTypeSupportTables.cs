using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Menuinator.Data.Migrations
{
    public partial class correctDescriptionDataTypeSupportTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WeatherTypes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PrepTimes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Meals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CookingTimes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CookingMethods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "WeatherTypes",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "PrepTimes",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "Meals",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "CookingTimes",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "CookingMethods",
                nullable: false);
        }
    }
}
