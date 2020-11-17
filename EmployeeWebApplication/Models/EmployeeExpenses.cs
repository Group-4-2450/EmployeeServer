namespace EmployeeWebApplication.Models
{
    public class EmployeeExpenses
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public float Reimbursement { get; set; }
        public string CardNumber { get; set; }
        public bool CardEnabled { get; set; }
        public float CurrentBalance { get; set; }
    }
}
