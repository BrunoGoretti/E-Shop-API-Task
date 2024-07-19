using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class PayableAmountService : IPayableAmountService
    {
        private readonly ApiContext _context;
        public PayableAmountService(ApiContext context)
        {
            _context = context;
        }

        public async Task<UserOrdersModel> GetPayableAmountAsync(double payAmount)
        {
            var newPaymentAmount = new UserOrdersModel
            {
                PayableAmount = payAmount,
                PaymentGateway = "DefaultGateway"
            };

            _context.DbUsers.Add(newPaymentAmount);
            await _context.SaveChangesAsync();

            return newPaymentAmount;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
