using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_project.Models
{
    public partial class Salary
    {
        public int SalaryId { get; set; }
        public int? Bonus { get; set; }
        public int EmployeeId { get; set; }
        public int? HardSalary { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
