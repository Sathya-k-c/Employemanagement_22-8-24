using System.ComponentModel.DataAnnotations;

namespace Employemanagement_22_8_24.Models
{
    public class UpdatePassword
    {
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "New password is required.")]

        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } // Used to confirm the new password
    }
}
