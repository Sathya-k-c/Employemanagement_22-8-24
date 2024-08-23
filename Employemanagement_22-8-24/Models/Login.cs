using System.ComponentModel.DataAnnotations;

namespace Employemanagement_22_8_24.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; } // Taken from admin during add user

        [Required(ErrorMessage = "Password is required.")]
        
        public string Password { get; set; } // Password must meet certain complexity requirements

    }
}
