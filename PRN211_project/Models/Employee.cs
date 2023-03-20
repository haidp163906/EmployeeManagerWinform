using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_project.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Salaries = new HashSet<Salary>();
            Tasks = new HashSet<Task>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
