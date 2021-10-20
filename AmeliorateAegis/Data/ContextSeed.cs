using AmeliorateAegis.Models;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(SD.SuperAdmin));
            await roleManager.CreateAsync(new IdentityRole(SD.ProvincialLiason));
            await roleManager.CreateAsync(new IdentityRole(SD.RegionalManager));
            await roleManager.CreateAsync(new IdentityRole(SD.Teacher));
            await roleManager.CreateAsync(new IdentityRole(SD.Parent));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@ameliorate.com",
                Email = "admin@ameliorate.com",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.SuperAdmin);
                }

            }
        }
    }
}
