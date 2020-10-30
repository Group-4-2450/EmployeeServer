using EmployeeWebApplication.ModelsGenerated.EnumTypes;

namespace EmployeeWebApplication.ModelsGenerated
{
    public partial class EmployeeEmergencyContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public PhoneTypeEnum PhoneType { get; set; }
        public EmployeeRelationshipEnum RelationshipToEmployee { get; set; }
        public virtual Employee IdNavigation { get; set; }
    }
}
