﻿using System;
using System.Collections.Generic;

namespace LINQDB_KZ_Preparation.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; } E= null!;
        public int ManagerId { get; set; }

        public virtual Employee Manager { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
