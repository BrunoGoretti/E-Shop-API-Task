using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Services
{
    public class UserIdService : IUserIdService
    {
        private readonly ApiContext _context;

        public UserIdService(ApiContext context)
        {
            _context = context;
        }

        public async Task<UserOrdersModel> GetUserIdAsync(int userId)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException(nameof(userId), "User ID cannot be zero");
            }

            var newUserId = new UserOrdersModel { };

            _context.DbUsers.Add(newUserId);
            await _context.SaveChangesAsync();

            var createdUser = await _context.DbUsers
                .FirstOrDefaultAsync(x => x.UserId == newUserId.UserId);

            return createdUser ?? throw new Exception("User could not be created");
        }
    }
}