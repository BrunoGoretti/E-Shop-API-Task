namespace EShopAPI.Tests.Services
{
    [TestFixture]
    public class PaymentGatewayServiceTests
    {
        private ApiContext _context;
        private PaymentGatewayService _paymentGatewayService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApiContext(options);
            _paymentGatewayService = new PaymentGatewayService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetPaymentGatewayAsync_ShouldAddPaymentGatewayToContext()
        {
            // Arrange
            var paymentGateway = "PayPal";

            // Act
            var result = await _paymentGatewayService.GetPaymentGatewayAsync(paymentGateway);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(paymentGateway, result.PaymentGateway);

            var addedPaymentGateway = await _context.DbUsers.FirstOrDefaultAsync(u => u.PaymentGateway == paymentGateway);
            ClassicAssert.IsNotNull(addedPaymentGateway);
            ClassicAssert.AreEqual(paymentGateway, addedPaymentGateway.PaymentGateway);
        }
    }
}