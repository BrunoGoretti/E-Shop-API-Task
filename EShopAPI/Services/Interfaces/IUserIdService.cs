using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IUserIdService
    {
        Task<UserOrdersModel> GetUserIdAsync(int userId);
    }
}
