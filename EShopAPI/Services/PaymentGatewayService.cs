using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        private readonly ApiContext _context;
        public PaymentGatewayService(ApiContext context)
        {
            _context = context;
        }
        public async Task<UserOrdersModel> GetPaymentGatewayAsync(string payGateway)
        {
            var newPaymentGateway = new UserOrdersModel
            {
                PaymentGateway = payGateway
            };

            _context.DbUsers.Add(newPaymentGateway);
            await _context.SaveChangesAsync();

            return newPaymentGateway;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
