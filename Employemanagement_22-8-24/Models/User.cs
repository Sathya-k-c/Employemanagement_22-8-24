using Employemanagement_22_8_24.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Employemanagement_22_8_24.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; } // Taken from admin during add user

        [Required(ErrorMessage = "Password is required.")]
        
        public string Password { get; set; } // Password must meet certain complexity requirements

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } // Taken from admin during add user

        public bool IsFirstTimeLogin { get; set; } = true; // Default value is true for first-time login, no validation required

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } // Taken from admin during add user


        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PersonalPhoneNumber { get; set; } = "9658585456"; // Must be a valid phone number format


        [EmailAddress(ErrorMessage = "Invalid work email format.")]
        public string WorkEmail { get; set; } = "example@gmail.com"; // Must be a valid email format


        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Account number must be between 10 and 12 digits.")]
        public string AccountNumber { get; set; } = "000000000000"; // Must be between 10 and 12 digits

        public string Name { get; set; } = "Unknown"; // Default value: "Unknown"
        public DateTime? DateOfBirth { get; set; } = new DateTime(1900, 1, 1); // Default value: 1st Jan 1900
        public DateTime? StartDate { get; set; } = new DateTime(1900, 1, 1);



        public Gender Gender { get; set; } = Gender.NotSpecified; // Default value: Not Specified

        public string MaritalStatus { get; set; } = "Not Specified"; // Default value: "Not Specified"

        public Bloodgroup BloodGroup { get; set; } = Bloodgroup.Unknown; // Default value: "Unknown"

        public string Nationality { get; set; } = "Unknown"; // Default value: "Unknown"

        public string ResidentialAddress { get; set; } = "Unknown"; // Default value: "Unknown"

        public string District { get; set; } = "Unknown"; // Default value: "Unknown"

        public string State { get; set; } = "Unknown"; // Default value: "Unknown"

        public decimal BasicPay { get; set; } = 0.0m; // Default value: 0.0

        public decimal HRA { get; set; } = 0.0m; // Default value: 0.0

        public decimal ConveyanceAllowance { get; set; } = 0.0m; // Default value: 0.0

        public decimal FixedMedicalAllowance { get; set; } = 0.0m; // Default value: 0.0

        public decimal TotalEarnings { get; set; } = 0.0m; // Default value: 0.0

        public string BankName { get; set; } = "Unknown"; // Default value: "Unknown"

        public string AccountHolderName { get; set; } = "Unknown"; // Default value: "Unknown"

        public string Designation { get; set; } = "Unknown"; // Default value: "Unknown"

        public string Department { get; set; } = "Unknown"; // Default value: "Unknown"

        

        public string EmploymentType { get; set; } = "Unknown"; // Default value: "Unknown"

        public string WorkPhoneNumber { get; set; } = "0000000000"; // Default value: "0000000000"
       
    }
}
