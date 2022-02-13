using System.ComponentModel.DataAnnotations;

namespace DotNet5CoreWebApp.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is required"), MinLength(2), MaxLengthAttribute(50)]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}
