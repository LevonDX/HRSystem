using Microsoft.Build.Framework;

namespace HRSystem.UI.Models
{
    public class EmployeeAddModel
    {
        [Required]
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string? Email { get; set; }
    }
}
