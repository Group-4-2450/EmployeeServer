using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Interfaces
{
    interface IEmployeeExpenses
    {
        Task CreateExpenseRecordForEmployeeAsync(int id);
        Task GetAllExpenseRecordsAsync();
        Task GetEmployeeeExpenseRecordAsync(int id);
        Task UpdateEmployeeExpenseRecordAsync(int id);
    }
}
