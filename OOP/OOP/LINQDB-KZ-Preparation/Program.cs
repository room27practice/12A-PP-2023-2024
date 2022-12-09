using LINQDB_KZ_Preparation.Contracts;
using LINQDB_KZ_Preparation.Models;
using LINQDB_KZ_Preparation.Services;

namespace LINQDB_KZ_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IDBMaster db = new DBMaster();        
            List<Project> projects= db.GetAllProjects();

            Employee employee = db.GetEmployeeById(5);

            var allAddressesOfEmpsWithUnfinishedBusiness = db.GetAddressesOfEmployeesWithUnfinishedProjects();


            List<Project> projectsAfterDate = db.GetProjectsStartedAfterDate(new DateTime(2003, 1, 6));
            
            foreach (var item in projects)
            {
                Console.WriteLine(item.Name);
            }
        
        
        }
    }
}