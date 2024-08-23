using System.ComponentModel.DataAnnotations;

namespace Employemanagement_22_8_24.Models
{
    public class ForgotPassword
    {
        
        public string UserId { get; set; }

        
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
