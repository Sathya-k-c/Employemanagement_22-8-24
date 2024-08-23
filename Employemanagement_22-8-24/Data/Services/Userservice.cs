using Employemanagement_22_8_24.Data.Enums;
using Employemanagement_22_8_24.Models;
using Microsoft.EntityFrameworkCore;

namespace Employemanagement_22_8_24.Data.Services
{
    public class Userservice : IUSERSERVICE
    {
        private List<Request> _editRequests = new List<Request>();

        private readonly ApplicationDbContext _context;

        public Userservice(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddRequestAsync(string userId, string editRequest)
        {
            if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(editRequest)) throw new ArgumentNullException(nameof(editRequest));

            var request = new Request
            {
                RequestId = GenerateUniqueRequestId(),
                UserId = userId,
                EditRequest = editRequest,
                RequestDate = DateTime.UtcNow, // Current date and time
                isprocessed = Isprocessed.Processing // Default status
            };

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteRequestAsync(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request == null) throw new KeyNotFoundException("Request not found.");

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Request>> GetAllRequestsByUserIdAsync(string userId)
        {
            return await _context.Requests
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }


        public async Task<User> GetUserDetailsAsync(string userId)
        {
            return await _context.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }
        // -------------------------------------------------------------------------------------------------------

        private int GenerateUniqueRequestId()
        {
            var random = new Random();
            int requestId;
            bool isUnique;

            do
            {
                requestId = random.Next(1000, 10000); // Generates a number between 1000 and 9999
                isUnique = !_context.Requests.Any(r => r.RequestId == requestId);
            } while (!isUnique);

            return requestId;
        }
    }
}
