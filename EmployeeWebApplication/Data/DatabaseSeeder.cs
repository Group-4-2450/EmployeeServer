using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebApplication.Authorization;
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

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Executive", "Management", "HumanResources", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    _ = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedUsersAsync(UserManager<Employee> userManager)
        {
            var users = new List<Employee>
            {
                new Employee
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    FirstName = "Example",
                    LastName = "Admin"
                },
                new Employee
                {
                    UserName = "executive@example.com",
                    Email = "executive@example.com",
                    EmailConfirmed = true,
                    FirstName = "executive",
                    LastName = "executive"
                },
                new Employee 
                {
                    UserName = "hr@example.com",
                    Email = "hr@example.com",
                    EmailConfirmed = true,
                    FirstName = "human",
                    LastName = "resources"
                },
                new Employee
                {
                    UserName = "manager@example.com",
                    Email = "manager@example.com",
                    EmailConfirmed = true,
                    FirstName = "manager",
                    LastName = "dude"
                },
                new Employee
                {
                    UserName = "employee@example.com",
                    Email = "employee@example.com",
                    EmailConfirmed = true,
                    FirstName = "employee",
                    LastName = "dude"
                }
        };

            foreach(var user in users)
            {
                if (await userManager.FindByEmailAsync(user.Email) == null)
                {
                    var creationResult = await userManager.CreateAsync(user, "CS2450-Group4!");

                    if (!creationResult.Succeeded)
                    {
                        throw new Exception("Failed to seed initial admin user.");
                    }
                }
            }
            
            var roleResultExec = await userManager.AddToRoleAsync(users[1], AuthorizationRoles.ExecutivesRole);
            var roleResultHr = await userManager.AddToRoleAsync(users[2], AuthorizationRoles.HumanResourcesRole);
            var roleResultManager = await userManager.AddToRoleAsync(users[3], AuthorizationRoles.ManagersRole);
            var roleResultEmployee = await userManager.AddToRoleAsync(users[4], AuthorizationRoles.EmployeeRole);
        }
    }
}
