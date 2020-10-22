using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Models
{
    public class EmployeeExpense
    {
        [ForeignKey("Employee")]
        public int ID { get; set; }

        public float Reimbursements { get; set; }
        public string CardNumber { get; set; }
        public bool IsCardEnabled { get; set; }
        public float CurrentBalance { get; set; }
    }
}
