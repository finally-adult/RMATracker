using Microsoft.EntityFrameworkCore;
using RMATracker.Models;

namespace RMATracker.Data
{
    public class RMATrackerContext : DbContext
    {
        public RMATrackerContext(DbContextOptions<RMATrackerContext> options)
            : base(options)
        {
        }

        public DbSet<RMA> RMAs { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
    }
}
