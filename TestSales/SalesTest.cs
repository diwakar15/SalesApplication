using Moq;
using SalesApplication.Interface;
using SalesApplication.Model;
using SalesApplication.Services;
using static SalesApplication.Services.SalesRecordService;
using SalesRecordService = SalesApplication.Services.SalesRecordService;

namespace TestSales
{
    public class SalesRecordServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly ISalesRecordService _salesRecordService;

        public SalesRecordServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _salesRecordService = new SalesRecordService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetSalesRecordByIdAsync_ReturnsSalesRecord()
        {
            // Arrange
            var salesRecord = new SalesRecord { Id = 1, ProductName = "Product1" };
            _mockUnitOfWork.Setup(u => u.SalesRecords.GetByIdAsync(1)).ReturnsAsync(salesRecord);

            // Act
            var result = await _salesRecordService.GetSalesRecordByIdAsync(1);

            // Assert
            Assert.Equal(salesRecord, result);
        }

       
    }

}