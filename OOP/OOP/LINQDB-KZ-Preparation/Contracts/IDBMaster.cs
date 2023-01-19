using LINQDB_KZ_Preparation.Models;
using LINQDB_KZ_Preparation.Services;
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
        List<T> GetAll<T>() where T : class;
        PersonDataMiniDTO[] GetAllEmpsFromDepartment(int departmentId);
        List<Project> GetAllProjects();
        Dictionary<int, string> GetDepatamentsNames();
        Employee GetEmployeeById(int id);
        Project GetProjectById(int id);
        List<Project> GetProjectsStartedAfterDate(DateTime date);
        List<Project> GetProjectsStartedBeforeDate(DateTime date);
        object GetSpeciaData();
    }
}
