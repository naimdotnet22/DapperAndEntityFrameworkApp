using Dapper;
using DapperAndEntityFrameworkApp.DataContext;
using DapperAndEntityFrameworkApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DapperAndEntityFrameworkApp.Repositories.EmpRepository
{
    public class EmpRepositoryDapper : IEmpRepository
    {
        private readonly IDbConnection _db;
        string sql = "";

        public EmpRepositoryDapper(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("appdb"));
        }


        public Employee Insert(Employee employee)
        {
            sql = "INSERT INTO Employees(Name, Code, Address, Age) VALUES(@Name, @Code, @Address, @Age);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = _db.Query<int>(sql, employee).Single();

            employee.EmployeeId = id;
            return employee;
        }

        public Employee Update(Employee employee)
        {
            sql = "UPDATE Employees SET Name= @Name, Code= @Code, Address= @Address, Age= @Age " +
                "WHERE EmployeeId = @EmployeeId";
            _db.Execute(sql, employee);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            sql = "SELECT * FROM Employees";
            return _db.Query<Employee>(sql).ToList();
        }

        public Employee Find(int id)
        {
            sql = "  SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
            return _db.Query<Employee>(sql, new { @EmployeeId = id }).Single();
        }

        public void Remove(int id)
        {
            sql = "DELETE FROM Employees WHERE EmployeeId = @id";
            _db.Execute(sql, new { id });
        }
    }
}
