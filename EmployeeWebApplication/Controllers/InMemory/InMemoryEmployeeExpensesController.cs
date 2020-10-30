using EmployeeWebApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Controllers.InMemory
{
    public class InMemoryEmployeeExpensesController : IEmployeeExpenses
    {
        public Task CreateExpenseRecordForEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllExpenseRecordsAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetEmployeeeExpenseRecordAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeExpenseRecordAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
