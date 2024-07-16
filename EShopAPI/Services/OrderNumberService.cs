using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

            // Create a new UserOrdersModel instance
            var newOrderNumber = new UserOrdersModel { OrderNumber = orderNumber };

            // Add it to the context
            _context.DbUsers.Add(newOrderNumber);

            // Save changes to the database
             _context.SaveChangesAsync();

            // Retrieve the added entity (optional, if needed)
            var addedOrder = await _context.DbUsers.FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);

            return addedOrder;
        }
    }
}
