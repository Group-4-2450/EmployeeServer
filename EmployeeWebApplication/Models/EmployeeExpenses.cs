using System;
using System.Collections.Generic;

namespace EmployeeWebApplication.Models
{
    public partial class EmployeeExpenses
    {
        public int Id { get; set; }
        public float Reimbursement { get; set; }
        public string CardNumber { get; set; }
        public bool CardEnabled { get; set; }
        public float CurrentBalance { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}
