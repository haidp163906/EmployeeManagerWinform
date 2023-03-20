using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_project.Models
{
    public partial class Manager
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? DepartmentId { get; set; }
    }
}
