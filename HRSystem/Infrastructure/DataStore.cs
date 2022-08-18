using HRSystem.Data.Entities;

namespace HRSystem.UI.Infrastructure
{
    public static class DataStore
    {
        public static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Surname = "Doe", Email = "asdas@mail.com" },
                new Employee { Id = 2, Name = "Jane", Surname = "Pu", Email = "asdas@mail.com" },
                new Employee { Id = 3, Name = "Edmon", Surname = "So", Email = "asdas@mail.com" },
                new Employee { Id = 4, Name = "Ashot", Surname = "Yan", Email = "asdas@mail.com" },
                new Employee { Id = 5, Name = "Valod", Surname = "Gevorgyan", Email = "asdas@mail.com" },
                new Employee { Id = 6, Name = "Anastasiya", Surname = "Papikyan", Email = "asdas@mail.com" },
            };
        }
    }
}
