using EmployeeWebApplication.Models.EnumTypes;


namespace EmployeeWebApplication.Models
{
    public partial class EmployeeEmergencyContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public PhoneTypeEnum phone_type { get; set; }
        public EmployeeRelationshipEnum relationship_to_employee { get; set; }
        public virtual Employee IdNavigation { get; set; }
    }
}
