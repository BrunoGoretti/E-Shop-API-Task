using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IOrderNumberService
    {
        Task<UserOrdersModel> GetOrderNumberAsync(int orderNumber);
        Task SaveChangesAsync();
    }
}
