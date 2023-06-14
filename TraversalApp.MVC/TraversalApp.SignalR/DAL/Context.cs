using Microsoft.EntityFrameworkCore;

namespace TraversalApp.SignalR.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //  //  builder.ApplyUtcDateTimeConverter();//Put before seed data and after model creation
        //}

        public DbSet<Visitor> Visitors { get; set; }
    }
}
