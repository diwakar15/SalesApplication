using SalesApplication.Model;

namespace SalesApplication.Interface
{

    public interface ISalesRecordRepository1
    {
        Task<SalesRecord> GetByIdAsync(int id);
        Task<IEnumerable<SalesRecord>> GetAllAsync();
        Task AddAsync(SalesRecord salesRecord);
        void Update(SalesRecord salesRecord);
        void Delete(SalesRecord salesRecord);
    }




}
