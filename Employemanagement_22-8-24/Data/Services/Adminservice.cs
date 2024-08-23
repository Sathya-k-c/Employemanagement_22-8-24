using Employemanagement_22_8_24.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Employemanagement_22_8_24.Data.Services
{
    public class Adminservice : IADMINSERVICE
    {
        private readonly ApplicationDbContext _context; // Assuming you're using Entity Framework
        private readonly string _adminId = "A100";
        private readonly string _adminPassword = "123456";

        public Adminservice(ApplicationDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------------------------

        // Requests

        public async Task AcceptRequestAsync(Request request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var existingRequest = await _context.Requests.FindAsync(request.RequestId);
            if (existingRequest == null) throw new KeyNotFoundException("Request not found.");

            existingRequest.isprocessed = Enums.Isprocessed.Accepted;
            _context.Requests.Update(existingRequest);
            await _context.SaveChangesAsync();
        }

        public async Task RejectRequestAsync(Request request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var existingRequest = await _context.Requests.FindAsync(request.RequestId);
            if (existingRequest == null) throw new KeyNotFoundException("Request not found.");

            existingRequest.isprocessed = Enums.Isprocessed.Rejected;
            _context.Requests.Update(existingRequest);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        //------------------------------------------------------------------------------------------------------------

        public async Task AddUserAsync(User user)
        {
            // Generate a temporary password
            string tempPassword = GenerateTempPassword();

            // Set initial password and role
            user.Password = tempPassword;
            user.Role = "User";

            // Add user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Send email with temporary password
            await SendEmailAsync(user.Email, tempPassword);

        }

        public async Task DeleteUserAsync(User user)
        {
            
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            

        }



        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }



        public async Task UpdateUserDetailsAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Gender = user.Gender;
                existingUser.MaritalStatus = user.MaritalStatus;
                existingUser.BloodGroup = user.BloodGroup;
                existingUser.Nationality = user.Nationality;
                existingUser.ResidentialAddress = user.ResidentialAddress;
                existingUser.District = user.District;
                existingUser.State = user.State;
                existingUser.PersonalPhoneNumber = user.PersonalPhoneNumber;
                existingUser.BasicPay = user.BasicPay;
                existingUser.HRA = user.HRA;
                existingUser.ConveyanceAllowance = user.ConveyanceAllowance;
                existingUser.FixedMedicalAllowance = user.FixedMedicalAllowance;
                existingUser.TotalEarnings = user.TotalEarnings;
                existingUser.BankName = user.BankName;
                existingUser.AccountHolderName = user.AccountHolderName;
                existingUser.AccountNumber = user.AccountNumber;
                existingUser.Designation = user.Designation;
                existingUser.Department = user.Department;
                existingUser.StartDate = user.StartDate;
                existingUser.EmploymentType = user.EmploymentType;
                existingUser.WorkEmail = user.WorkEmail;
                existingUser.WorkPhoneNumber = user.WorkPhoneNumber;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }

        }

        //---------------------------------------------------------------------------------------------------------

        private string GenerateTempPassword()
        {
            // Implement a method to generate a temporary password
            var rng = new Random();
            var length = 8;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rng.Next(s.Length)]).ToArray());
        }

        private async Task SendEmailAsync(string email, string tempPassword)
        {

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                // Gmail credentials
                smtpClient.Credentials = new NetworkCredential("erennnyeager.aot@gmail.com", "xfms idvl wzqx owme");
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("erennnyeager.aot@gmail.com"),
                    Subject = "Temporary Password",
                    Body = tempPassword,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }



        }
    }
}
