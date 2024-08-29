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


        public async Task CreateUserAsync(User user)
        {
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddLoginAsync(string userId, string email)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null) throw new KeyNotFoundException("User not found.");

            if (existingUser.LoginCreated) throw new InvalidOperationException("Login already created for this user.");

            existingUser.Email = email;
            existingUser.Password = GenerateTempPassword();
            existingUser.LoginCreated = true;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            await SendEmailAsync(existingUser.Email, existingUser.Password);
        }






        //---------------------------------------------------------------------------------------------------------

        // Requests

        public async Task UpdateRequestAsync(Request request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var existingRequest = await _context.Requests.FindAsync(request.RequestId);
            if (existingRequest == null) throw new KeyNotFoundException("Request not found.");

            existingRequest.isprocessed = request.isprocessed;
            existingRequest.Remarks = request.Remarks; // Update remarks
            _context.Requests.Update(existingRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int requestId)
        {
            return await _context.Requests.FindAsync(requestId);
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
                existingUser.DateOfJoin = user.DateOfJoin;
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

        // Method to generate the next User ID in the sequence
        public async Task<string> GenerateUserIdAsync()
        {
            var lastUser = await _context.Users.OrderByDescending(u => u.UserId).FirstOrDefaultAsync();
            if (lastUser == null)
                return "Q100"; // Starting point if no users exist

            int lastIdNumber = int.Parse(lastUser.UserId.Substring(1));
            return $"Q{lastIdNumber + 1}";
        }
        //--------------------------------------------------
        public List<User> GetUserIdSuggestions(string partialUserId)
        {
            return _context.Users
                            .Where(u => u.UserId.Contains(partialUserId)) // Filter by partial UserId
                            .ToList();
        }
    }
}
