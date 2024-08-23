
using Employemanagement_22_8_24.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Employemanagement_22_8_24.Data.Services
{
    public class Accountservice : IACCOUNTSERVICE
    {
        private readonly ApplicationDbContext _context;

        public Accountservice(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task ForgotPasswordAsync(string userId)

        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            SendOtpAsync(userId, user.Email);

        }
        public User GetUserByIdAsync(string userId)
        {
            return  _context.Users.Find(userId);
        }

        public async Task<string> GetUserRoleAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            return user?.Role;
        }

        public async Task<bool> IsFirstTimeLoginAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            return user != null && user.IsFirstTimeLogin;

        }

        public async Task SendOtpAsync(string userId, string email)
        {
            var otp = GenerateOtp();
            ValidateOtp validateOtp = new ValidateOtp
            {
                UserId = userId,
                Otp = otp
            };
            

             _context.ValidateOtps.Add(validateOtp); 
            await _context.SaveChangesAsync();
            SendEmail(email, "Your OTP", $"Your OTP is: {otp}");
            // Code to send OTP via email using SMTP


        }

        public async Task SendTemporaryPasswordAsync(string userId, string email)
        {

            var tempPassword = GenerateTemporaryPassword();
            var user = new User
            {
                UserId = userId,
                Password = tempPassword,
                Email = email,
                Role = "User",
                IsFirstTimeLogin = true
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Code to send tempPassword via email using SMTP
            SendEmail(email, "Your Temporary Password", $"Your temporary password is: {tempPassword}");

        }

        public async Task UpdatePasswordAsync(string userId, string newPassword)
        {
            var user = GetUserByIdAsync(userId);
            
            if (true)
            {
                user.Password = newPassword;
            
                user.IsFirstTimeLogin = false;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<bool> ValidateLoginAsync(string userId, string password)
        {
            return await _context.Users.AnyAsync(x => x.UserId == userId && x.Password == password);
        }

        public async Task<bool> ValidateOtpAsync(string userId, string otp)
        {
            var validateOtp = await _context.ValidateOtps.FirstOrDefaultAsync(x => x.UserId == userId && x.Otp == otp);
            return validateOtp != null;
        }


        // -----------------------------------------------------------------------------------------------------
        private string GenerateTemporaryPassword()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }

        private async Task SendEmail(string toEmail, string subject, string body)
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
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }



        }
        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

    }
}
