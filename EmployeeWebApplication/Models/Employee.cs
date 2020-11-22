using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EmployeeWebApplication.Models.EnumTypes;
using Microsoft.AspNetCore.Identity;

namespace EmployeeWebApplication.Models
{
    public class Employee : IdentityUser
    {
        public ICollection<EmployeeEmergencyContact> EmergencyContacts { get; set; }

        public ICollection<EmployeeExpenses> Expenses { get; set; }

        [DisplayName("Employee ID")]
        public string EmployeeId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("SSN")]
        public string Ssn { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Wage { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Phone Number")]
        public override string PhoneNumber
        {
            get => base.PhoneNumber;
            set => base.PhoneNumber = value;
        }

        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }

        [DisplayName("Payment Information")]
        public string PaymentInformation { get; set; }

        public Gender Gender { get; set; }
    }
}
