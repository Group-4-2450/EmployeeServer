using System;
using System.Collections.Generic;
using EmployeeWebApplication.Models.EnumTypes;
using Microsoft.AspNetCore.Identity;

namespace EmployeeWebApplication.Models
{
    public class Employee : IdentityUser
    {
        public ICollection<EmployeeEmergencyContact> EmergencyContacts { get; set; }
        public ICollection<EmployeeExpenses> Expenses { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public DateTime BirthDate { get; set; }
        public string Title { get; set; }
        public double? Wage { get; set; }
        public DateTime StartDate { get; set; }
        public string HomeAddress { get; set; }
        public string PaymentInformation { get; set; }
        public Gender Gender { get; set; }
    }
}
