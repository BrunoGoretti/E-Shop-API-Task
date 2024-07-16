using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Models;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingOrder : ControllerBase
    {
        public readonly IUserIdService _userIdService;
        public readonly IOrderNumberService _userOrderService;

        public IncomingOrder(IUserIdService userIdService, IOrderNumberService userOrderNumber)
        {
            _userIdService = userIdService;
            _userOrderService = userOrderNumber;
        }

        [HttpPost("Make_order")]
        public async Task<ActionResult<UserOrdersModel>> AddUserAsync(int userId, int orderNumber)
        {
            var newUser = await _userIdService.GetUserIdAsync(userId);
            var addOrder = await _userOrderService.GetOrderNumberAsync(orderNumber);

            var response = new UserOrdersModel
            {
                UserId = newUser.UserId,
                OrderNumber = addOrder.OrderNumber
            };

            return Ok(response);
        }
    }
}
