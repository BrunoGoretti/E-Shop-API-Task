using NUnit.Framework.Legacy;

namespace EShopAPI.nUnitTest
{
    public class IncomingOrderTests
    {
        private Mock<IUserIdService> _mockUserIdService;
        private Mock<IOrderNumberService> _mockOrderNumberService;
        private Mock<IPayableAmountService> _mockPayableAmountService;
        private Mock<IPaymentGatewayService> _mockPaymentGatewayService;
        private Mock<IOptionalDescriptionService> _mockOptionalDescriptionService;
        private Mock<IReceiptService> _mockReceiptService;
        private IncomingOrder _controller;
        private ApiContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApiContext(options);
            _mockUserIdService = new Mock<IUserIdService>();
            _mockOrderNumberService = new Mock<IOrderNumberService>();
            _mockPayableAmountService = new Mock<IPayableAmountService>();
            _mockPaymentGatewayService = new Mock<IPaymentGatewayService>();
            _mockOptionalDescriptionService = new Mock<IOptionalDescriptionService>();
            _mockReceiptService = new Mock<IReceiptService>();

            _controller = new IncomingOrder(
                _context,
                _mockUserIdService.Object,
                _mockOrderNumberService.Object,
                _mockPayableAmountService.Object,
                _mockPaymentGatewayService.Object,
                _mockOptionalDescriptionService.Object,
                _mockReceiptService.Object
            );
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddUserAsync_ShouldReturnOk_WhenOrderIsProcessedSuccessfully()
        {
            // Arrange
            int userId = 1;
            int orderNumber = 123;
            double paymentAmount = 99.99;
            string paymentGateway = "PayPal";
            string optionalDescription = "Order for electronic items";

            var newUserOrder = new UserOrdersModel
            {
                UserId = userId,
                OrderNumber = orderNumber,
                PayableAmount = paymentAmount,
                PaymentGateway = paymentGateway,
                OptionalDescription = optionalDescription
            };

            var receipt = new ReceiptModel
            {
                Id = 1,
                UserId = userId,
                AmountPaid = paymentAmount,
                ReceiptNumber = "R12345"
            };

            _mockReceiptService.Setup(r => r.CreateReceiptAsync(It.IsAny<UserOrdersModel>())).ReturnsAsync(receipt);

            // Act
            var result = await _controller.AddUserAsync(userId, orderNumber, paymentAmount, paymentGateway, optionalDescription);

            // Assert
            ClassicAssert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            ClassicAssert.AreEqual("Order processed successfully. Receipt number: R12345", okResult.Value);
        }

        [Test]
        public async Task AddUserAsync_ShouldReturnInternalServerError_WhenReceiptCreationFails()
        {
            // Arrange
            int userId = 1;
            int orderNumber = 123;
            double paymentAmount = 99.99;
            string paymentGateway = "PayPal";
            string optionalDescription = "Order for electronic items";

            var newUserOrder = new UserOrdersModel
            {
                UserId = userId,
                OrderNumber = orderNumber,
                PayableAmount = paymentAmount,
                PaymentGateway = paymentGateway,
                OptionalDescription = optionalDescription
            };

            _mockReceiptService.Setup(r => r.CreateReceiptAsync(It.IsAny<UserOrdersModel>())).ThrowsAsync(new Exception("Receipt creation failed"));

            // Act
            var result = await _controller.AddUserAsync(userId, orderNumber, paymentAmount, paymentGateway, optionalDescription);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<ObjectResult>());
            var objectResult = result.Result as ObjectResult;
            ClassicAssert.AreEqual(500, objectResult.StatusCode);
            ClassicAssert.AreEqual("Failed to process order: Receipt creation failed", objectResult.Value);
        }
    }
}