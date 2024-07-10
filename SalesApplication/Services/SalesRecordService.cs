using SalesApplication.Interface;
using SalesApplication.Model;

namespace SalesApplication.Services
{
    
        public class SalesRecordService : ISalesRecordService
        {
            private readonly IUnitOfWork _unitOfWork;

            public SalesRecordService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<SalesRecord> GetSalesRecordByIdAsync(int id)
            {
                return await _unitOfWork.SalesRecords.GetByIdAsync(id);
            }

            public async Task<IEnumerable<SalesRecord>> GetAllSalesRecordsAsync()
            {
                return await _unitOfWork.SalesRecords.GetAllAsync();
            }

            public async Task AddSalesRecordAsync(SalesRecord salesRecord)
            {
                await _unitOfWork.SalesRecords.AddAsync(salesRecord);
                await _unitOfWork.CompleteAsync();
            }

            public async Task UpdateSalesRecordAsync(SalesRecord salesRecord)
            {
                _unitOfWork.SalesRecords.Update(salesRecord);
                await _unitOfWork.CompleteAsync();
            }

            public async Task DeleteSalesRecordAsync(int id)
            {
                var salesRecord = await _unitOfWork.SalesRecords.GetByIdAsync(id);
                if (salesRecord != null)
                {
                    _unitOfWork.SalesRecords.Delete(salesRecord);
                    await _unitOfWork.CompleteAsync();
                }
            }

            public async Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate)
            {
                var salesRecords = await _unitOfWork.SalesRecords.GetAllAsync();
                return salesRecords
                    .Where(sr => sr.Date >= startDate && sr.Date <= endDate)
                    .Sum(sr => sr.Price * sr.Quantity);
            }

            public async Task<IEnumerable<SalesTrend>> GetSalesTrendsAsync(DateTime startDate, DateTime endDate)
            {
                var salesRecords = await _unitOfWork.SalesRecords.GetAllAsync();

                var salesTrends = salesRecords
                    .Where(sr => sr.Date >= startDate && sr.Date <= endDate)
                    .GroupBy(sr => new { Year = sr.Date.Year, Month = sr.Date.Month })
                    .Select(g => new SalesTrend
                    {
                        Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                        TotalSales = g.Sum(sr => sr.Price * sr.Quantity)
                    })
                    .OrderBy(st => st.Date)
                    .ToList();

                return salesTrends;
            }

            public async Task<IEnumerable<SalesRecord>> GetTopProductsAsync(DateTime startDate, DateTime endDate)
            {
                var salesRecords = await _unitOfWork.SalesRecords.GetAllAsync();

                var topProducts = salesRecords
                    .Where(sr => sr.Date >= startDate && sr.Date <= endDate)
                    .GroupBy(sr => sr.ProductName)
                    .Select(g => new SalesRecord
                    {
                        ProductName = g.Key,
                        TotalQuantity = g.Sum(sr => sr.Quantity),
                        TotalRevenue = g.Sum(sr => sr.Price * sr.Quantity)
                    })
                    .OrderByDescending(sr => sr.TotalQuantity) 
                    .Take(10)
                    .ToList();

                return topProducts;
            }

            public async Task<IEnumerable<SalesRecord>> GetSalesByRegionAsync(string region, DateTime startDate, DateTime endDate)
            {

                var salesRecords = await _unitOfWork.SalesRecords.GetAllAsync();

                var salesByRegion = salesRecords
                    .Where(sr => sr.Region == region && sr.Date >= startDate && sr.Date <= endDate)
                    .ToList();

                return salesByRegion;
            }
        }

    
}
