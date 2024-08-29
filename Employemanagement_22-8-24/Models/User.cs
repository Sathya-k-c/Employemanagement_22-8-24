using Employemanagement_22_8_24.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Employemanagement_22_8_24.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; } // Auto-generated, non-editable


        public string Password { get; set; } = "temp";// Set during login creation

        
        public string Role { get; set; } = "User"; // Default Role

        public bool IsFirstTimeLogin { get; set; } = true;


        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = ""; // Set during login creation

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PersonalPhoneNumber { get; set; } = ""; // From user creation form

        [EmailAddress(ErrorMessage = "Invalid work email format.")]
        public string WorkEmail { get; set; } = "";

        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Account number must be between 10 and 12 digits.")]
        public string AccountNumber { get; set; } = "";

        public string Name { get; set; } = "";

        public DateTime? DateOfBirth { get; set; } 

        public DateTime? DateOfJoin { get; set; }

        public Gender Gender { get; set; } = Gender.NotSpecified;

        public string MaritalStatus { get; set; } = "";

        public Bloodgroup BloodGroup { get; set; } = Bloodgroup.Unknown;

        public string Nationality { get; set; } = "";

        public string ResidentialAddress { get; set; } = "";

        public string District { get; set; } = "";

        public string State { get; set; } = "";

        public decimal BasicPay { get; set; } = 0.0m;

        public decimal HRA { get; set; } = 0.0m;

        public decimal ConveyanceAllowance { get; set; } = 0.0m;

        public decimal FixedMedicalAllowance { get; set; } = 0.0m;

        public decimal TotalEarnings { get; set; } = 0.0m;

        public string BankName { get; set; } = "";

        public string AccountHolderName { get; set; } = "";

        public string Designation { get; set; } = "";

        public string Department { get; set; } = "";

        public string EmploymentType { get; set; } = "";

        public string WorkPhoneNumber { get; set; } = "";

        public bool LoginCreated { get; set; } = false; // Indicates if login has been created for the user

       
    }
}
