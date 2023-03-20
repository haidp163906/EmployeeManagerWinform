using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_project.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
