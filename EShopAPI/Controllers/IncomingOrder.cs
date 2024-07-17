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
        public readonly IPaymentGatewayService _userGatewayService;
        public readonly IOptionalDescriptionService _userOptimalDescription;
        private readonly IReceiptService _receiptService;

        public IncomingOrder(ApiContext context, IUserIdService userIdService, IOrderNumberService userOrderService, IPayableAmountService userPayableAmount, 
            IPaymentGatewayService userGatewayService, IOptionalDescriptionService userOptimalDescription, IReceiptService receiptService)
        {
            _context = context;
            _userIdService = userIdService;
            _userOrderService = userOrderService;
            _userPayableAmount = userPayableAmount;
            _userGatewayService = userGatewayService;
            _userOptimalDescription = userOptimalDescription;
            _receiptService = receiptService;
        }

    [HttpPost("Make_order")]
        public async Task<ActionResult<ReceiptModel>> AddUserAsync(int userId, int orderNumber, double paymentAmount, string paymentGateway,
            string optimalDescription)
        {
            var newUserOrder = new UserOrdersModel
            {
                UserId = userId,
                OrderNumber = orderNumber,
                PayableAmount = paymentAmount,
                PaymentGateway = paymentGateway,
                OptionalDescription = optimalDescription
            };

            _context.DbUsers.Add(newUserOrder);
            await _context.SaveChangesAsync();

            try
            {
                var receipt = await _receiptService.CreateReceiptAsync(newUserOrder);
                return Ok($"Order processed successfully. Receipt number: {receipt.ReceiptNumber}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to process order: {ex.Message}");
            }
        }
    }
}
