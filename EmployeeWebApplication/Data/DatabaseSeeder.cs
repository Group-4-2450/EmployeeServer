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
                    EmployeeId = "1",
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    FirstName = "Example",
                    LastName = "Admin",
                    Title = "The Admin",
                    BirthDate = DateTime.Now.AddYears(-50),
                    StartDate = DateTime.Now.AddYears(-5),
                },
                new Employee
                {
                    EmployeeId = "2",
                    UserName = "executive@example.com",
                    Email = "executive@example.com",
                    EmailConfirmed = true,
                    FirstName = "executive",
                    LastName = "executive",
                    Title = "The Executive",
                    BirthDate = DateTime.Now.AddYears(-42),
                    StartDate = DateTime.Now.AddYears(-4),
                },
                new Employee 
                {
                    EmployeeId = "3",
                    UserName = "hr@example.com",
                    Email = "hr@example.com",
                    EmailConfirmed = true,
                    FirstName = "human",
                    LastName = "resources",
                    Title = "The Killer of Fun",
                    BirthDate = DateTime.Now.AddYears(-26),
                    StartDate = DateTime.Now.AddYears(-3),
                },
                new Employee
                {
                    EmployeeId = "4",
                    UserName = "manager@example.com",
                    Email = "manager@example.com",
                    EmailConfirmed = true,
                    FirstName = "manager",
                    LastName = "dude",
                    Title = "The Party Pooper",
                    BirthDate = DateTime.Now.AddYears(-34),
                    StartDate = DateTime.Now.AddYears(-2),
                },
                new Employee
                {
                    EmployeeId = "5",
                    UserName = "employee@example.com",
                    Email = "employee@example.com",
                    EmailConfirmed = true,
                    FirstName = "employee",
                    LastName = "dude",
                    Title = "The Would-be Haver of Fun",
                    BirthDate = DateTime.Now.AddYears(-18),
                    StartDate = DateTime.Now.AddYears(-1),
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
            
            await userManager.AddToRoleAsync(users[1], AuthorizationRoles.ExecutivesRole);
            await userManager.AddToRoleAsync(users[2], AuthorizationRoles.HumanResourcesRole);
            await userManager.AddToRoleAsync(users[3], AuthorizationRoles.ManagersRole);
            await userManager.AddToRoleAsync(users[4], AuthorizationRoles.EmployeeRole);

            await userManager.AddToRoleAsync(users[0], AuthorizationRoles.ExecutivesRole);
            await userManager.AddToRoleAsync(users[0], AuthorizationRoles.HumanResourcesRole);
            await userManager.AddToRoleAsync(users[0], AuthorizationRoles.ManagersRole);
            await userManager.AddToRoleAsync(users[0], AuthorizationRoles.EmployeeRole);
        }
    }
}
