using DapperAndEntityFrameworkApp.DataContext;
using DapperAndEntityFrameworkApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DapperAndEntityFrameworkApp.Repositories.EmpRepository
{
    public class EmpRepositoryEF : IEmpRepository
    {
        private readonly ApplicationDbContext _db;

        public EmpRepositoryEF(ApplicationDbContext db)
        {
            _db = db;
        }


        public Employee Insert(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            _db.Employees.Update(employee);
            _db.SaveChanges();
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _db.Employees.ToList();
        }

        public Employee Find(int id)
        {
            Employee employee = _db.Employees.FirstOrDefault(c => c.EmployeeId == id);
            return employee;
        }

        public void Remove(int id)
        {
            Employee employee = _db.Employees.FirstOrDefault(c => c.EmployeeId == id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
