using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Menuinator.Data.Migrations
{
    public partial class initialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookingMethods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingMethods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CookingTimes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTimes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrepTimes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepTimes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WeatherTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookingMethodID = table.Column<int>(nullable: true),
                    CookingTimeID = table.Column<int>(nullable: true),
                    Description = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PrepTimeID = table.Column<int>(nullable: true),
                    WeatherTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meals_CookingMethods_CookingMethodID",
                        column: x => x.CookingMethodID,
                        principalTable: "CookingMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_CookingTimes_CookingTimeID",
                        column: x => x.CookingTimeID,
                        principalTable: "CookingTimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_PrepTimes_PrepTimeID",
                        column: x => x.PrepTimeID,
                        principalTable: "PrepTimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_WeatherTypes_WeatherTypeID",
                        column: x => x.WeatherTypeID,
                        principalTable: "WeatherTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealMenus",
                columns: table => new
                {
                    MealID = table.Column<int>(nullable: false),
                    MenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMenus", x => new { x.MealID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_MealMenus_Meals_MealID",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeals",
                columns: table => new
                {
                    MealID = table.Column<int>(nullable: false),
                    AppUserID = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeals", x => new { x.MealID, x.AppUserID });
                    table.ForeignKey(
                        name: "FK_UserMeals_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMeals_Meals_MealID",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CookingMethodID",
                table: "Meals",
                column: "CookingMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CookingTimeID",
                table: "Meals",
                column: "CookingTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_PrepTimeID",
                table: "Meals",
                column: "PrepTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_WeatherTypeID",
                table: "Meals",
                column: "WeatherTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MealMenus_MealID",
                table: "MealMenus",
                column: "MealID");

            migrationBuilder.CreateIndex(
                name: "IX_MealMenus_MenuID",
                table: "MealMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_ApplicationUserId",
                table: "UserMeals",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_MealID",
                table: "UserMeals",
                column: "MealID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealMenus");

            migrationBuilder.DropTable(
                name: "UserMeals");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "CookingMethods");

            migrationBuilder.DropTable(
                name: "CookingTimes");

            migrationBuilder.DropTable(
                name: "PrepTimes");

            migrationBuilder.DropTable(
                name: "WeatherTypes");
        }
    }
}
