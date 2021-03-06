using System.ComponentModel.DataAnnotations;
    

namespace inventory_management_v6.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        
        [Required]
        
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string? Email { get; set; }






        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
