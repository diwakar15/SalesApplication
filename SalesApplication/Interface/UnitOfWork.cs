using Microsoft.EntityFrameworkCore;

namespace SalesApplication.Interface
{
        public class UnitOfWork : IUnitOfWork
        {
            private readonly DbContext _context;

            public UnitOfWork(DbContext context)
            {
                _context = context;
                SalesRecords = new SalesRecordRepository(_context);
            }

            public ISalesRecordRepository SalesRecords { get; }

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
