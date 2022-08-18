using HRSystem.Data.Context;
using HRSystem.Data.Entities;
using HRSystem.UI.Infrastructure;
using HRSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.UI.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            IEnumerable<Employee> employees = DataStore.GetEmployees();

            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (Employee item in employees)
            {
                EmployeeViewModel model = new EmployeeViewModel()
                {
                    Name = item.Name,
                    Surname = item.Surname
                };

                employeeViewModels.Add(model);
            }
                
            return View(employeeViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid Model";
                return View();
            }

            Employee employee = new Employee()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email
            };

            using (var context = new HRSystemDBContext())
            {
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
