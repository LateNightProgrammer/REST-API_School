using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class StandardDbMap : EntityTypeConfiguration<Standard>
    {
        public override void Map(EntityTypeBuilder<Standard> builder)
        {
            builder.HasKey(x => x.StandardId);

            builder.Property(x => x.Description).HasMaxLength(150);

            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}
