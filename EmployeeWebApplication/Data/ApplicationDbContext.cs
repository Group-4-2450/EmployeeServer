using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EmployeeWebApplication.Models.EmployeeEmergencyContact> EmployeeEmergencyContact { get; set; }
        public DbSet<EmployeeWebApplication.Models.EmployeeExpenses> EmployeeExpenses { get; set; }
    }
}
