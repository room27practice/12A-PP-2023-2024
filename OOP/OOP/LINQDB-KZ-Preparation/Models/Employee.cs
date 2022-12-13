using System;
using System.Collections.Generic;

namespace LINQDB_KZ_Preparation.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            InverseManager = new HashSet<Employee>();
            Projects = new HashSet<Project>();
            //   UserVehicles = new HashSet<UserVehicle>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string JobTitle { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? AddressId { get; set; }

        public Happiness HappinessStatus => CalculateHappiness();

        private Happiness CalculateHappiness()
        {
            if (Salary>6000)
            {
                return Happiness.SuperHappy;
            }
            if (Salary > 4000)
            {
                return Happiness.AlmostHappy;
            }
            if (Salary > 3000)
            {
                return Happiness.Macdonalds;
            }
            return Happiness.Miserable;
        }


        public virtual Address? Address { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        // public ICollection<UserVehicle> UserVehicles { get; set; }
    }
}

public enum Happiness
{
    SuperHappy, AlmostHappy, Macdonalds, Miserable
}
