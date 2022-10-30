using System.ComponentModel.DataAnnotations;

namespace AspNetCore_6_MVC_Crud.Models
{
    public class AddEmployeeModel
    {
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Email { get; set; }
        
        [Required]
        public long Salary { get; set; }
        
        [Required]
        public string Department { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
