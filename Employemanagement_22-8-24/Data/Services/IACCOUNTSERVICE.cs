namespace Employemanagement_22_8_24.Data.Services
{
    public interface IACCOUNTSERVICE
    {
        Task<bool> ValidateLoginAsync(string userId, string password);
        Task<bool> IsFirstTimeLoginAsync(string userId);
        void UpdatePasswordAsync(string userId, string newPassword);
        Task SendTemporaryPasswordAsync(string userId, string email);
        Task SendOtpAsync(string userId, string email);
        Task<bool> ValidateOtpAsync(string userId, string otp);
        Task<string> GetUserRoleAsync(string userId);
        Task ForgotPasswordAsync(string userId);
    }
}
