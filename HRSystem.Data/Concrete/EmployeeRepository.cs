using HRSystem.Data.Context;
using HRSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Data.Concrete
{
    public class HrSystemRepository<T> : IDisposable where T:EntityBase
    {
        HRSystemDBContext context;

        public HrSystemRepository()
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

        public async Task AddAsync(T employee)
        {
            await context.AddAsync(employee);
        }
        public void Add(T employee)
        {
            context.Add(employee);
        }

        public IEnumerable<T> GetEmployees(bool getDeleted = false)
        {
            if (!getDeleted)
                return this.context.Set<T>().Where(e => !e.IsDeleted);
            else
                return this.context.Set<T>();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.context.Employees;
        }


        public void Update(T employee)
        {
            context.Entry<T>(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
