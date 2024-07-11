using Microsoft.EntityFrameworkCore;
using SalesApplication.Data;

namespace SalesApplication.Interface
{
        public class UnitOfWork : IUnitOfWork
        {
            private readonly SalesDbContext _context;

            public UnitOfWork(SalesDbContext context)
            {
                _context = context;
                SalesRecords = new SalesRecordRepository1(_context);
            }

            public ISalesRecordRepository1 SalesRecords { get; }

            public async Task<int> CompleteAsync()
            {
                return await _context.SaveChangesAsync();
            }

            public void Dispose()
            {
                _context.Dispose();
            }
        }

    
}
