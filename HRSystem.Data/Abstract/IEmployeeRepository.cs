using HRSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Data.Abstract
{
    public interface IEmployeeRepository
    {
        void Save();
        Task SaveAsync();
        Task AddAsync(Employee employee);
        void Add(Employee employee);
        IEnumerable<Employee> GetEmployees(bool getDeleted = false);
        IEnumerable<Employee> GetEmployees();
        void Update(Employee employee);
        void DeleteEmployee(int ID);
        Employee? GetEmployeeByID(int ID);
        Task<Employee?> GetEmployeeByIDAsync(int ID);
    }
}
