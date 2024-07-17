using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IOptionalDescriptionService
    {
        Task<UserOrdersModel> GetOptionalDescriptionAsync(string optionalDescription);
        Task SaveChangesAsync();
    }
}
