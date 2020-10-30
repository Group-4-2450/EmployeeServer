using System;
using System.ComponentModel.DataAnnotations;
using EmployeeWebApplication.Models.EnumTypes;

namespace EmployeeWebApplication.Models
{
    public class Employee
    {
        //This is the primary key for the database. No touchie.
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Title { get; set; }
        public EmployeeTypesEnum EmployeeType { get; set; }
        public GenderTypes Gender { get; set; }
        public float Wage { get; set; } 
        public DateTime StartDate { get; set; }
        public string HomeAddress { get; set; }
        public string PaymentInformation { get; set; }
    }
}
