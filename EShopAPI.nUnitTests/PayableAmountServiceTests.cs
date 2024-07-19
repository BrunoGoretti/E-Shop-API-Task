namespace EShopAPI.Tests.Services
{
    [TestFixture]
    public class PayableAmountServiceTests
    {
        private ApiContext _context;
        private PayableAmountService _payableAmountService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApiContext(options);
            _payableAmountService = new PayableAmountService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetPayableAmountAsync_ShouldAddPayableAmountToContext()
        {
            // Arrange
            var payableAmount = 100.50;

            // Act
            var result = await _payableAmountService.GetPayableAmountAsync(payableAmount);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(payableAmount, result.PayableAmount);

            var addedPayableAmount = await _context.DbUsers.FirstOrDefaultAsync(u => u.PayableAmount == payableAmount);
            ClassicAssert.IsNotNull(addedPayableAmount);
            ClassicAssert.AreEqual(payableAmount, addedPayableAmount.PayableAmount);
            ClassicAssert.AreEqual("DefaultGateway", addedPayableAmount.PaymentGateway); // Check required property
        }
    }
}