using SalesApplication.Model;

namespace SalesApplication.Services
{
    
        public interface ISalesRecordService
        {
            Task<SalesRecord> GetSalesRecordByIdAsync(int id);
            Task<IEnumerable<SalesRecord>> GetAllSalesRecordsAsync();
            Task AddSalesRecordAsync(SalesRecord salesRecord);
            Task UpdateSalesRecordAsync(SalesRecord salesRecord);
            Task DeleteSalesRecordAsync(int id);
            Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate);
            Task<IEnumerable<SalesTrend>> GetSalesTrendsAsync(DateTime startDate, DateTime endDate);
            Task<IEnumerable<SalesRecord>> GetTopProductsAsync(DateTime startDate, DateTime endDate);
            Task<IEnumerable<SalesRecord>> GetSalesByRegionAsync(string region, DateTime startDate, DateTime endDate);
        }

    
}
