using HRSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Data.Context
{
    public class HRSystemDBContext : DbContext
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=HRSystemDB;Integrated Security=True";
        
        public HRSystemDBContext()
            : base(GetOptions())
        {
        }

        public static DbContextOptions<HRSystemDBContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRSystemDBContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            
            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departament> Departaments { get; set; }
    }
}
