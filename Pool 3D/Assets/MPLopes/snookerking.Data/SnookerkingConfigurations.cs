using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using snookerking.Core;

namespace snookerking.Data
{
    public class SnookerkingConfigurations : IEntityTypeConfiguration<GameCore>
    {
        public void Configure(EntityTypeBuilder<GameCore> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}