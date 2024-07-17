using EShopAPI.Models;

namespace EShopAPI.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<ReceiptModel> CreateReceiptAsync(UserOrdersModel order);
    }
}