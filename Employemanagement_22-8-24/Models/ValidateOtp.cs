using System.ComponentModel.DataAnnotations;

namespace Employemanagement_22_8_24.Models
{
    public class ValidateOtp
    {
        [Key]
        public string UserId { get; set; }

        
        public string Otp { get; set; }
    }
}
