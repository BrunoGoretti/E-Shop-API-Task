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
            var newUser = new Usermodel
            {
                UserId = userId,
            };

            _context.Add(newUser);

            await _context.SaveChangesAsync();

            return newUser;
        }

      
    }
}
