using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Division { get; set; }

        public string Role { get; set; }

    }
}
