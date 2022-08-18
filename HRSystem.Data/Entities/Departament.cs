using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Data.Entities
{
    public class Departament : EntityBase
    {
        public Departament()
        {
            Employees = new List<Employee>();
        }

        [Required]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
