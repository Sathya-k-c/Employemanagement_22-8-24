using Employemanagement_22_8_24.Models;

namespace Employemanagement_22_8_24.Data.Services
{
    public interface IUSERSERVICE
    {
        Task<User> GetUserDetailsAsync(string userId);
        Task DeleteRequestAsync(int requestId);
        Task AddRequestAsync(string userId, string editRequest);
        Task<List<Request>> GetAllRequestsByUserIdAsync(string userId);
    }
}
