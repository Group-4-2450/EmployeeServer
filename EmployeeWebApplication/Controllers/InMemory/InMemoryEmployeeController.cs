using EmployeeWebApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Controllers.InMemory
{
    public class InMemoryEmployeeController : IEmployeeAccessProvider
    {
        public Task CreateEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeRecordAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
