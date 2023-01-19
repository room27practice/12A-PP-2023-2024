using LINQDB_KZ_Preparation.Contracts;
using LINQDB_KZ_Preparation.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LINQDB_KZ_Preparation.Services
{
    public class DBMaster : IDBMaster
    {

        private SoftUniContext dbcontext;


        public DBMaster()
        {
            dbcontext = new SoftUniContext();
        }


        public List<T> GetAll<T>()
            where T : class
        {
            return dbcontext.Set<T>().ToList();
        }

        public List<Project> GetAllProjects()
        {
            return dbcontext.Projects.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return dbcontext.Employees
                 .Include(e => e.Department)
                 .ThenInclude(d => d.Manager)
                 .FirstOrDefault(x => x.EmployeeId == id);
        }

        public Project GetProjectById(int id)
        {
            return dbcontext.Projects.FirstOrDefault(x => x.ProjectId == id);
        }

        public List<Project> GetProjectsStartedAfterDate(DateTime date)
        {
            return dbcontext.Projects.Where(x => x.StartDate > date).ToList();
        }

        public List<Project> GetProjectsStartedBeforeDate(DateTime date)
        {
            return dbcontext.Projects.Where(x => x.StartDate <= date).ToList();
        }

        public List<Employee> GetAllEmployeesFromTown(int townId)
        {
            return dbcontext.Employees.Where(x => x.Address.Town.TownId == townId).ToList();
        }

        public List<Address> GetAddressesOfEmployeesWithUnfinishedProjects()
        {
            var result = dbcontext.Projects.Where(x => x.EndDate == null)
                .SelectMany(p => p.Employees).Distinct().Select(e => e.Address)
                .ToList();

            var result2 = dbcontext.Employees.Where(e => e.Projects.Any(p => p.EndDate == null))
                .Select(e1 => e1.Address).ToArray();

            Console.WriteLine($"{result.Count()}   -- {result2.Count()}");
            return result;
        }

        public Dictionary<int, string> GetDepatamentsNames()
        {
            var result = dbcontext.Departments.ToDictionary(d => d.DepartmentId, d => d.Name);
            return result;

        }

        public PersonDataMiniDTO[] GetAllEmpsFromDepartment(int departmentId)
        {
            return dbcontext.Employees

                .Where(e => e.DepartmentId == departmentId)
                //  .OrderByDescending(e=>e.Projects.Count())
                .Select(e => new PersonDataMiniDTO
                {
                    Id = e.EmployeeId,
                    Name = $"{e.FirstName.ToUpper()[0]}. {e.LastName}",
                    Salary = e.Salary * 0.9m,
                    ProjectsCount = e.Projects.Count()
                })
                .OrderByDescending(e => e.ProjectsCount)
                .ToArray();
        }

        public object GetSpeciaData()
        {
            var data = dbcontext.Employees.Select(x => new
            {
                Name = x.FirstName + " " + x.LastName,
                Projects = x.Projects.Select(p => p.Name).ToArray(),
                Salary = x.Salary,
                Address = new
                {
                    Town = x.Address.Town.Name,
                    Street = x.Address.AddressText
                }
            }).ToArray();
          
            return data;
        }

        PersonDataMiniDTO[] IDBMaster.GetAllEmpsFromDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }
    }

    public class PersonDataMiniDTO
    {
        public PersonDataMiniDTO()
        {

        }
        public PersonDataMiniDTO(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int ProjectsCount { get; set; }
        public override string ToString()
        {
            return $"Id:[{Id}]. {Name} --{Salary:F2}--. Works in {ProjectsCount} projects.";
        }
    }
}




