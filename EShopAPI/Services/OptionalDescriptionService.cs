using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class OptionalDescriptionService : IOptionalDescriptionService
    {
        private readonly ApiContext _context;

        public OptionalDescriptionService(ApiContext context)
        {
            _context = context;
        }

        public async Task<UserOrdersModel> GetOptionalDescriptionAsync(string optimalDescription)
        {
            var newOptimalDescription = new UserOrdersModel
            {
                OptionalDescription = optimalDescription
            };

            _context.DbUsers.Add(newOptimalDescription);
            await _context.SaveChangesAsync();

            return newOptimalDescription;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
