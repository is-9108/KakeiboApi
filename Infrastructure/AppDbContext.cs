using Kakeibo.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kakeibo.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
