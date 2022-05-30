using DapperAndEntityFrameworkApp.Models;
using System.Collections.Generic;

namespace DapperAndEntityFrameworkApp.Repositories.EmpRepository
{
    public interface IEmpRepository
    {
        Employee Find(int id);
        List<Employee> GetEmployees();
        Employee Insert(Employee employee);
        void Remove(int id);
        Employee Update(Employee employee);
    }
}