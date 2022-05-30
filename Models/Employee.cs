
using System.ComponentModel.DataAnnotations;

namespace DapperAndEntityFrameworkApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }
    }
}
