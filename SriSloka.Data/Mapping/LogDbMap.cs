using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class LogDbMap:EntityTypeConfiguration<Log>
    {
        public override void Map(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Application).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Logged).IsRequired();
            builder.Property(x => x.Level).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(2500).IsRequired();
            builder.Property(x => x.Logger).HasMaxLength(250);
            builder.Property(x => x.Callsite).HasMaxLength(2500);
            builder.Property(x => x.Exception).HasMaxLength(2500);
        }
    }
}
