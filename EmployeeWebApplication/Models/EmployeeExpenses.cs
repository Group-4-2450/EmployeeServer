using System.ComponentModel;

namespace EmployeeWebApplication.Models
{
    public class EmployeeExpenses
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }
        
        public float Reimbursement { get; set; }
        
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }
        
        [DisplayName("Card Enabled")]
        public bool CardEnabled { get; set; }
        
        [DisplayName("Current Balance")]
        public float CurrentBalance { get; set; }
    }
}
