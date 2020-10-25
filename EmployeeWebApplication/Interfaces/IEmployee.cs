 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Interfaces
{
    interface IEmployee
    {
        Task CreateEmployeeAsync();
        Task GetAllEmployeesAsync();
        Task GetEmployeeAsync(int id);
        Task UpdateEmployeeAsync(int id);
        Task DeleteEmployeeRecordAsync(int id);
    }
}
