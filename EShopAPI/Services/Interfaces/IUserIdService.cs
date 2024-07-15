using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IUserIdService
    {
        Task<Usermodel> GetUserIdAsync(int userId);
    }
}
