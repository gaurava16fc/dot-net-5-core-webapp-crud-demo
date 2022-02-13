using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet5CoreWebApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Employee Name is required")]
        [Display(Name="Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public string Department { get; set; }
    }
}
