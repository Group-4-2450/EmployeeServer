using EmployeeWebApplication.Models.EnumTypes;

namespace EmployeeWebApplication.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        //This is used for authorization
        public string ownerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthdate { get; set; }
        public string Title { get; set; }
        public double? Wage { get; set; }
        public string StartDate { get; set; }
        public string HomeAddress { get; set; }
        public string PaymentInformation { get; set; }
        public employee_position_tpyes employee_position { get; set; }
        public gender_types gender { get; set; }

        //This is used for authorization
        public PermissionTypes permission { get; set; }
    }
}
