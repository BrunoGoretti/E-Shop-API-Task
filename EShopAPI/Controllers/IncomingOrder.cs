using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Models;
using EShopAPI.Data;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingOrder : ControllerBase
    {
        public readonly ApiContext _context;
        public readonly IUserIdService _userIdService;
        public readonly IOrderNumberService _userOrderService;
        public readonly IPayableAmountService _userPayableAmount;

        public IncomingOrder(ApiContext context, IUserIdService userIdService, IOrderNumberService userOrderService, IPayableAmountService userPayableAmount)
        {
            _context = context;
            _userIdService = userIdService;
            _userOrderService = userOrderService;
            _userPayableAmount = userPayableAmount;
        }

        [HttpPost("Make_order")]
        public async Task<ActionResult<UserOrdersModel>> AddUserAsync(int userId, int orderNumber, double paymentAmount)
        {
            var newUserOrder = new UserOrdersModel
            {
                UserId = userId,
                OrderNumber = orderNumber,
                PayableAmount = paymentAmount
            };

            _context.DbUsers.Add(newUserOrder);
            await _context.SaveChangesAsync();

            return Ok(newUserOrder);
        }
    }
}
