    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Data.Entities
{
    public class Employee : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        
        public DateTime? BirthDate { get; set; }

        public decimal? Salary { get; set; }

        public virtual Departament? Departament { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}