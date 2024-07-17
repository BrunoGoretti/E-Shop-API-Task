using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly ApiContext _context;

        public ReceiptService(ApiContext context)
        {
            _context = context;
        }

        public async Task<ReceiptModel> CreateReceiptAsync(UserOrdersModel order)
        {
            // Simulate payment processing
            bool paymentSuccess = true; // Replace with actual payment gateway logic

            if (paymentSuccess)
            {
                var receipt = new ReceiptModel
                {
                    UserId = order.UserId,
                    AmountPaid = order.PayableAmount ?? 0,
                    ReceiptNumber = Guid.NewGuid().ToString()
                };
                
                _context.Receipts.Add(receipt);
                await _context.SaveChangesAsync();
                string successMessage = "Order processed successfully.";
                Console.WriteLine(successMessage); 
                return receipt;
            }
            else
            {
                throw new Exception("Payment processing failed");
            }
        }
    }
}