using System.ComponentModel.DataAnnotations;

namespace HRSystem.UI.Models
{
    public class EmployeeViewModel
    {
        [Display(Name ="Անուն")]
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
