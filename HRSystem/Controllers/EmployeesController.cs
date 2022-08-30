using HRSystem.Data.Abstract;
using HRSystem.Data.Concrete;
using HRSystem.Data.Context;
using HRSystem.Data.Entities;
using HRSystem.UI.Infrastructure;
using HRSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.UI.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeRepository _repository;
        HRSystemDBContext _context;
        
        public EmployeesController(IEmployeeRepository repository, HRSystemDBContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return new NotFoundResult();
        }

        public IActionResult List()
        {
            List<Employee> employees = _repository.GetEmployees().ToList();

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

            if (!model.id.HasValue)
            {
                Employee employee = new Employee()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email
                };


                await _repository.AddAsync(employee);
                await _repository.SaveAsync();
            }
            else
            {
                Employee? employee = await _repository.GetEmployeeByIDAsync(model.id ?? 0);

                employee.Name = model.Name;
                employee.Surname = model.Surname;
                employee.Email = model.Email;

                await _repository.SaveAsync();
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee? employee = _repository.GetEmployeeByID(id);

            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Email = employee.Email
            };
            ViewBag.IsEdit = true;

            return View("Add", employeeViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            _repository.DeleteEmployee(id);
            _repository.Save();

            return RedirectToAction(nameof(List));
        }
    }
}