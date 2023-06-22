using Microsoft.EntityFrameworkCore;

namespace TraversalApp.SignalRForMsSql.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
