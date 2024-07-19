namespace EShopAPI.nUnitTest
{
    public class UserIdServiceTests
    {
        private ApiContext _context;
        private UserIdService _userIdService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApiContext(options);
            _userIdService = new UserIdService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task GetUserIdAsync_ShouldAddUserIdToDatabase_WhenCalled()
        {
            // Arrange
            int userId = 1;

            // Act
            var result = await _userIdService.GetUserIdAsync(userId);

            // Assert
            var userFromDb = await _context.DbUsers.FindAsync(result.UserId);
            ClassicAssert.NotNull(userFromDb);
            ClassicAssert.AreEqual(userId, userFromDb.UserId);
            ClassicAssert.AreEqual("PayPal", userFromDb.PaymentGateway);
        }

        [Test]
        public async Task GetUserIdAsync_ShouldReturnUserOrdersModel_WhenCalled()
        {
            // Arrange
            int userId = 2;

            // Act
            var result = await _userIdService.GetUserIdAsync(userId);

            // Assert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(userId, result.UserId);
            ClassicAssert.AreEqual("PayPal", result.PaymentGateway); 
        }
    }
}