using LINQDB_KZ_Preparation.Contracts;
using LINQDB_KZ_Preparation.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Project> GetAllProjects()
        {
            return dbcontext.Projects.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
           return dbcontext.Employees
                .Include(e=>e.Department)
                .ThenInclude(d=>d.Manager)
                .FirstOrDefault(x=>x.EmployeeId==id);
        }

        public Project GetProjectById(int id)
        {
            return dbcontext.Projects.FirstOrDefault(x=>x.ProjectId==id);
        }

        public List<Project> GetProjectsStartedAfterDate(DateTime date)
        {
            return dbcontext.Projects.Where(x => x.StartDate > date).ToList();
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

            Console.WriteLine($"{result.Count()}    -- {result2.Count()}");
                return result;
        }



    }
}
