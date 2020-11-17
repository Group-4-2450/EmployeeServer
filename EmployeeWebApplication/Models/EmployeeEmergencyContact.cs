using EmployeeWebApplication.Models.EnumTypes;

namespace EmployeeWebApplication.Models
{
    public class EmployeeEmergencyContact
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public PhoneType PhoneType { get; set; }
        public EmployeeRelationship RelationshipToEmployee { get; set; }
    }
}
