using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AutoAccessoriesPlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoAccessoriesPlus.Data
{
    public class AutoAccessoriesPlusDbContext : IdentityDbContext
    {
        public AutoAccessoriesPlusDbContext(DbContextOptions<AutoAccessoriesPlusDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrandAccessories> VehicleBrandAccessories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            const string USER_ID = "03895gh1–8321–5bef-bgea-48t832w83ey7";
            const string ROLE_ID = "532467h2-hfr4–63ej-nhre-75shrewf89r8";
            
            base.OnModelCreating(builder);

            builder.Entity<Vehicle>()
                        .HasMany(c => c.VehicleBrandAccessories)
                        .WithOne(e => e.Vehicle).IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

            //seed user role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin", 
                NormalizedName = "Admin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new IdentityUser
            {
                Id = USER_ID,
                Email = "steel9561@yahoo.com",
                EmailConfirmed = true,                
                UserName = "steel9561@yahoo.com",
                NormalizedUserName= "steel9561@yahoo.com",
                NormalizedEmail= "steel9561@yahoo.com"
            };

            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "My5pass@ord");

            //seed user
            builder.Entity<IdentityUser>().HasData(appUser);

            //set user role to User Role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = USER_ID
            });
        }
    }
}
