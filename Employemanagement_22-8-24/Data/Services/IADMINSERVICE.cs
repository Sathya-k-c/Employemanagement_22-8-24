﻿using Employemanagement_22_8_24.Models;

namespace Employemanagement_22_8_24.Data.Services
{
    public interface IADMINSERVICE
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(string userId);
        Task UpdateUserDetailsAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task DeleteUserAsync(User user);
        Task<List<Request>> GetAllRequestsAsync();
       
        Task AddLoginAsync(string userId, string email);

        Task CreateUserAsync(User user);
        Task<string> GenerateUserIdAsync();

        Task<Request> GetRequestByIdAsync(int requestId);

        Task UpdateRequestAsync(Request request);
    }
}
