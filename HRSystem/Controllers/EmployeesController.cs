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
            return new NotFoundResult();
        }

        public IActionResult List()
        {
            using (HRSystemDBContext hRSystemDBContext = new HRSystemDBContext())
            {
                List<Employee> employees = hRSystemDBContext.Employees.ToList();


                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                foreach (Employee item in employees)
                {
                    EmployeeViewModel model = new EmployeeViewModel()
                    {
                        id = item.Id,
                        Name = item.Name,
                        Surname = item.Surname
                    };

                    employeeViewModels.Add(model);
                }

                return View(employeeViewModels);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid Model";
                return View();
            }

            if (model.id == 0)
            {
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
            }
            else
            {
                using (var context = new HRSystemDBContext())
                {
                    Employee? employee = await context.Employees.FindAsync(model.id);
                    
                    employee.Name = model.Name;
                    employee.Surname = model.Surname;
                    employee.Email = model.Email;
                    
                    await context.SaveChangesAsync();
                }
            }
            
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            using (HRSystemDBContext context = new HRSystemDBContext())
            {
                Employee? employee = context.Employees.Find(id);

                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Email = employee.Email
                };
                ViewBag.IsEdit = true;

                return View("Add", employeeViewModel);
            }
        }
    }
}