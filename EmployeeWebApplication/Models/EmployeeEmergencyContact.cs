using EmployeeWebApplication.Models.EnumTypes;
using System.ComponentModel;

namespace EmployeeWebApplication.Models
{
    public class EmployeeEmergencyContact
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [DisplayName("Phone Type")]
        public PhoneType PhoneType { get; set; }

        [DisplayName("Relationship To Employee")]
        public EmployeeRelationship RelationshipToEmployee { get; set; }
    }
}
