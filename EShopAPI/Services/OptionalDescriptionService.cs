using EShopAPI.Data;
using EShopAPI.Models;
using EShopAPI.Services.Interfaces;

public class OptionalDescriptionService : IOptionalDescriptionService
{
    private readonly ApiContext _context;

    public OptionalDescriptionService(ApiContext context)
    {
        _context = context;
    }

    public async Task<UserOrdersModel> GetOptionalDescriptionAsync(string optionalDescription)
    {
        var newOptionalDescription = new UserOrdersModel
        {
            OptionalDescription = optionalDescription,
            PaymentGateway = "DefaultGateway" 
        };

        _context.DbUsers.Add(newOptionalDescription);
        await _context.SaveChangesAsync();

        return newOptionalDescription;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}