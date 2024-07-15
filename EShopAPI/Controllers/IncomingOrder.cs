using EShopAPI.Models;
using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // POST api/incomingorder/adduser
        [HttpPost("adduser")]
        public async Task<ActionResult<Usermodel>> AddUserAsync(int userId)
        {
            try
            {
                var newUser = await _userIdService.GetUserIdAsync(userId);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding user: {ex.Message}");
            }
        }

    }
}
