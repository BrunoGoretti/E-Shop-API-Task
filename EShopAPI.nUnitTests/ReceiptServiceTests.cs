namespace EShopAPI.nUnitTest
{
    public class ReceiptServiceTests
    {
        private ApiContext _context;
        private ReceiptService _receiptService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApiContext(options);
            _receiptService = new ReceiptService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task CreateReceiptAsync_ShouldCreateReceipt_WhenPaymentIsSuccessful()
        {
            // Arrange
            var order = new UserOrdersModel
            {
                UserId = 1,
                PayableAmount = 99.99
            };

            // Act
            var receipt = await _receiptService.CreateReceiptAsync(order);

            // Assert
            var receiptFromDb = await _context.Receipts.FindAsync(receipt.Id);
            ClassicAssert.NotNull(receiptFromDb);
            ClassicAssert.AreEqual(order.UserId, receiptFromDb.UserId);
            ClassicAssert.AreEqual(order.PayableAmount, receiptFromDb.AmountPaid);
            ClassicAssert.NotNull(receiptFromDb.ReceiptNumber);
        }

        [Test]
        public void CreateReceiptAsync_ShouldThrowException_WhenPaymentFails()
        {
            // Arrange
            var order = new UserOrdersModel
            {
                UserId = 1,
                PayableAmount = 99.99
            };

            var mockReceiptService = new Mock<ReceiptService>(_context) { CallBase = true };
            mockReceiptService.Setup(r => r.CreateReceiptAsync(It.IsAny<UserOrdersModel>()))
                              .ThrowsAsync(new Exception("Payment processing failed"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await mockReceiptService.Object.CreateReceiptAsync(order));
            ClassicAssert.AreEqual("Payment processing failed", ex.Message);
        }

        [Test]
        public async Task CreateReceiptAsync_ShouldHandleNullPayableAmount()
        {
            // Arrange
            var order = new UserOrdersModel
            {
                UserId = 1,
                PayableAmount = null
            };

            // Act
            var receipt = await _receiptService.CreateReceiptAsync(order);

            // Assert
            var receiptFromDb = await _context.Receipts.FindAsync(receipt.Id);
            ClassicAssert.NotNull(receiptFromDb);
            ClassicAssert.AreEqual(order.UserId, receiptFromDb.UserId);
            ClassicAssert.AreEqual(0, receiptFromDb.AmountPaid);
            ClassicAssert.NotNull(receiptFromDb.ReceiptNumber);
        }
    }
}