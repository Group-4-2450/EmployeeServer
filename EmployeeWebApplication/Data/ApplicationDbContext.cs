using System;
using System.Collections.Generic;
using System.Text;
using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEmergencyContactInformation> EmployeeEmergencyContacts { get; set; }
        public DbSet<EmployeeExpense> EmployeeExpenses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
