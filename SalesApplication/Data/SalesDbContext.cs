
using Microsoft.EntityFrameworkCore;
using SalesApplication.Model;

namespace SalesApplication.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }

        public DbSet<SalesRecord> SalesRecords { get; set; }
        
    }
}


