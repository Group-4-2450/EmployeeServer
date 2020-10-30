using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Data
{
    public class PostgresSqlDbContextFactory : IDesignTimeDbContextFactory<PostgreSqlContext>
    {
        public PostgreSqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgreSqlContext>();
            optionsBuilder.UseNpgsql("User ID=EmployeeDBUser;Password=HelloThere69!;Server=192.168.1.165;Port=5432;Database=testDb;Integrated Security=true;Pooling=true;");

            return new PostgreSqlContext(optionsBuilder.Options);
        }
    }
}
