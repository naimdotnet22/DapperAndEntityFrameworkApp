using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DapperAndEntityFrameworkApp.Models;
using DapperAndEntityFrameworkApp.Repositories.EmpRepository;

namespace DapperAndEntityFrameworkApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpRepository _emp;

        public EmployeeController(IEmpRepository emp)
        {
            _emp = emp;
        }

        public async Task<IActionResult> Index()
        {
            return View(_emp.GetEmployees());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = _emp.Find(id.GetValueOrDefault());

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Code,Address,Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _emp.Insert(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = _emp.Find(id.GetValueOrDefault());
            if (employee == null)
                return NotFound();

            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Code,Address,Age")] Employee employee)
        {
            if (id != employee.EmployeeId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _emp.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _emp.Remove(id.GetValueOrDefault());

            return RedirectToAction(nameof(Index));
        }


    }
}
