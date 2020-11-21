using EmployeeWebApplication.Models.EnumTypes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApplication.Models
{
    public class EmployeeEditViewModel
    {
        public string Id { get; set; }
        
        public string ConcurrencyStamp { get; set; }

        public string EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public DateTime BirthDate { get; set; }

        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Wage { get; set; }

        public DateTime StartDate { get; set; }

        public string PhoneNumber { get; set; }

        public string HomeAddress { get; set; }

        public string PaymentInformation { get; set; }

        public Gender Gender { get; set; }

        public EmployeeEditViewModel()
        {

        }

        public EmployeeEditViewModel(Employee employee)
        {
            Id = employee.Id;
            ConcurrencyStamp = employee.ConcurrencyStamp;
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Ssn = employee.Ssn;
            BirthDate = employee.BirthDate;
            Title = employee.Title;
            Wage = employee.Wage;
            StartDate = employee.StartDate;
            PhoneNumber = employee.PhoneNumber;
            HomeAddress = employee.HomeAddress;
            PaymentInformation = employee.PaymentInformation;
            Gender = employee.Gender;
        }

        public void ApplyTo(Employee employee)
        {
            employee.Id = Id;
            employee.ConcurrencyStamp = ConcurrencyStamp;
            employee.EmployeeId = EmployeeId;
            employee.FirstName = FirstName;
            employee.LastName = LastName;
            employee.Ssn = Ssn;
            employee.BirthDate = BirthDate;
            employee.Title = Title;
            employee.Wage = Wage;
            employee.StartDate = StartDate;
            employee.PhoneNumber = PhoneNumber;
            employee.HomeAddress = HomeAddress;
            employee.PaymentInformation = PaymentInformation;
            employee.Gender = Gender;
        }
    }
}
