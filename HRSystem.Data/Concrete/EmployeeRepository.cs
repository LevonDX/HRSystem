using HRSystem.Data.Context;
using HRSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Data.Concrete
{
    public class EmployeeRepository : IDisposable
    {
        HRSystemDBContext context;

        public EmployeeRepository()
        {
            context = new HRSystemDBContext();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await context.Employees.AddAsync(employee);
        }
        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetEmployees(bool getDeleted = false)
        {
            if (!getDeleted)
                return this.context.Employees.Where(e => !e.IsDeleted);
            else
                return this.context.Employees;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.context.Employees;
        }


        public void Update(Employee employee)
        {
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Employee? GetEmployeeByID(int ID)
        {
            Employee? employee = this.context.Employees.Find(ID);
            return employee;
        }

        public async Task<Employee?> GetEmployeeByIDAsync(int ID)
        {
            Employee? employee = await this.context.Employees.FindAsync(ID);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            this.context.Employees.Remove(employee);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
