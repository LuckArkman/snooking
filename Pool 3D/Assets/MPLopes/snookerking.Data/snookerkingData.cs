using Microsoft.EntityFrameworkCore;
using snookerking.Core;

namespace snookerking.Data
{
    public class snookerkingData : DbContext
    {
        public DbSet<GameCore> Categories => Set<GameCore>();
        public snookerkingData(DbContextOptions<snookerkingData> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder) => builder.ApplyConfiguration(new SnookerkingConfigurations());
    }
}