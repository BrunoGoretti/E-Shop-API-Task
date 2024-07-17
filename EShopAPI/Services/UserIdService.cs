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
            var newUserId = new UserOrdersModel
            {
                UserId = userId
            };

            _context.DbUsers.Add(newUserId);
            await _context.SaveChangesAsync();

            return newUserId;
        }
    }
}