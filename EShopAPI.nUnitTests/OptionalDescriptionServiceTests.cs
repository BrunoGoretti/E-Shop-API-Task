namespace EShopAPI.Tests.Services
{
    [TestFixture]
    public class OptionalDescriptionServiceTests
    {
        private ApiContext _context;
        private OptionalDescriptionService _optionalDescriptionService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApiContext(options);
            _optionalDescriptionService = new OptionalDescriptionService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetOptionalDescriptionAsync_ShouldAddOptionalDescriptionToContext()
        {
            // Arrange
            var optionalDescription = "This is an optional description";

            // Act
            var result = await _optionalDescriptionService.GetOptionalDescriptionAsync(optionalDescription);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(optionalDescription, result.OptionalDescription);

            var addedDescription = await _context.DbUsers.FirstOrDefaultAsync(u => u.OptionalDescription == optionalDescription);
            ClassicAssert.IsNotNull(addedDescription);
            ClassicAssert.AreEqual(optionalDescription, addedDescription.OptionalDescription);
            ClassicAssert.AreEqual("DefaultGateway", addedDescription.PaymentGateway); 
        }
    }
}