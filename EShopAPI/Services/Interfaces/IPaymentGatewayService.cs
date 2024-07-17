using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IPaymentGatewayService
    {
        Task<UserOrdersModel> GetPaymentGatewayAsync(string paymentGateway);
        Task SaveChangesAsync();
    }
}
