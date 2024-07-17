using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class OrderNumberService : IOrderNumberService
    {
        private readonly ApiContext _context;

        public OrderNumberService(ApiContext context)
        {
            _context = context;
        }

        public async Task<UserOrdersModel> GetOrderNumberAsync(int orderNumber)
        {
            var newUserOrder = new UserOrdersModel
            {
                OrderNumber = orderNumber
            };

            _context.DbUsers.Add(newUserOrder);
            await _context.SaveChangesAsync();

            return newUserOrder;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}