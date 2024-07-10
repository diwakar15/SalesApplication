using Microsoft.EntityFrameworkCore;
using SalesApplication.Model;

namespace SalesApplication.Interface
{

    public class SalesRecordRepository : ISalesRecordRepository
    {
        private readonly DbContext _context;

        public SalesRecordRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<SalesRecord> GetByIdAsync(int id)
        {
            return await _context.Set<SalesRecord>().FindAsync(id);
        }

        public async Task<IEnumerable<SalesRecord>> GetAllAsync()
        {
            return await _context.Set<SalesRecord>().ToListAsync();
        }

        public async Task AddAsync(SalesRecord salesRecord)
        {
            await _context.Set<SalesRecord>().AddAsync(salesRecord);
        }

        public void Update(SalesRecord salesRecord)
        {
            _context.Set<SalesRecord>().Update(salesRecord);
        }

        public void Delete(SalesRecord salesRecord)
        {
            _context.Set<SalesRecord>().Remove(salesRecord);
        }
    }




}
