using System.ComponentModel.DataAnnotations;

namespace HRSystem.UI.Models
{
    public class EmployeeViewModel
    {
        public int? id { get; set; }

        [Display(Name ="Անուն")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
