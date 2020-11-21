using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeWebApplication.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDataAsync(RoleManager<IdentityRole> roleManager, UserManager<Employee> userManager)
        {
            await SeedRolesAsync(roleManager);
            await SeedUsersAsync(userManager);
        }

        private static Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            return Task.CompletedTask;
        }

        private static async Task SeedUsersAsync(UserManager<Employee> userManager)
        {
            if (await userManager.FindByEmailAsync("admin@example.com") != null)
            {
                return;
            }

            var user = new Employee
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                EmailConfirmed = true,
                FirstName = "Example",
                LastName = "Admin",
            };

            var creationResult = await userManager.CreateAsync(user, "CS2450-Group4!");

            if (!creationResult.Succeeded)
            {
                throw new Exception("Failed to seed initial admin user.");
            }
        }
    }
}
