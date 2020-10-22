using EmployeeWebApplication.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Models
{
    public class EmployeeEmergencyContactInformation
    {
        [ForeignKey("Employee")]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypeEnum PhoneType { get; set; }
        public string Email { get; set; }
        public EmployeeRelationshipEnum employeeRelationship { get; set; }
    }
}
