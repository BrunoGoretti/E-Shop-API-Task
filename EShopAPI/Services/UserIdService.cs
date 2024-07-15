using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Usermodel> GetUserIdAsync(int userId)
        {
            var user = await _context.DbUsers.FirstOrDefaultAsync(u => u.UserId == userId);
            return user;
        }

      
    }
}
