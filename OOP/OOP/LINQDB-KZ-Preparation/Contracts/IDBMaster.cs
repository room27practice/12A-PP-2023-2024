using LINQDB_KZ_Preparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDB_KZ_Preparation.Contracts
{
    public interface IDBMaster
    {
        List<Address> GetAddressesOfEmployeesWithUnfinishedProjects();
        List<Project> GetAllProjects();
        Employee GetEmployeeById(int id);
        Project GetProjectById(int id);
        List<Project> GetProjectsStartedAfterDate(DateTime date);
    }
}
