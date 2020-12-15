using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmployeeWebApplication.Data;
using EmployeeWebApplication.Models;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace EmployeeWebApplication.Controllers
{
    public class EmployeeExporter
    {
        UserManager<Employee> _userManager;

        public EmployeeExporter(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> ExportAsCsvAsync(IEnumerable<Employee> employees)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(FormatColumnValues(new[]
            {
                "Employee ID",
                "First Name",
                "Last Name",
                "Birth Date",
                "Title",
                "Wage",
                "Start Date",
                "Phone Number",
                "Home Address",
                "Payment Information",
                "Roles",
                "Gender",
            }));

            foreach (var employee in employees.ToList())
            {
                var roles = await _userManager.GetRolesAsync(employee);
                var roleNames = string.Join(",", roles);

                stringBuilder.AppendLine(FormatColumnValues(new[]
                {
                    employee.EmployeeId,
                    employee.FirstName,
                    employee.LastName,
                    FormatDate(employee.BirthDate),
                    employee.Title,
                    employee.Wage.ToString(),
                    FormatDate(employee.StartDate),
                    employee.PhoneNumber,
                    employee.HomeAddress,
                    employee.PaymentInformation,
                    roleNames,
                    employee.Gender.ToString(),
                }));
            }

            return stringBuilder.ToString();
        }

        string FormatDate(DateTime date)
        {
            if (date == default)
            {
                return "";
            }
            else
            {
                return date.ToString("d");
            }
        }

        string FormatColumnValues(string[] columnValues)
        {
            return string.Join(",", columnValues.Select(FormatColumnValue));
        }

        string FormatColumnValue(string columnValue)
        {
            if (columnValue == null)
            {
                return "";
            }

            if (!columnValue.Contains(",") && !columnValue.Contains("\""))
            {
                return columnValue;
            }

            columnValue = columnValue.Replace("\"", "\"\"");
            return $"\"{columnValue}\"";
        }
    }
}
