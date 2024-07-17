using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IPayableAmountService
    {
        Task<UserOrdersModel> GetPayableAmountAsync(double orderNumber);
        Task SaveChangesAsync();
    }
}
