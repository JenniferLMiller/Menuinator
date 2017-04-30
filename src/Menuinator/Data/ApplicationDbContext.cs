using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Menuinator.Models;

namespace Menuinator.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CookingMethod> CookingMethods { get; set; }
        public DbSet<CookingTime> CookingTimes { get; set; }
        public DbSet<DefaultMeal> DefaultMeals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealMenu> MealMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<PrepTime> PrepTimes { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
        public DbSet<WeatherType> WeatherTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<MealMenu>()
                .HasKey(c => new { c.MealID, c.MenuID });

            builder.Entity<UserMeal>()
                .HasKey(c => new { c.MealID, c.AppUserID });
        }
    }
}
