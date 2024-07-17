using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            var newOrderNumber = new UserOrdersModel { OrderNumber = orderNumber };

            await _context.DbUsers.AddAsync(newOrderNumber);
            await _context.SaveChangesAsync();

            return await _context.DbUsers
                .Where(x => x.OrderNumber == orderNumber)
                .FirstOrDefaultAsync() ?? newOrderNumber;
        }
    }
}
