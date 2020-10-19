using System;
using EmployeeWebApplication.Models.EnumTypes;

namespace EmployeeWebApplication.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public EmployeeTypesEnum employeeType { get; set; }
        public GenderTypes gender { get; set; }
        public float Wage { get; set; }
        public DateTime StartDate { get; set; }
        public string HomeAddress { get; set; }
        public string PaymentInformation { get; set; }
    }
}
