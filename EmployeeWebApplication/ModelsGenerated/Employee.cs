using EmployeeWebApplication.ModelsGenerated.EnumTypes;

namespace EmployeeWebApplication.ModelsGenerated
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
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
        public EmployeeTypesEnum EmployeePosition { get; set; }
        public GenderTypes Gender { get; set; }
    }
}
