using Microsoft.EntityFrameworkCore;

namespace SolarShare.Data
{
    public class SolarDataContext : DbContext
    {
        public SolarDataContext(DbContextOptions<SolarDataContext> options) : base(options)
        {
        }

        public DbSet<SolarData> SolarData { get; set; }
    }
}
