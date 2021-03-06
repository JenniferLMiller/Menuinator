﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Menuinator.Data;

namespace Menuinator.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170703215539_Argh")]
    partial class Argh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Menuinator.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Menuinator.Models.DefaultMeal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AltCookingMethodID");

                    b.Property<int>("CookingMethodID");

                    b.Property<int>("CookingTimeID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("PrepTimeID");

                    b.Property<int>("WeatherTypeID");

                    b.HasKey("ID");

                    b.HasIndex("AltCookingMethodID");

                    b.HasIndex("CookingMethodID");

                    b.HasIndex("CookingTimeID");

                    b.HasIndex("PrepTimeID");

                    b.HasIndex("WeatherTypeID");

                    b.ToTable("DefaultMeals");
                });

            modelBuilder.Entity("Menuinator.Models.Meal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AltCookingMethodID");

                    b.Property<int>("CookingMethodID");

                    b.Property<int>("CookingTimeID");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("PrepTimeID");

                    b.Property<string>("UserID");

                    b.Property<int>("WeatherTypeID");

                    b.HasKey("ID");

                    b.HasIndex("AltCookingMethodID");

                    b.HasIndex("CookingMethodID");

                    b.HasIndex("CookingTimeID");

                    b.HasIndex("PrepTimeID");

                    b.HasIndex("WeatherTypeID");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Menuinator.Models.MealMenu", b =>
                {
                    b.Property<int>("MealID");

                    b.Property<int>("MenuID");

                    b.HasKey("MealID", "MenuID");

                    b.HasIndex("MealID");

                    b.HasIndex("MenuID");

                    b.ToTable("MealMenus");
                });

            modelBuilder.Entity("Menuinator.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Menuinator.Models.SupportTables.CookingMethod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("CookingMethods");
                });

            modelBuilder.Entity("Menuinator.Models.SupportTables.CookingTime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("CookingTimes");
                });

            modelBuilder.Entity("Menuinator.Models.SupportTables.PrepTime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("PrepTimes");
                });

            modelBuilder.Entity("Menuinator.Models.SupportTables.WeatherType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("WeatherTypes");
                });

            modelBuilder.Entity("Menuinator.Models.UserMeal", b =>
                {
                    b.Property<int>("MealID");

                    b.Property<int>("AppUserID");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("MealID", "AppUserID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("MealID");

                    b.ToTable("UserMeals");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Menuinator.Models.DefaultMeal", b =>
                {
                    b.HasOne("Menuinator.Models.SupportTables.CookingMethod", "AltCookingMethod")
                        .WithMany()
                        .HasForeignKey("AltCookingMethodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.CookingMethod", "CookingMethod")
                        .WithMany()
                        .HasForeignKey("CookingMethodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.CookingTime", "CookingTime")
                        .WithMany()
                        .HasForeignKey("CookingTimeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.PrepTime", "PrepTime")
                        .WithMany()
                        .HasForeignKey("PrepTimeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.WeatherType", "WeatherType")
                        .WithMany()
                        .HasForeignKey("WeatherTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Menuinator.Models.Meal", b =>
                {
                    b.HasOne("Menuinator.Models.SupportTables.CookingMethod", "AltCookingMethod")
                        .WithMany()
                        .HasForeignKey("AltCookingMethodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.CookingMethod", "CookingMethod")
                        .WithMany()
                        .HasForeignKey("CookingMethodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.CookingTime", "CookingTime")
                        .WithMany()
                        .HasForeignKey("CookingTimeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.PrepTime", "PrepTime")
                        .WithMany()
                        .HasForeignKey("PrepTimeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.SupportTables.WeatherType", "WeatherType")
                        .WithMany()
                        .HasForeignKey("WeatherTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Menuinator.Models.MealMenu", b =>
                {
                    b.HasOne("Menuinator.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Menuinator.Models.UserMeal", b =>
                {
                    b.HasOne("Menuinator.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Menuinator.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Menuinator.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Menuinator.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Menuinator.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
