using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Models;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingOrder : ControllerBase
    {
        private readonly IUserIdService _userIdService;

        public IncomingOrder(IUserIdService userIdService)
        {
            _userIdService = userIdService;
        }

        [HttpPost("Add_user")]
        public async Task<ActionResult<UserOrdersModel>> AddUserAsync(int userId)
        {
            var newUser = await _userIdService.GetUserIdAsync(userId);
            return Ok(newUser);
        }

    }
}
