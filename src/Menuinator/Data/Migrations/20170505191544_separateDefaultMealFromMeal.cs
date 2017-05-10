using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Menuinator.Data.Migrations
{
    public partial class separateDefaultMealFromMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "DefaultMeals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookingMethodID = table.Column<int>(nullable: true),
                    CookingTimeID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PrepTimeID = table.Column<int>(nullable: true),
                    WeatherTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultMeals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DefaultMeals_CookingMethods_CookingMethodID",
                        column: x => x.CookingMethodID,
                        principalTable: "CookingMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMeals_CookingTimes_CookingTimeID",
                        column: x => x.CookingTimeID,
                        principalTable: "CookingTimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMeals_PrepTimes_PrepTimeID",
                        column: x => x.PrepTimeID,
                        principalTable: "PrepTimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMeals_WeatherTypes_WeatherTypeID",
                        column: x => x.WeatherTypeID,
                        principalTable: "WeatherTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "UserIDId",
                table: "Meals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserIDId",
                table: "Meals",
                column: "UserIDId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMeals_CookingMethodID",
                table: "DefaultMeals",
                column: "CookingMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMeals_CookingTimeID",
                table: "DefaultMeals",
                column: "CookingTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMeals_PrepTimeID",
                table: "DefaultMeals",
                column: "PrepTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMeals_WeatherTypeID",
                table: "DefaultMeals",
                column: "WeatherTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_UserIDId",
                table: "Meals",
                column: "UserIDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "DefaultMeals");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Meals",
                nullable: false,
                defaultValue: "");
        }
    }
}
